using ConsoleGUI;
using ConsoleGUI.Elements;

namespace TrackMoney
{
    internal class TrackMoneyApp
    {
        public int GetSaldo { get; }

        private readonly View startView;

        public TrackMoneyApp()
        {
            startView = SetupStartView();


            GUI.Display(startView);
        }

        View SetupStartView()
        {
            return new View(new List<Element>()
            {
                new Paragraph("Welcome to TrackMoney!"),
                new Paragraph($"You have currently {GetSaldo};- on your account"),
                new Select(new()
                {
                    ("Test", () => {

                    }),
                    ("Exit", () => {

                    })
                })
            },
            ConsoleInput.NAVIGATION);
        }
        
    }
}
