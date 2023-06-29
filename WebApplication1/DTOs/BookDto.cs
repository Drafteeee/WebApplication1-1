namespace WebApplication1.DTOs
{
    public record struct BookDto(string Name, List<AuthorDto> Authors , List<GanreDto> Ganres, List<FeedbackDto> Feedback); 
}
