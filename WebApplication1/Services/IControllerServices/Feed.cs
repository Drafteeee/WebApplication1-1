using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services.IControllerServices
{
    public class Feed:IFeed
    {
        private readonly DataContext _context;

        public Feed(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Feedback>> AddFeed(Feedback feedback)
        {

            _context.feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return await _context.feedbacks.ToListAsync();
        }

        
    }
}
