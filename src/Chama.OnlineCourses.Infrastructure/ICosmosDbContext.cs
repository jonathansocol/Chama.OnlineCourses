using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace Chama.OnlineCourses.Infrastructure
{
    public interface ICosmosDbContext
    {
        IDocumentClient GetClient();
        Uri GetDocumentUri(string documentId);
        Uri GetDocumentCollectionUri();
    }
}