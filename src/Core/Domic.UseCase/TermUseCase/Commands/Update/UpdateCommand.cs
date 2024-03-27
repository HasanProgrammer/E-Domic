using Domic.UseCase.TermUseCase.DTOs.GRPCs.Update;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Commons.Enumerations;

namespace Domic.UseCase.TermUseCase.Commands.Update;

public class UpdateCommand : ICommand<UpdateResponse>
{
    public required string TermId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required long Price { get; set; }
    public required Status? Status { get; set; }
}