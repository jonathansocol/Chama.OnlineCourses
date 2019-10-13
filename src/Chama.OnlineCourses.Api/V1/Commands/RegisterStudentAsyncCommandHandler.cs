using AutoMapper;
using Chama.OnlineCourses.Infrastructure.Providers;
using Chama.OnlineCourses.IntegrationEvents;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.V1.Commands
{
    public class RegisterStudentCommandAsyncHandler : IRequestHandler<RegisterStudentAsyncCommand, Unit>
    {
        private readonly IServiceBusPublisher _serviceBusPublisher;
        private readonly IMapper _mapper;

        public RegisterStudentCommandAsyncHandler(IServiceBusPublisher serviceBusPublisher, IMapper mapper)
        {
            _serviceBusPublisher = serviceBusPublisher ?? throw new ArgumentNullException(nameof(serviceBusPublisher));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(RegisterStudentAsyncCommand request, CancellationToken cancellationToken)
        {
            var integrationEvent = _mapper.Map<RegisterStudentIntegrationCommand>(request);

            await _serviceBusPublisher.SendMessage(integrationEvent);

            return Unit.Value;
        }
    }
}
