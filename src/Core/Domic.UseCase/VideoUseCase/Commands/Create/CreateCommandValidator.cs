﻿using Domic.Core.Common.ClassExtensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.VideoUseCase.Commands.Create;

public class CreateCommandValidator : IValidator<CreateCommand>
{
    public Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        if (input.Video is null || input.Video.Length == 0)
            throw new UseCaseException("فیلد فیلم آموزشی الزامی می باشد !");
        
        if (!input.Video.IsVideo())
            throw new UseCaseException("فرمت فیلم آموزشی صحیح نمی باشد !");

        return Task.FromResult(default(object));
    }
}