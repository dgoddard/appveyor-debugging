﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FooBar
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                FileName = @"cmd.exe",
                Arguments = "/C set",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                
            };
            p.Start();
            Thread.Sleep(100);
            p.WaitForExit(10000);
            if (p.HasExited)
            {
                Console.WriteLine(p.ExitCode);
                Console.WriteLine(p.StandardOutput.ReadToEnd());
            }
            else
            {
                p.Kill();
                Console.WriteLine("DID NOT EXIT");
            }
        }        
    }
}
