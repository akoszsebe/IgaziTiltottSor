using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore.Models
{
    public class Order
    {
        public string ordername { get; set; }

        public string useremail { get;set; }

        public string address { get; set; }

        public int beernumber { get; set; }

        public string orderdate { get; set; }

        public int price { get; set; }

        public int orderid { get; set; }

        public string delivered { get; set; }
    }
}