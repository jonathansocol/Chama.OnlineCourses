using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Infrastructure
{
    public class CosmosDbContext : ICosmosDbContext
    {
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly string _endpointUrl;
        private readonly string _authorizationKey;

        public CosmosDbContext(IConfiguration configuration)
        {
            _databaseName = configuration.GetSection("CosmosDb:DatabaseName").Value ??
                throw new ArgumentNullException(nameof(_databaseName));
            _collectionName = configuration.GetSection("CosmosDb:CollectionName").Value ?? 
                throw new ArgumentNullException(nameof(_collectionName));
            _endpointUrl = configuration.GetSection("CosmosDb:EndpointUrl").Value ??
                throw new ArgumentNullException(nameof(_endpointUrl));
            _authorizationKey = configuration.GetSection("CosmosDb:AuthorizationKey").Value ??
                throw new ArgumentNullException(nameof(_authorizationKey));
        }

        public IDocumentClient GetClient()
        {
            return new DocumentClient(new Uri(_endpointUrl), _authorizationKey);
        }

        public Uri GetDocumentUri(string documentId)
        {
            return UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId);
        }
    }
}
