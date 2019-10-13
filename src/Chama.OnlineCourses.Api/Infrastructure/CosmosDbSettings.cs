namespace Chama.OnlineCourses.Api.Infrastructure
{
    public class CosmosDbSettings 
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string EndpointUrl { get; set; }
        public string AuthorizationKey { get; set; }
    }
}
