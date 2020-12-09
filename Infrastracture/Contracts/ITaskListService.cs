using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Infrastracture.Contracts
{
    public interface ITaskListService : IBaseServices<TaskList>
    {
        void samp();

    }
}
