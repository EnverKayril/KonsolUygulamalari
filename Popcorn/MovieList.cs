using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class MovieList
    {
        public int sNumber { get; set; }
        public string movie { get; set; }
        public string director { get; set; }
        public string IMDb { get; set; }


        public static List<MovieList> GetMovies(string path)
        {
            List<MovieList> movieList = new List<MovieList>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string line = sr.ReadLine();
                    string[] movieInfo = line.Split('-');

                    MovieList movie = new MovieList()
                    {
                        sNumber = int.Parse(movieInfo[0]),
                        movie = movieInfo[1],
                        director = movieInfo[2],
                        IMDb = movieInfo[3],
                    };
                    movieList.Add(movie);
                }
            }
            return movieList;
        }
        public static void GetList(List<MovieList> movie)
        {
            Console.WriteLine($"{"S. No",5}  {"Movie",-50}{"Director",-35}{"IMDb",6}");
            foreach (var m in movie)
            {
                Console.WriteLine($"{m.sNumber,5}  {(m.movie).Trim(),-50}{(m.director).Trim(),-35}{m.IMDb,6}");
            }
        }

    }
}
