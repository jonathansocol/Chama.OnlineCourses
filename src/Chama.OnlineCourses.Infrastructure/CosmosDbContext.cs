using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
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

        public CosmosDbContext(string databaseName, string collectionName, string endpointUrl, string authorizationKey)
        {
            _databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
            _collectionName = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
            _endpointUrl = endpointUrl ?? throw new ArgumentNullException(nameof(endpointUrl));
            _authorizationKey = authorizationKey ?? throw new ArgumentNullException(nameof(authorizationKey));
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
