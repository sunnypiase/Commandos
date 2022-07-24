using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Commandos.CommandosLogic.Services
// (this does not work, ConsoleUI does not see the Commandos)

namespace ConsoleUI.Commands
{
    internal class AuthorizationCommand
    {
        private AuthorizationService userService;

        public void Execute(IDrawer drawer)
        {
            userService.LoginRoutine(drawer);
        }
    }
}
