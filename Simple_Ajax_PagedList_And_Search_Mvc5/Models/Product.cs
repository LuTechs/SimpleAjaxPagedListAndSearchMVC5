using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public float  Price { get; set; }
        public int Qty { get; set; }
    }
}