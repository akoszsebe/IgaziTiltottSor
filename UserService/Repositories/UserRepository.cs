using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _userList;

        public UserRepository()
        {
            InitializeData();
        }
        public IEnumerable<User> All
        {
            get { return _userList; }
        }

        public bool DoesItemExist(string useremail)
        {
            return _userList.Exists(item => item.useremail == useremail);
        }

        public User Find(string useremail)
        {
            return _userList.Find(item => item.useremail == useremail);
        }


        public void Insert(User item)
        {
            _userList.Add(item);
        }

        public void Update(User item)
        {
            var tmpItem = this.Find(item.useremail);
            var index = _userList.IndexOf(tmpItem);
            _userList.RemoveAt(index);
            _userList.Insert(index, item);
        }

        public void Delete(string useremail)
        {
            _userList.Remove(this.Find(useremail));
        }
        private void InitializeData()
        {
            _userList = new List<User>();

            var item1 = new User
            {
                useremail = "zsebea@yahoo.com",
                address = "Strada Ploiești 27, Cluj-Napoca 400000",
                phone = "0757159681",
                cardnumber = "1234567891011121",
                cardexpiration = "10/20",
                cvv = "123"
            };

            _userList.Add(item1);
        }
    }
}
