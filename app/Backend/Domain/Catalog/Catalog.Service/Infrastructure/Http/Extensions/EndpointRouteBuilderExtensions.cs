using Catalog.Service.Infrastructure.Http.EndpointHandlers;

namespace Catalog.Service.Infrastructure.Http.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterSongsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var songsEndpoints = endpointRouteBuilder
                .MapGroup("api/songs")
                .WithTags("Songs");

            songsEndpoints.MapGet("", SongsHandlers.GetSongsAsync)
                .WithName("GetSongs")
                .WithOpenApi();

            songsEndpoints.MapGet("/{songId:guid}", SongsHandlers.GetSongBySongIdAsync)
                .WithName("GetSong")
                .WithOpenApi();

            songsEndpoints.MapPost("", SongsHandlers.CreateSongAsync)
                .WithName("CreateSong")
                .WithOpenApi();

            songsEndpoints.MapDelete("/{songId:guid}", SongsHandlers.DeleteSongAsync)
                .WithName("DeleteSong")
                .WithOpenApi();

            songsEndpoints.MapPut("/{songId:guid}", SongsHandlers.UpdateSongAsync)
                .WithName("UpdateSong")
                .WithOpenApi();
        }

        public static void RegisterSubjectsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var subjectsEndpoints = endpointRouteBuilder
                .MapGroup("api/subjects")
                .WithTags("Subjects");

            subjectsEndpoints.MapGet("", SubjectsHandlers.GetSubjectsAsync)
                .WithName("GetSubjects")
                .WithOpenApi();

            subjectsEndpoints.MapPost("", SubjectsHandlers.CreateSubjectAsync)
                .WithName("CreateSubject")
                .WithOpenApi();

            subjectsEndpoints.MapGet("/{subjectId:guid}", SubjectsHandlers.GetSubjectBySubjectIdAsync)
                .WithName("GetSubject")
                .WithOpenApi();

            subjectsEndpoints.MapDelete("/{subjectId:guid}", SubjectsHandlers.DeleteSubjectAsync)
                .WithName("DeleteSubject")
                .WithOpenApi();

            subjectsEndpoints.MapPut("/{subjectId:guid}", SubjectsHandlers.UpdateSubjectAsync)
                .WithName("UpdateSubject")
                .WithOpenApi();
        }

        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterSongsEndpoints();
            app.RegisterSubjectsEndpoints();
        }
    }
}