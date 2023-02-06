using BookStoreDataAccess.Data;
using BookStoreDataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDataAccess.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataBaseContext _context;

        public IGenreService Genre { get; private set; }
        public IPublisherService Publisher { get; private set; }
        public IBookService Book { get; private set; }
        public IAuthorService Author { get; private set; }

        public UnitOfWork(DataBaseContext context )
        {
            _context = context;
            Genre = new GenreService(context);
            Publisher = new PublisherService(context);
            Book = new BookService(context);
            Author = new AuthorService(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
