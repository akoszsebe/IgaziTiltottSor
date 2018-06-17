using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        bool DoesItemExist(string useremail);
        IEnumerable<User> All { get; }
        User Find(string useremail);
        void Insert(User item);
        void Update(User item);
        void Delete(string useremail);
    }
}
