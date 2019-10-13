using Chama.OnlineCourses.Infrastructure.Contexts;
using Chama.OnlineCourses.Infrastructure.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(functions_csharp_entityframeworkcore.Startup))]

namespace functions_csharp_entityframeworkcore
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("Sql:ConnectionString");

            builder.Services.AddDbContext<ReportingContext>(
                options => options.UseSqlServer(SqlConnection));
        }
    }
}