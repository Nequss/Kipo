using System;
using System.Collections;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
namespace KipoBot.Modules
{
    public class MetricsModule
    {
        public int memoryMax { get; private set;}
        public int memoryUsed { get; private set; }
        public int memoryFree { get; private set; }


        public MetricsModule()
        {
            MetricsModule tmp = getMemoryData();
            memoryMax = tmp.memoryMax;
            memoryUsed = tmp.memoryUsed;
            memoryFree = tmp.memoryFree;
        }
      
        private MetricsModule(int max, int used)
        {
            memoryMax = max;
            memoryUsed = used;
            memoryFree = memoryMax - memoryUsed;
        }
        
        // Returns used memory in %
        public float getUsedPercent()
        {
            return ((float)memoryUsed / (float)memoryMax)*100;
        }

        // Returns free memory in %
        public float getFreePercent()
        {
            return  ((float)memoryFree / (float)memoryMax)*100;
        }

        // Converts stored values to GB - this operation cannot be reverted
        public void convertToGB()
        {
            memoryMax /= 1024;
            memoryFree /= 1024;
            memoryUsed /= 1024;
        }

        private static MetricsModule getMemoryData()
        {
            if (isUnix())
            {
                return getUnixMetrics();
            }
            else
            {
                return getWindowsMetrics();
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
            return new MetricsModule(1, 0);
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
                int memMax = Int32.Parse(memory[1]); // Obtain max system ram
                int memUsed = Int32.Parse(memory[2]); // Obtain used system ram
                
                return new MetricsModule(memMax, memUsed);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new MetricsModule(1, 0);
            }
        }
    }
}