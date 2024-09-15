﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public Product() { }
        public Product(int id, string title, int price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }
    }
}
