namespace LEXTRAIT_Hugo_TP3_ST2TRD;

public class Run
{
    public static void Main()
    {
        //---------------
        //  Exercice 1
        //---------------
        Queries queries = new Queries();
        queries.run_queries();   
            
            
        //---------------
        //  Exercice 2
        //---------------
        ThreadManager threads = new ThreadManager();
        threads.run_threads();
    }
}