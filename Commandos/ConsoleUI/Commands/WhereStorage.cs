﻿using Commandos.Models.Products.General;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class WhereStorage<G> : ICommand
        where G : IProduct
    {
        private Predicate<((G Product, int Amount) element, string inputed)> predicate;
        private string title;
        private IInput input;
        IDrawer drawer;
        public WhereStorage(Predicate<((G Product, int Amount) element, string inputed)> _predicate, string _title, IInput _input, IDrawer _drawer)
        {
            predicate = _predicate;
            title = _title;
            drawer = _drawer;
            input = _input;
        }

        public ICollection<IMenuElement>? Execute(IUser? user = null)
        {
            string inputed = input.Read(title, drawer) ;
            var storage = ProductStorage<IProduct>.Instance;
            List<IMenuElement> elements = new();
            var products = storage.Where(x => x.Product is G && predicate((((G)x.Product, x.Amount), inputed)));
            foreach (var item in products)
            {
                elements.Add(new InfoElement($"{item}"));
            }
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
    }
}