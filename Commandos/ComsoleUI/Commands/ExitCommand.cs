using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands
{
    internal class ExitCommand
    {
        private AuthorizationService userService;

        public void Execute(IDrawer drawer)
        {
            userService.ExitProgram(drawer);
        }
    }
}
}
