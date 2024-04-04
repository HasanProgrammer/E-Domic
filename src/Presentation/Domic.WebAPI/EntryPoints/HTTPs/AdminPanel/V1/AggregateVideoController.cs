﻿using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.WebAPI.Filters;
using Domic.UseCase.AggregateVideoUseCase.DTOs.GRPCs.ReadAllPaginated;
using Domic.UseCase.AggregateVideoUseCase.Queries.ReadAllPaginated;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Route = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.AdminPanel.V1;

[ApiVersion("1.0")]
[Authorize(Roles = "SuperAdmin,Admin,Author")]
[BlackListPolicy]
public class AggregateVideoController(IMediator mediator) : BaseAggregateVideoController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(Route.ReadAllPaginatedAggregateVideoUrl)]
    [PermissionPolicy(Type = "AggregateVideoReadAllPaginated")]
    public async Task<IActionResult> ReadAllPaginated([FromQuery] ReadAllPaginatedQuery query,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<ReadAllPaginatedResponse>(query, cancellationToken);

        return new JsonResult(result);
    }
}