using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Infrastracture.Persistence;
using Domain.Contracts;
using Domain.Models;

namespace Infrastracture.Repositories
{
    public class ItemRepo : IItem
    {
        private IDatabaseContext _dbcontext;

        public ItemRepo(IDatabaseContext context) => _dbcontext = context;

        public void Create(Item entity)
        {
            _dbcontext.Items.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<Item> FindAll()
        {
            return _dbcontext.Items.OrderByDescending(i => i.Id).ToList();
        }

        public IEnumerable<Item> FindByFK(int id)
        {
            return _dbcontext.Items.OrderByDescending(i => i.Id).Where(d => d.IdTask.Equals(id)).ToList();
        }

        public Item FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Item entity)
        {
            _dbcontext.Items.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(Item entity)
        {
            _dbcontext.Items.Update(entity);
            _dbcontext.Save();
        }
    }
}
