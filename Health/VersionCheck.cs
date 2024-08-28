using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Diagnostics;
using System.Reflection;

namespace DemoHealthcheckAPI.Health
{
    internal class VersionCheck : IHealthCheck
    {
        //private readonly string _executablePath;

        public VersionCheck()
        {
            //_executablePath = executablePath;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return (await Task.FromResult(HealthCheckResult.Healthy(
                "Version successfully fetched",
                new Dictionary<string, object> { ["version"] = version })));
        }
    }
}
