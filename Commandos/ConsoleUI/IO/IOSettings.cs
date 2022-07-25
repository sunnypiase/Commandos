using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.IO
{
    internal class IOSettings
    {
        private static IOSettings _instance;

        private IOSettings(IDrawer drawer, IInput input)
        {
            Drawer = drawer;
            Input = input;
        }

        public IDrawer Drawer { get; }
        public IInput Input { get; }

        public static IOSettings GetInstance(IDrawer drawer = null, IInput input = null)
        {
            if (_instance == null)
                _instance = new IOSettings(drawer, input);
            return _instance;
        }

    }
}
