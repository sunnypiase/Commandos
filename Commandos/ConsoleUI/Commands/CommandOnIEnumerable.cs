using ConsoleUI.Menu.MenuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands
{
    internal class CommandOnIEnumerable<T, G> : CommandOn<IEnumerable<G>>
        where T : IEnumerable<G>
    {
        protected readonly CommandOn<G> command;
        protected readonly string title;

        public CommandOnIEnumerable(IEnumerable<G> _commandTarget, CommandOn<G> _command, string _title = "Select element") : base(_commandTarget)
        {
            command = _command;
            title = _title;
        }
        public override object Clone()
        {
            return new CommandOnIEnumerable<T, G>(commandTarget,command);
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            elements.Add(new InfoElement(title));
            int i = default;
            foreach (G item in commandTarget)
            {
                CommandOn<G> tmpAction = command.Clone() as CommandOn<G>;
                tmpAction.SerTarget(item);
                elements.Add(new SelectableElement($"{item}", $"{++i}", tmpAction));
            }
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }
    }
}
