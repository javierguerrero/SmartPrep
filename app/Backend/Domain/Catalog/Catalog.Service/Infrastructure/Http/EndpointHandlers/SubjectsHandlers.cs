using Catalog.Service.Application.Dtos;
using Catalog.Service.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Service.Infrastructure.Http.EndpointHandlers
{
    public class SubjectsHandlers
    {
        public static async Task<Results<BadRequest, Ok<List<SubjectDto>>>> GetSubjectsAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService
        )
        {
            var result = await _catalogApplicationService.GetSubjectsAsync();
            return TypedResults.Ok(result);
        }

        public static async Task<Results<BadRequest, Ok<SubjectDto>>> CreateSubjectAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService,
            [FromBody] SubjectForCreationDto subject
        )
        {
            if (subject == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _catalogApplicationService.CreateSubjectAsync(subject);
            return TypedResults.Ok(result);
        }


    }
}