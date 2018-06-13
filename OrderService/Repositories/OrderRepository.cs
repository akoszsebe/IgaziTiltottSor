using System.Collections.Generic;
using DotNetCore.Models;

namespace DotNetCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orderList;

        public OrderRepository()
        {
            InitializeData();
        }

        public IEnumerable<Order> All
        {
            get { return _orderList; }
        }

        public bool DoesItemExist(int id)
        {
            return _orderList.Exists(item => item.orderid == id);
        }

        public Order Find(int id)
        {
            return _orderList.Find(item => item.orderid == id);
        }

        public IEnumerable<Order> FindByEmail(string useremail)
        {
            return _orderList.FindAll(item => item.useremail == useremail);
        }

        public void Insert(Order item)
        {
            _orderList.Add(item);
        }

        public void Update(Order item)
        {
            var tmpItem = this.Find(item.orderid);
            var index = _orderList.IndexOf(tmpItem);
            _orderList.RemoveAt(index);
            _orderList.Insert(index, item);
        }

        public void Delete(int id)
        {
            _orderList.Remove(this.Find(id));
        }

        private void InitializeData()
        {
            _orderList = new List<Order>();

            var item1 = new Order
            {
                ordername = "Mezes",
                useremail = "zsebea@yahoo.com",
                address = "memo nr 2",
                beernumber = 12,
                orderdate = System.DateTime.Now.Date.ToString(),
                price = 36,
                orderid = 3541, 
                delivered = "DRONE"
            };

            var item2 = new Order
            {
                ordername = "Tiltott",
                useremail = "zsebea@yahoo.com",
                address = "memo nr 2",
                beernumber = 12,
                orderdate = System.DateTime.Now.ToString(), 
                price = 36,
                orderid = 3432, 
                delivered = "HOME"
            };

            _orderList.Add(item1);
            _orderList.Add(item2);
        }
    }
}