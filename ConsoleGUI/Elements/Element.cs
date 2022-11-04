namespace ConsoleGUI.Elements
{
    public class Element
    {
        public List<(string, Action?)> Values { get; protected set; } = new();
    }
}