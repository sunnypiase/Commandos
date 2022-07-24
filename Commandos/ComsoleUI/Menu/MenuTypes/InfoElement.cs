namespace ConsoleUI.Menu.MenuTypes
{
    public class InfoElement : IMenuElement
    {
        public string Title { get; }
        public DrawPriority Priority { get; }

        public InfoElement(string title,
            DrawPriority priority = DrawPriority.First)
        {
            Title = title;
            Priority = priority;
        }
    }
}
