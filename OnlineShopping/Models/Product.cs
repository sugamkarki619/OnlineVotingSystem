﻿namespace OnlineShopping.Models
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }

        public int Categoryid { get; set; }

    }
}
