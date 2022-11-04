namespace ConsoleGUI.Elements
{
    public class Select: Element
    {
        public Select(List<(string, Action?)> options)
        {
            Values = options;
        }
    }
}
