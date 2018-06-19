using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;
using UserService.Repositories;

namespace UserService.Controllers
{
    [Route("api/users")]
    public class UserController: Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.All;
        }

        // GET api/orders
        [HttpGet("one")]
        public User Get([FromHeader] String useremail)
        {
            return _userRepository.Find(useremail);
        }

        [HttpPost]
        public bool Post([FromBody]User user)
        {
            Console.WriteLine("Beszur ujj elem " + user.useremail);
            if (!_userRepository.DoesItemExist(user.useremail))
            {
                _userRepository.Insert(new User
                {
                    useremail = user.useremail,
                    address = user.address,
                    phone = user.phone,
                    cardnumber = user.cardnumber,
                    cardexpiration = user.cardexpiration,
                    cvv = user.cvv
                });
            }
            else
            {
                _userRepository.Update(user);
            }
            return true;
        }
    }
}
