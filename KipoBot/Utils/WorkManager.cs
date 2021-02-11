using System;
using System.Collections.Generic;
using System.Threading;
using Kipo.Modules;
using KipoBot.Game.Base;

namespace KipoBot.Utils
{
    public class WorkManager
    {
        public static List<Work> jobList = new List<Work>();
        private static List<Work> deletionList = new List<Work>();
        private static int checkIntervalMinutes = 1;
        public static bool running = false;

        public static void Start()
        {
            while (running)
            {
                DateTime currentTime = DateTime.Now;

                lock (jobList)
                {
                    Console.WriteLine("JobManager: Started job checking...");
                    foreach (var job in jobList)
                    {
                        Console.WriteLine($"Checking job: {job.name} for pet: {job.worker.name}");
                        
                        if (job.markedForDeletion)
                        {
                            deletionList.Add(job);
                            Console.WriteLine($"Deleted job for pet: {job.worker.name}");
                        }
                        else
                        {
                            if (DateTime.Compare(currentTime, job.timeEnd) >= 0)
                            {
                                job.workCompleted();
                                deletionList.Add(job);
                                Console.WriteLine("Job completed");
                            }
                            else
                            {
                                Console.WriteLine($"Job will be completed in: {currentTime.Subtract(job.timeEnd)}");
                            }
                        }
                    }

                    Console.WriteLine("JobManager: Job checking completed!");
                    removeCompletedJobs();

                    //Thread.Sleep(checkIntervalMinutes*1000*60);
                    Thread.Sleep(5000);
                }
            }
        }

        private static void removeCompletedJobs()
        {
            int count = 0;
            Console.WriteLine("Removing completed jobs...");
            foreach (var job in deletionList)
            {
                jobList.Remove(job);
                count++;
            }

            deletionList = new List<Work>();
            Console.WriteLine($"Removed {count} completed jobs!");
        }
    }
}