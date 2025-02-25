#pragma warning disable CS4014

using Domic.Core.UseCase.Attributes;
using Domic.UseCase.TicketUseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs.GRPCs.Create;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommandHandler(ITicketRpcWebRequest ticketRpcWebRequest) 
    : ICommandHandler<CreateCommand, CreateResponse>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;

    [WithValidation]
    public Task<CreateResponse> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => ticketRpcWebRequest.CreateAsync(command, cancellationToken);

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken) => Task.CompletedTask;
}