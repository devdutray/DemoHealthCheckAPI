using DemoHealthcheckAPI.Models;

namespace DemoHealthcheckAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);

    }
}
