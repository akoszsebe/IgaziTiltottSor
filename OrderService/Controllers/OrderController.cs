using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCore.Models;
using DotNetCore.Repositories;

namespace DotNetCore.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderRepository.All;
        }

        // GET api/orders/id
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderRepository.Find(id);
        }

        // GET api/orders
        [HttpGet("byuser")]
        public IEnumerable<Order> Get([FromHeader] String useremail)
        {
            return _orderRepository.FindByEmail(useremail);
        }

        [HttpGet("exeption")]
        public void GetExeption()
        {
            Environment.Exit(0);
        }

        [HttpPost]
        public bool Post([FromBody]Order order)
        {
            Random rnd = new Random();
            //int id = rnd.Next(1000, 5000);
             Console.WriteLine("Beszur ujj elem "+order.useremail);
             _orderRepository.Insert(new Order{
                 ordername = order.ordername,
                useremail = order.useremail,
                address = order.address,
                beernumber = order.beernumber,
                orderdate = order.orderdate,
                price = order.price,
                orderid = order.orderid, 
                delivered = "DEPOSIT"
             });
             return true;
        }

        [HttpPost("ondrone/{id}")]
        public void OnDrone(int id)
        {
            Console.WriteLine("id itt "+id);
            _orderRepository.Find(id).delivered = "DRONE";
        }

        [HttpPost("delivered/{id}")]
        public void Delivered(int id)
        {
            Console.WriteLine("id itt "+id);
            _orderRepository.Find(id).delivered = "HOME";
        }
    }
}