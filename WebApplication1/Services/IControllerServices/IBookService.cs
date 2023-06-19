using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services.IControllerServices
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetOneBooks(int id);

        Task<List<Book>>AddBooks(Book book);

        Task<List<Book>?> DelBooks(int id);

    }
}
