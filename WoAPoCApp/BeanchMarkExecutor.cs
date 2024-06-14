using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoAPoCApp
{
    public class BeanchMarkExecutor
    {
        [Benchmark]
        public void Execute() { 
        
            var calculator = new Calculador();

            calculator.Add(1, 2);

        }
    }
}
