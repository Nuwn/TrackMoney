namespace ConsoleGUI
{
    public static class GUI
    {
        public static void Display(View view)
        {
            Console.Clear();
            foreach (var item in view.listedElements)
            {
                Console.WriteLine(item.Item1);
            }

            switch (view.Input)
            {
                case ConsoleInput.NAVIGATION:
                    ConsoleKeyInfo navKey = Console.ReadKey();

                    if (navKey.Key == ConsoleKey.UpArrow)
                    {
                        view.PrevSelected();
                        Display(view);
                    }
                    else if(navKey.Key == ConsoleKey.DownArrow)
                    {
                        view.NextSelected();
                        Display(view);
                    }
                    else if (navKey.Key == ConsoleKey.Enter)
                    {
                        view.CallAction();
                    }
                    break;
                case ConsoleInput.TEXT:
                    view.OnTextInput?.Invoke(Console.ReadLine());

                    break;
                case ConsoleInput.KEY:
                    Console.WriteLine("\nPress any key to continue...");
                    ConsoleKeyInfo key = Console.ReadKey();
                    break;
            }
        }
    }
}