using BookStoreDataAccess.Data;
using BookStoreDataAccess.Repositories.Abstract;
using BookStoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDataAccess.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly DataBaseContext context;

        public AuthorService(DataBaseContext context)
        {
            this.context = context;
        }

        public bool Add(Author model)
        {
            try
            {
                context.Author.Add(model);
                context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var data = FindById(id);
                if (data != null)
                {
                    return false;
                }
                context.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }

        }

        public Author FindById(int id)
        {
            return context.Author.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return context.Author.ToList();
        }

        public bool Update(Author model)
        {
            try
            {
                context.Author.Update(model);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
