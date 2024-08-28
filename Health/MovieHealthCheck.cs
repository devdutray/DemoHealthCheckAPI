using DemoHealthcheckAPI.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DemoHealthcheckAPI.Health
{
    public class MovieHealthCheck : IHealthCheck
    {
        private readonly IMovieService _movieService;

        public MovieHealthCheck(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _movieService.GetAllMoviesAsync();
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(exception: ex);
            }
        }
    }
}
