using System;
using System.Threading;

namespace LEXTRAIT_Hugo_TP3_ST2TRD
{
    //  ------------------------------------------------------------------------------------------------------------
    //  Exercice 2 : Create a simple function that create 3 threads:
    //                  1. The 1st prints an empty space for 10 seconds, every 50ms.
    //                  2. The 2nd prints * for 11 seconds, every 40ms.
    //                  3. The 3rd prints ° for 9 seconds, every 20ms. 
    public class ThreadManager
    {
        private static Mutex _mut = new Mutex(); // Creation and initialisation of a Mutex
        private const int NbThreads = 3;
        public void run_threads()
        {
            Console.WriteLine("----------------------------------------------\n");
            Console.WriteLine("Exercice 2 : Create a sky full of stars using multithreads, expiration dates and single printing method\n");

            for (int i = 0; i<NbThreads; i++) //  Threads creation 
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProcessor));
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
            }
            // Main Static method is ended but threads will continue to execute until they die (Expiration Datetime here)
        }
        
        
        private static void ThreadProcessor()
        {
            // Expiration Calculation
            ThreadManager obj = new ThreadManager();
            DateTime startDate = DateTime.Now;
            DateTime expiration1 = startDate.AddSeconds(10);
            DateTime expiration2 = startDate.AddSeconds(9);
            DateTime expiration3 = startDate.AddSeconds(11);

            // Thread's information (User interface)
            switch (Thread.CurrentThread.Name)
            {
                case "Thread1":
                    Console.WriteLine("[{0}] - Begin at -> {1} | Expire at-> {2} | Duration -> {3}s",
                        Thread.CurrentThread.Name, startDate.ToString("mm:ss.fff"),expiration1.ToString("mm:ss.fff"),(expiration1 - startDate));
                    break;
                case "Thread2":
                    Console.WriteLine("[{0}] - Begin at -> {1} | Expire at-> {2} | Duration -> {3}s", 
                        Thread.CurrentThread.Name, startDate.ToString("mm:ss.fff"), expiration2.ToString("mm:ss.fff"),(expiration2 - startDate));
                    break;
                case "Thread3":
                    Console.WriteLine("[{0}] - Begin at -> {1} | Expire at-> {2} | Duration -> {3}s",
                        Thread.CurrentThread.Name, startDate.ToString("mm:ss.fff"), expiration3.ToString("mm:ss.fff"),(expiration3 - startDate));
                    break;
            }
            
            // Thread's expiration date
            int exp1= DateTime.Compare(expiration1, DateTime.Now);
            int exp2 = DateTime.Compare(expiration1, DateTime.Now);
            int exp3 = DateTime.Compare(expiration1, DateTime.Now);
            bool isAlive = true; // Thread's life cycle

            while (isAlive) // This loop request the unique function that prints characters (shared between 3 different threads)
            {
                isAlive = false;
                switch (Thread.CurrentThread.Name)
                {
                    case "Thread1":
                        if (exp1 > 0)
                        {
                            isAlive = true;
                            Thread.Sleep(50);
                            exp1 = DateTime.Compare(expiration1, DateTime.Now);
                        }
                        break;
                    case "Thread2":
                        if (exp2 > 0)
                        {
                            isAlive = true;
                            Thread.Sleep(40);
                            exp2 = DateTime.Compare(expiration2, DateTime.Now);
                        }
                        break;
                    case "Thread3":
                        if (exp3 > 0)
                        {
                            isAlive = true;
                            Thread.Sleep(20);
                            exp3 = DateTime.Compare(expiration3, DateTime.Now);
                        }
                        break;
                }
                if (isAlive)
                {
                    ThreadManager.PrintChar();
                }  
            }
        }
        
        //  Function that match and print the caracter that correponds to the thread
        private static void PrintChar() //   This function can be accessed by only one thread at the same time
        {
            _mut.WaitOne(); // Request the right of accessing the Muttex -> thread wait his turn
            
            switch (Thread.CurrentThread.Name) // Thread's tasks according to the threads name
            {
                case "Thread1":
                    Console.Write(" ");
                    
                    break;
                case "Thread2":
                    Console.Write("°");
                 
                    break;
                case "Thread3":
                    Console.Write("*");
                    break;
            }
            _mut.ReleaseMutex(); // Thread is leaving the Muttex -> Release of the Mutex
        }
    }
}