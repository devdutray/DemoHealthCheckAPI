using DemoHealthcheckAPI.Models;

namespace DemoHealthcheckAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly List<Movie> _movies;

        public MovieService()
        {
            _movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    ReleaseYear = 1994,
                    Genre = "Drama",
                    Description = "Two imprisoned"
                },
                new Movie
                {
                    Id = 2, 
                    Title = "The Godfather", 
                    Director = "Francis Ford Coppola", 
                    ReleaseYear = 1972, 
                    Genre = "Crime, Drama", 
                    Description = "The aging patriarch of an organized crime dynasty..."
                }
            };
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await Task.FromResult(_movies);
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await Task.FromResult(_movies.FirstOrDefault(m => m.Id == id));
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            _movies.Add(movie);
            await Task.CompletedTask;
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Director = movie.Director;
                existingMovie.ReleaseYear = movie.ReleaseYear;
                existingMovie.Genre = movie.Genre;
                existingMovie.Description = movie.Description;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movieToRemove = _movies.FirstOrDefault(m => m.Id == id);
            if (movieToRemove != null)
            {
                _movies.Remove(movieToRemove);
            }
            await Task.CompletedTask;
        }
    }
}
