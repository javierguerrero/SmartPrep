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

        public static async Task<Results<BadRequest, Ok<SubjectDto>>> GetSubjectBySubjectIdAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService,
            Guid subjectId
        )
        {
            var result = await _catalogApplicationService.GetSubjectBySubjectIdAsync(subjectId);
            return TypedResults.Ok(result);
        }

        public static async Task<Results<NotFound, NoContent>> DeleteSubjectAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService,
            Guid subjectId
        )
        {
            var result = await _catalogApplicationService.DeleteSubjectAsync(subjectId);

            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.NoContent();
        }

        public static async Task<Results<BadRequest, NotFound, NoContent, Ok<SubjectDto>>> UpdateSubjectAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService,
            [FromBody] SubjectForUpdateDto subject,
            Guid subjectId
        )
        {
            if (subject == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _catalogApplicationService.UpdateSubjectAsync(subjectId, subject);

            if (result.Success && result.SubjectUpserted != null)
            {
                return TypedResults.Ok(result.SubjectUpserted);
            }

            return TypedResults.NoContent();
        }

    }
}