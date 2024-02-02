using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BookStore.Healthchecks
{
    public class CustomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> 
            CheckHealthAsync(
                HealthCheckContext context,
                CancellationToken cancellationToken 
                    = new CancellationToken())
        {
            try
            {
               return Task.FromResult(
                   HealthCheckResult.Healthy("OK"));
            }
            catch (Exception e)
            {
                return Task.FromResult(
                    HealthCheckResult.Unhealthy(e.Message));
            }
        }
    }
}
