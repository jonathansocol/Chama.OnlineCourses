using Chama.OnlineCourses.Domain.AggregateModels.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Infrastructure.Providers
{
    public interface IServiceBusPublisher
    {
        Task SendMessage(object message);
    }
}
