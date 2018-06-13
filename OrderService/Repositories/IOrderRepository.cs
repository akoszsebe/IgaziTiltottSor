using System.Collections.Generic;
using DotNetCore.Models;

namespace DotNetCore.Repositories
{
    public interface IOrderRepository
    {
        bool DoesItemExist(int id);
        IEnumerable<Order> All { get; }
        Order Find(int id);
        IEnumerable<Order> FindByEmail(string useremail);
        void Insert(Order item);
        void Update(Order item);
        void Delete(int id);
    }
}