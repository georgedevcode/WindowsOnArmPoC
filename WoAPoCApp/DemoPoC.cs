using BenchmarkDotNet.Attributes;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WoAPoCApp
{
    public class DemoPoC
    {
        private readonly int[] arr = new int[1000000];
        private bool FoundTarget = false;
        private int Target = 0;
        private int left = 0;
        private int right = 0;

        Random rand = new Random();

        public DemoPoC()
        {
            SetUpArray();

            SortArray();
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
            this.Target = rand.Next(this.arr.Length);

            return Target;
        }

        [Benchmark]
        public void SortArray()
        {

            Array.Sort(this.arr);

        }
 
        [Benchmark]
        public bool LinearSearch()
        {

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == this.Target)
                {
                    FoundTarget = true;

                    break;
                }
            }

            return FoundTarget;
        }

        [Benchmark]
        public int Binarysearch()
        {
            int low = 0, high = arr.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                // Check if x is present at mid
                if (arr[mid] == Target)
                    return mid;

                // If x greater, ignore left half
                if (arr[mid] < Target)
                    low = mid + 1;

                // If x is smaller, ignore right half
                else
                    high = mid - 1;
            }

            // If we reach here, then element was
            // not present
            return -1;
        }
    }
}
