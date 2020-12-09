using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Contracts
{
    public interface IItem : IBaseRepo<Item>
    {
        public IEnumerable<Item> FindByFK(int id);
    }
}
