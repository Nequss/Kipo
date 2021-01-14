using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
namespace KipoBot.Modules
{
    public class MetricsModule
    {
        private OS platform = OS.OTHER;
        private int memoryMax;
        private int memoryUsed;
        private int memoryFree; 


        public MetricsModule()
        {
            readOsPlatform();
            MetricsModule tmp = getSystemData();
            memoryMax = tmp.memoryMax;
            memoryUsed = tmp.memoryUsed;
            memoryFree = tmp.memoryFree;
        }
      
        private MetricsModule(int max, int used)
        {
            if (max <= 0)
                max = 1;
            
            memoryMax = max;
            memoryUsed = used;
            memoryFree = memoryMax - memoryUsed;
        }

        public int getCpuNow()
        {
            switch (platform)
            {
                case OS.LINUX:
                    return getCpuLinux();
                    break;
                case OS.WINDOWS:
                    return getCpuWindows();
                    break;
                case OS.MACOS:
                    return getCpuMacOS();
                    break;
                default:
                    return 0;
                    break;
            }
        }

        private int getCpuMacOS()
        {
            return 0;
        }

        private int getCpuWindows()
        {
            return 0;
        }

        private int getCpuLinux()
        {
            var info = new ProcessStartInfo("top -bn 1 | grep '%Cpu(s):' | sed 's/%Cpu(s)://; s/us,//g; s/sy,//g; s/ni//g; s/,/./g' | cut -c 2-18");
            info.FileName = "/bin/bash";
            info.Arguments = "-c \"top -bn 1 | grep '%Cpu(s):' | sed 's/%Cpu(s)://; s/us,//g; s/sy,//g; s/ni//g; s/,/./g' | cut -c 2-18\"";
            info.RedirectStandardOutput = true; 
                
            try
            {
                var process = Process.Start(info);
                var output = process.StandardOutput.ReadToEnd();
                var lines = output.Split("\n");
                var usage = lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                float sum = 0;
                foreach (var number in usage)
                {
                    sum += Int32.Parse(number);
                }
                return (int)Math.Round(sum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            } 
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

        private MetricsModule getSystemData()
        {
            switch (platform)
            {
                case OS.LINUX:
                    return getLinuxMemoryInfo();
                    break;
                case OS.WINDOWS:
                    return getWindowsMemoryInfo();
                    break;
                case OS.MACOS:
                    //TODO
                    return getMacOSMemoryInfo();
                    break;
                case OS.OTHER:
                    //TODO
                    return getEmptyModule();
                    break;
                default:
                    //TODO
                    return getEmptyModule();
                    break;
            }
        }

        private MetricsModule getEmptyModule()
        {
            return new MetricsModule(1, 0);
        }

        public String getOsPlatform()
        {
            switch (platform)
            {
                case OS.LINUX:
                    return "Linux";
                    break;
                case OS.WINDOWS:
                    return "Windows";
                    break;
                case OS.MACOS:
                    return "MacOS";
                    break;
                default:
                    return "Other";
                    break;
            }
        }

        private void readOsPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                platform = OS.LINUX;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                platform = OS.MACOS;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                platform = OS.WINDOWS;
            else
                platform = OS.OTHER;
        }

        private static MetricsModule getWindowsMemoryInfo()
        {
            //TODO
            return new MetricsModule(0, 0);
        }

        private static MetricsModule getLinuxMemoryInfo()
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
                return new MetricsModule(0, 0);
            }
        }

        private static MetricsModule getMacOSMemoryInfo()
        {
            //TODO
            return new MetricsModule(0,0);
        }
        
        private enum OS
        {
            WINDOWS,
            LINUX,
            MACOS,
            OTHER
            
        }
    }
}