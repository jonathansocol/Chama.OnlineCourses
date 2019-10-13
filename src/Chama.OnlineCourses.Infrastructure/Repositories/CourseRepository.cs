using System;
using System.Net;
using System.Threading.Tasks;
using Chama.OnlineCourses.Domain.AggregateModels.Course;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace Chama.OnlineCourses.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ICosmosDbContext _context;

        public CourseRepository(ICosmosDbContext context)
        {
            _context = context;
        }

        public async Task<Course> FindById(Guid id)
        {
            var client = _context.GetClient();
            var uri = _context.GetDocumentUri(id.ToString());
            var requestOptions = new RequestOptions { PartitionKey = new PartitionKey("online-courses") };

            try
            {
                var response = await client.ReadDocumentAsync(uri, requestOptions);
                return JsonConvert.DeserializeObject<Course>(response.Resource.ToString());
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task Upsert(Course course)
        {
            var client = _context.GetClient();
            var uri = _context.GetDocumentCollectionUri();

            await client.UpsertDocumentAsync(uri, course);
        }
    }
}
