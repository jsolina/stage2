using Domain.Contracts;
using Domain.Models;
using Infrastracture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastracture.Repositories
{
    public class ItemRepo : IItem
    {
        private IDatabaseContext _dbcontext;
        public ItemRepo(IDatabaseContext context) => _dbcontext = context;

        public void Create(ItemModel entity)
        {
            _dbcontext.Items.Add(entity);
            _dbcontext.Save();
        }

        public IEnumerable<ItemModel> FindAll()
        {
            return _dbcontext.Items.OrderByDescending(i => i.Id).ToList();
        }

        public IEnumerable<ItemModel> FindByFK(object id)
        {
            return _dbcontext.Items.OrderByDescending(i => i.Id).Where(d => d.IdTask.Equals(id)).ToList();
        }

        public ItemModel FindById(object id)
        {
            return _dbcontext.Items.Where(d => d.Id.Equals(id)).FirstOrDefault();
        }

        public void Remove(ItemModel entity)
        {
            _dbcontext.Items.Remove(entity);
            _dbcontext.Save();
        }

        public void Update(ItemModel entity)
        {
            _dbcontext.Items.Update(entity);
            _dbcontext.Save();
        }
    }
}
