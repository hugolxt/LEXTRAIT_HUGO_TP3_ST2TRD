namespace LEXTRAIT_Hugo_TP3_ST2TRD
{
    public class Queries
    {
        public void run_queries()
        {
            //  ------------------------------------------------------------------------------------------------------------
            //  Exercice 1 : Create some queries using LINQ
            var movieList = new MovieCollection();      
            Console.WriteLine("----------------------------------------------\n");
            Console.WriteLine("Exercice 1 : Create some queries using LINQ\n");

            // Query number 1
            Console.WriteLine("* Query number 1 :");
            var old = (from movie in movieList.Movies
                                orderby movie.ReleaseDate ascending
                                select movie).First();

            Console.WriteLine("Display the title of the oldest movie : " + old.Title);

            // Query number  2
            Console.WriteLine("\nQuery number 2 :");
            var total = (from movie in movieList.Movies
                                select movie).Count();

            Console.WriteLine("Count all movies : " + total);


            // Query number  3 
            Console.WriteLine("\n* Query number 3 :");
            var moviesWithE = (from movie in movieList.Movies
                            where movie.Title.Contains("e")
                            select movie).Count();

            Console.WriteLine("Count all movies with the letter e. at least once in the title : " + moviesWithE);


            // Query number 4
            Console.WriteLine("\n* Query number 4 :");
            var fNumber = (from movie in movieList.Movies

                select movie.Title.Count(m => m == 'f')).Sum() ;

 

            Console.WriteLine("Count how many time the letter f is in all the titles from this list : " + fNumber);

            // Query number 5
            Console.WriteLine("\n* Query number 5 :");
            var higherBudget = (from movie in movieList.Movies
                                 where movie.Budget != null
                                 orderby movie.Budget descending
                                 select movie).First();

            Console.WriteLine("Display the title of the film with the higher budget :" + higherBudget.Title);


            // Query number 6
            Console.WriteLine("\n* Query number 6 :");
            var lowestBox = (from movie in movieList.Movies
                              where movie.BoxOffice != null
                              orderby movie.BoxOffice ascending
                              select movie).First();

            Console.WriteLine("Display the title of the movie with the lowest box office : " + lowestBox.Title);

            // Query number 7
            Console.WriteLine("\n* Query number 7 :");
            var reverseAlpha = (from movie in movieList.Movies
                                         orderby movie.Title descending
                                         select movie).Take(10);

            Console.WriteLine("Order the movies by reversed alphabetical order and print the first 11 of the list :\n");
            foreach (var movie in reverseAlpha)
            {
                Console.WriteLine(movie.Title);
            }

            // Query number 8
            Console.WriteLine("\n* Query number 8 :");
            var beforeDate = (from movie in movieList.Movies

                where movie.ReleaseDate < new DateTime(1980,01,01)
                select movie).Count();
            
            Console.WriteLine("Count all the movies made before 1980 : " + beforeDate);
            
            // Query number 9 
            Console.WriteLine("\n* Query number 9 :");
            char[] vowels = new[] { 'a','e','i','o','u','y','A','E','I','O','U','Y' };
            
            var averageRunningStartA = (from movie in movieList.Movies
                                   where vowels.Contains(movie.Title[0])
                                   select movie.RunningTime).Average(); 

            Console.WriteLine("Display the average running time of movies having a vowel as the first letter : " + averageRunningStartA);

            // Query number 10 
            Console.WriteLine("\n* Query number 10 :");
            var hwTitle = (from movie in movieList.Movies
                            where ((movie.Title.ToLower().Contains('i') == false || movie.Title.ToLower().Contains('t') == false ) && (movie.Title.ToLower().Contains('h') || movie.Title.ToLower().Contains('w')))
                            select movie);

            Console.WriteLine("Print all movies with the letter H or W in the title, but not the letter I or T :\n");

            foreach (var movie in hwTitle)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}