using ConsoleUI.Menu.MenuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands
{
    public abstract class CommandOn<T> : CommandBase, ICloneable
    {
        protected T? commandTarget;
        public CommandOn()
        { }
        public CommandOn(T _commandTarget)
        {
            commandTarget = _commandTarget;
        }
        public void SetTarget(T _commandTarget)
        {
            commandTarget = _commandTarget;
        }

        public abstract object Clone();
        public override abstract ICollection<IMenuElement>? Execute();
    }
}
