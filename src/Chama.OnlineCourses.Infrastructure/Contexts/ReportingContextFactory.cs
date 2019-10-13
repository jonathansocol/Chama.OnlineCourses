using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Chama.OnlineCourses.Infrastructure.Contexts
{
    public class ReportingContextFactory : IDesignTimeDbContextFactory<ReportingContext>
    {
        public ReportingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReportingContext>();

            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("Sql:ConnectionString"));

            return new ReportingContext(optionsBuilder.Options);
        }
    }
}
