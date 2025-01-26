using Catalog.Service.Application.Dtos;

namespace Catalog.Service.Infrastructure.Http.Results
{
    public class UpdateSubjectResult
    {
        public SubjectDto SubjectUpserted { get; set; }
        public bool Success { get; set; }
    }
}
