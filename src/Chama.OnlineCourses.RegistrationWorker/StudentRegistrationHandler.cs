using Chama.OnlineCourses.Domain.AggregateModels.Course;
using Chama.OnlineCourses.Infrastructure;
using Chama.OnlineCourses.Infrastructure.Repositories;
using Chama.OnlineCourses.IntegrationEvents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.RegistrationWorker
{
    public static class StudentRegistrationHandler
    {
        [FunctionName("StudentRegistrationHandler")]
        public static async Task Run([ServiceBusTrigger("register-student", Connection = "ASBConnectionString")]string message, ILogger log)
        {
            var command = JsonConvert.DeserializeObject<RegisterStudentIntegrationCommand>(message);

            var repository = GetCosmosDbRepository();

            var course = await repository.FindById(command.CourseId);

            if (course == null)
            {
                log.LogError($"Course with the Id '{command.CourseId}' could not be found.");
            }

            var student = MapStudent(command);

            try
            {
                course.AddStudent(student);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }

            await repository.Upsert(course);

            log.LogInformation($"User registered.");
        }

        private static Student MapStudent(RegisterStudentIntegrationCommand command)
        {
            return new Student
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Age = command.Age
            };
        }

        private static CourseRepository GetCosmosDbRepository()
        {
            var databaseName = Environment.GetEnvironmentVariable("CosmosDb:DatabaseName");
            var collectionName = Environment.GetEnvironmentVariable("CosmosDb:CollectionName");
            var endpointUrl = Environment.GetEnvironmentVariable("CosmosDb:EndpointUrl");
            var authorizationKey = Environment.GetEnvironmentVariable("CosmosDb:AuthorizationKey");

            return new CourseRepository(new CosmosDbContext(databaseName, collectionName, endpointUrl, authorizationKey));
        }
    }
}
