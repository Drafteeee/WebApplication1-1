using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;

namespace WebApplication1.Services.IControllerServices
{
    public interface IFeedServices
    {
        Task<List<Feedback>?> AddFeedBack(BookDto request, int id);
        Task<Book?> GetFeedBack(int id);

        Task<List<Feedback>?> DeleteFeedBack(int id);
    }
}
