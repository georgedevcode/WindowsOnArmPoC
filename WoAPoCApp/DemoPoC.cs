using BenchmarkDotNet.Attributes;
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
            this.RandomNumber = rand.Next(this.arr.Length);

            return RandomNumber;
        }

        [Benchmark]
        public void SortArray()
        {

            Array.Sort(this.arr);
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

                break;
            }

            return FoundTarget;
        }

        //[Benchmark]
        //public bool BinarySearch() {

        //    return FoundTarget;
        //}
    }
}
