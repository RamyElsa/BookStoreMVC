using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDataAccess.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        IGenreService Genre { get; }
        IAuthorService Author { get; }
        IBookService Book { get; }
        IPublisherService Publisher { get; }

        void Save();
    }
}
