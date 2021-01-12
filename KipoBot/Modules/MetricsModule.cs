using System;
using System.Collections;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
namespace KipoBot.Modules
{
    public class MetricsModule
    {
        public double memoryMax { get; }
        public double memoryUsed { get; }
        public double memoryFree { get; }
      
        private MetricsModule(double max, double used, double free)
        {
            memoryMax = max;
            memoryFree = free;
            memoryUsed = used;
        }
        
        // Returns used memory in %
        public float getUsedPercent()
        {
            return (float)memoryUsed / (float)memoryMax;
        }

        // Returns free memory in %
        public float getFreePercent()
        {
            return (float) memoryFree / (float)memoryMax;
        }

        public static MetricsModule getMemoryData()
        {
            if (isUnix())
            {
                //Unix functions
                return getUnixMetrics();
            }
            else
            {
                return new MetricsModule(1,0,0);
                //Windows functions
            }
        }

        private static bool isUnix()
        {
            var isUnix = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                         RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            return isUnix;
        }

        private static MetricsModule getWindowsMetrics()
        {
            //TODO
            return new MetricsModule(1, 0, 0);
        }

        private static MetricsModule getUnixMetrics()
        {
            var info = new ProcessStartInfo("free -m");
            info.FileName = "/bin/sh";
            info.Arguments = "-c \"free -m\"";
            info.RedirectStandardOutput = true;

            try
            {
                var process = Process.Start(info);
                var output=process.StandardOutput.ReadToEnd();
                var lines = output.Split("\n");
                var memory = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                double memMax = double.Parse(memory[1]); // Obtain max system ram
                double memUsed = double.Parse(memory[2]); // Obtain used system ram
                double memFree = memMax - memUsed; // Calculate free ram
                
                return new MetricsModule(memMax, memUsed, memFree);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new MetricsModule(1, 0, 0);
            }
        }
    }
}