using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrdersRepository:IRepository<Order>
    {
        IList<Order> FindAll(Func<Order, bool> condition);
    }
}
