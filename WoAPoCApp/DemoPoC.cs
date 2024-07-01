using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoAPoCApp
{
    public class DemoPoC
    {
        public readonly int[] arr = new int[1000000];
        public int RandomNumber = 0;
        private bool FoundTarget = false;
        private int Target = 0;
        private int left = 0;
        private int right = 0;

        Random rand = new Random();
        public DemoPoC()
        {
            SetUpArray();

            QuickSort(this.arr, this.left, this.right);

            this.Target = GenerateRandNumber();
        }

        [Benchmark]
        public int[] SetUpArray()
        {

            for (int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = GenerateRandNumber();
            }

            this.right = this.arr.Length - 1;

            return this.arr;
        }

        [Benchmark]
        public int GenerateRandNumber()
        {
            this.RandomNumber = rand.Next(this.arr.Length);

            return RandomNumber;
        }

        public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];

            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        // O(N log(N))
        [Benchmark]
        public void QuickSort()
        {

            if (left < right)
            {

                int pivot = Partition(this.arr, left, right);

                if (pivot > 1)
                {

                    QuickSort(this.arr, left, right);

                }

                if (pivot + 1 < right)
                {
                    QuickSort(this.arr, pivot + 1, right);
                }

            }

        }

        [Benchmark]
        public bool LinearSearch()
        {

            while (!FoundTarget)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == this.RandomNumber)
                    {
                        FoundTarget = true;
                    }
                }
            }

            return FoundTarget;
        }

        //[Benchmark]
        //public bool BinarySearch() {

        //    return FoundTarget;
        //}
    }
}
