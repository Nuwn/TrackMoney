using ConsoleGUI.Elements;

namespace ConsoleGUI
{

    public sealed class View
    {
        readonly List<Element> elements;
        public List<(string, Action?)> listedElements = new();
        int currentSelected = -1;

        public ConsoleInput Input { get; private set; }
        public Action<string?>? OnTextInput { get; private set; }


        public View(List<Element> elements, ConsoleInput input, Action<string?>? onTextInput = null)
        {
            this.elements = elements;
            Input = input;
            OnTextInput = onTextInput;
            SetupElements(elements);
            SetAction(true);
        }

        private void SetAction(bool positive)
        {
            bool done = false;
            var current = currentSelected;
            do
            {
                current = positive ?
                    (++current == listedElements.Count) ? 0 : current :
                    (--current < 0) ? listedElements.Count - 1 : current;

                if (listedElements[current].Item2 != null)
                    done = true;

            } while (!done);
            currentSelected = current;
            SetupElements(elements);
            UpdateSelected();
        }

        private void SetupElements(List<Element> elements)
        {
            listedElements.Clear();
            foreach (var item in elements)
            {
                listedElements.AddRange(item.Values);
            }
        }

        public void PrevSelected() => SetAction(false);
        public void NextSelected() => SetAction(true);
        public void CallAction() => listedElements[currentSelected].Item2?.Invoke();

        private void UpdateSelected() => 
            listedElements[currentSelected] = (">" + listedElements[currentSelected].Item1, listedElements[currentSelected].Item2);
    }
    
}