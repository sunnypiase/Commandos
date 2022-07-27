using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public abstract class CommandOn<T> : CommandBase, ICloneable
    {
        protected T? commandTarget;
        protected Type? commandType;

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

        public void SetTargetType(Type type)
        {
            commandType = type;
        }

        public abstract object Clone();
        public abstract override ICollection<IMenuElement>? Execute();


    }
}
