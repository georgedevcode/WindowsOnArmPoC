using BenchmarkDotNet.Attributes;
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

        Random rand = new Random();
        public DemoPoC()
        {
            SetUpArray(arr);

            GenerateRandNumber();
        }

        public int[] SetUpArray(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                this.arr[i] = i;
            }

            return this.arr;
        }

        [Benchmark]
        public int GenerateRandNumber()
        {
            this.RandomNumber = rand.Next(this.arr.Length);

            return RandomNumber;
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
