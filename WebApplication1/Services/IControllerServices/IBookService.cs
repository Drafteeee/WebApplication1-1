using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;

namespace WebApplication1.Services.IControllerServices
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetOneBooks(int id);

        Task<List<Book>> AddBooks(BookDto request);

        Task<List<Book>?> DelBooks(int id);

    }
}
