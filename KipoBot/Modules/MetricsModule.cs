using System;
using System.Collections;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
namespace KipoBot.Modules
{
    public class MetricsModule
    {
        private String platform="";
        private int memoryMax;
        private int memoryUsed;
        private int memoryFree; 


        public MetricsModule()
        {
            MetricsModule tmp = getSystemData();
            readOsPlatform();
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

        public int getMemoryMaxGB()
        {
            return memoryMax / 1024;
        }
        public int getMemoryUsedGB()
        {
            return memoryUsed / 1024;
        }
        public int getMemoryFreeGB()
        {
            return memoryFree / 1024;
        }
         public int getMemoryMaxMB()
         {
             return memoryMax;
         }
         public int getMemoryUsedMB()
         {
             return memoryUsed;
         }
         public int getMemoryFreeMB()
         {
             return memoryFree;
         }

        private static MetricsModule getSystemData()
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

        public String getOsPlatform()
        {
            return platform;
        }

        private void readOsPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                platform = "Linux";
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                platform = "MacOS";
            else
                platform = "Windows";
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
            info.FileName = "/bin/bash";
            info.Arguments = "-c \"free -m\"";
            info.RedirectStandardOutput = true;

            try
            {
                var process = Process.Start(info);
                var output = process.StandardOutput.ReadToEnd();
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