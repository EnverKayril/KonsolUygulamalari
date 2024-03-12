namespace Popcorn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\oscar\OneDrive\Masaüstü\Popcorn\MovieList.txt";
            List<MovieList> movies = MovieList.GetMovies(path);
            MovieList.GetList(movies);

            Console.WriteLine();



        }
    }
}
