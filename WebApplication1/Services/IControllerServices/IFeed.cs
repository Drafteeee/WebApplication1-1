using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services.IControllerServices
{
    public interface IFeed
    {

        Task<List<Feedback>> AddFeed(Feedback feedback);
    }
}
