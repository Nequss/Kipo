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
                    Program.Logger.info("JobManager: Started job checking...");
                    foreach (var job in jobList)
                    {
                        Program.Logger.info($"Checking job: {job.name} for pet: {job.worker.name}");
                        
                        if (job.markedForDeletion)
                        {
                            deletionList.Add(job);
                            Program.Logger.info($"Deleted job for pet: {job.worker.name}");
                        }
                        else
                        {
                            if (DateTime.Compare(currentTime, job.timeEnd) >= 0)
                            {
                                job.workCompleted();
                                deletionList.Add(job);
                                Program.Logger.info("Job completed");
                            }
                            else
                            {
                                Program.Logger.info($"Job will be completed in: {job.timeEnd.Subtract(currentTime)}");
                            }
                        }
                    }

                    Program.Logger.info("JobManager: Job checking completed!");
                    removeCompletedJobs();

                    //Thread.Sleep(checkIntervalMinutes*1000*60);
                    Thread.Sleep(5000);
                }
            }

            Program.Logger.warn("JobManager: Stopped!");
        }

        private static void removeCompletedJobs()
        {
            int count = 0;
            Program.Logger.info("Removing completed jobs...");
            foreach (var job in deletionList)
            {
                jobList.Remove(job);
                count++;
            }

            deletionList = new List<Work>();
            Program.Logger.info($"Removed {count} completed jobs!");
        }
    }
}