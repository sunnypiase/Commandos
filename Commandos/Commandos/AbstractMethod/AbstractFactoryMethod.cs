﻿using Commandos.Models.Products.General;
using System.Reflection;

namespace Commandos.AbstractMethod
{
    public abstract class AbstractFactoryMethod
    {
        protected string _name;
        protected double _price;
        protected double _weight;

        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }

        public AbstractFactoryMethod() : this("NaN", default, default) { }

        protected AbstractFactoryMethod(string name, double price, double weight)
        {
            _name = (name != null && name.Length > 0) ? name : "NaN";
            _price = (price > 0) ? price : 0;
            _weight = (weight > 0) ? weight : 0;
        }

        public abstract IProduct CreateProduct();

    }
}
