﻿using Karami.Core.Common.ClassExtensions;
using Karami.Core.Domain.Exceptions;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Core.UseCase.Exceptions;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.ArticleUseCase.Commands.Update;

public class CreateCommandValidator : IValidator<UpdateCommand>
{
    private readonly ICategoryRpcWebRequest _categoryRpcWebRequest;

    public CreateCommandValidator(ICategoryRpcWebRequest categoryRpcWebRequest) 
        => _categoryRpcWebRequest = categoryRpcWebRequest;

    public async Task<object> ValidateAsync(UpdateCommand input, CancellationToken cancellationToken)
    {
        if (input.Image is not null)
        {
            if (input.Image is null || input.Image.Length == 0)
                throw new UseCaseException("فیلد تصویر شاخص مقاله الزامی می باشد !");
        
            if (!input.Image.IsImage())
                throw new UseCaseException("فرمت تصویر شاخص مقاله صحیح نمی باشد !");
        }

        var taskCategory = _categoryRpcWebRequest.CheckExistAsync(input.CategoryId, cancellationToken);

        if (await taskCategory is false)
            throw new DomainException(
                string.Format("دسته بندی با شناسه {0} وجود خارجی ندارد !", input.CategoryId)
            );

        return default;
    }
}