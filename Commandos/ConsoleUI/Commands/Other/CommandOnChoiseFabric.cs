using Commandos.AbstractMethod;
using ConsoleUI.Menu.MenuTypes;
using System.Reflection;

namespace ConsoleUI.Commands
{
    internal class CommandOnChoiseFabric<T> : CommandOn<T>
    {
        protected readonly CommandOn<T> command;
        protected readonly string title;

        public CommandOnChoiseFabric(CommandOn<T> _command, string _title = "Select element")
        {
            command = _command;
            title = _title;
        }

        public override object Clone()
        {
            return new CommandOnChoiseFabric<T>(command);
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();

            elements.Add(new InfoElement(title));

            IEnumerable<Type>? typeList = GetTypeFactories();
            int i = default;

            foreach (Type? type in typeList)
            {
                CommandOn<T> tmpChoiseType = command.Clone() as CommandOn<T>;
                tmpChoiseType.SetTargetType(type); ;
                elements.Add(new SelectableElement($"{type.Name.Replace("Factory", "")}", $"{++i}", tmpChoiseType));
            }

            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }

        protected IEnumerable<Type> GetTypeFactories()
        {
            Type? typeList = typeof(AbstractFactoryMethod);
            return Assembly.GetAssembly(typeList).GetTypes().Where(type => type.IsSubclassOf(typeList));
        }

    }
}
