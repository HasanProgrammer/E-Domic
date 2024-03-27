using Domic.UseCase.TermUseCase.Contracts.Interfaces;
using Domic.UseCase.TermUseCase.DTOs.GRPCs.InActive;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TermUseCase.Commands.InActive;

public class InActiveCommandHandler(ITermRpcWebRequest termRpcWebRequest) 
    : ICommandHandler<InActiveCommand, InActiveResponse>
{
    public Task<InActiveResponse> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => termRpcWebRequest.InActiveAsync(command, cancellationToken);
}