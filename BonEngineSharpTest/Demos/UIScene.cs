using System;
using BonEngineSharp.Defs;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;
using BonEngineSharp.UI;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Show built-in UI system.
    /// </summary>
    class UIScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;

        // ui root
        UIElement _uiroot;

        // checkbox to show debug draw
        UICheckBox _debugDrawCheckbox;

        // load the scene
        protected override void Load()
        {
            // load fonts
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
        }

        // on start create ui
        protected override void Start()
        {
            // set cursor stylesheet
            UI.SetCursor("ui/cursor.ini");

            // create ui root
            _uiroot = UI.CreateRoot();

            // create button and list window
            var buttonAndListWindow = UI.CreateWindow("ui/window.ini", _uiroot, "Button, DropDown & List");
            buttonAndListWindow.AutoArrangeChildren = true;
            buttonAndListWindow.Offset = new PointI(40, 30);
            buttonAndListWindow.Grow(0, 50);

            // add into text and button
            UI.CreateText("ui/small_text.ini", buttonAndListWindow, "This demo shows UI elements. \nFor example, here's a button:");
            var button = UI.CreateButton("ui/button.ini", buttonAndListWindow, "Click Me!");
            int clickCounts = 1;
            button.OnMouseReleased((UIElement elem) =>
            {
                button.Caption.Text = "Thanks! Clicks: " + clickCounts++;
            });

            // add a dropdown
            var dropdownTitle = UI.CreateText("ui/small_text.ini", buttonAndListWindow, "Here's a DropDown:");
            var dropdown = UI.CreateDropDown("ui/dropdown.ini", buttonAndListWindow);
            dropdown.PlaceholderText = "Click to show options.";
            for (var i = 1; i <= 15; ++i)
            {
                dropdown.AddItem("Item #" + i);
            }

            // add a list
            var listTitle = UI.CreateText("ui/small_text.ini", buttonAndListWindow, "And here's a List:");
            var list = UI.CreateList("ui/list.ini", buttonAndListWindow);
            for (var i = 1; i <= 15; ++i)
            {
                list.AddItem("Item #" + i);
            }

            // add text to show selected
            var listSelected = UI.CreateText("ui/small_text.ini", buttonAndListWindow, "Selected: ");
            list.OnValueChange((UIElement element) =>
            {
                listSelected.Text = "Selected: " + list.SelectedItem;
            });

            // create another window for checkboxes and slider
            var checkboxSliderWindow = UI.CreateWindow("ui/window.ini", _uiroot, "Checkbox, Radio & Slider");
            checkboxSliderWindow.Offset = new PointI(140, 60);
            checkboxSliderWindow.AutoArrangeChildren = true;

            // some checkboxes
            UI.CreateText("ui/small_text.ini", checkboxSliderWindow, "Checkboxes: ");
            var checkbox1 = UI.CreateCheckBox("ui/checkbox.ini", checkboxSliderWindow, "This is a checkbox");
            _debugDrawCheckbox = UI.CreateCheckBox("ui/checkbox.ini", checkboxSliderWindow, "Debug draw UI");

            // some radio buttons
            var radioIntro = UI.CreateText("ui/small_text.ini", checkboxSliderWindow, "Radio buttons: ");
            for (var i = 1; i <= 3; ++i)
            {
                var radio = UI.CreateRadioButton("ui/radiobutton.ini", checkboxSliderWindow, "Radio Button #" + i);
            }

            // add slider
            var sliderText = UI.CreateText("ui/small_text.ini", checkboxSliderWindow, "Slider Input [value=0]:");
            var slider = UI.CreateSlider("ui/slider.ini", checkboxSliderWindow);
            slider.OnValueChange((UIElement element) =>
            {
                sliderText.Text = "Slider Input [value=" + slider.Value + "]:";
            });

            // create another window for text inputs
            var textInputsWindow = UI.CreateWindow("ui/window.ini", _uiroot, "Text Inputs");
            textInputsWindow.Offset = new PointI(240, 90);
            textInputsWindow.AutoArrangeChildren = true;

            // add text input
            UITextInput textInput = UI.CreateTextInput("ui/textinput.ini", textInputsWindow, "", "Free text input..");
            textInput.MaxLength = 16;

            // add numbers input
            UITextInput numbersInput = UI.CreateTextInput("ui/textinput.ini", textInputsWindow, "", "Numbers input..");
            numbersInput.InputMode = UITextInputMode.NumbersOnly;
            numbersInput.MaxLength = 16;

            // add characters input
            UITextInput alphaInput = UI.CreateTextInput("ui/textinput.ini", textInputsWindow, "", "Alpha input..");
            alphaInput.InputMode = UITextInputMode.AlphaOnly;
            alphaInput.MaxLength = 16;

            // add numbers and alpha input
            UITextInput numbersAlphaInput = UI.CreateTextInput("ui/textinput.ini", textInputsWindow, "", "Numbers & alpha input..");
            numbersAlphaInput.InputMode = UITextInputMode.NumbersOnly | UITextInputMode.AlphaOnly;
            numbersAlphaInput.MaxLength = 16;

            // add upper input
            UITextInput upperInput = UI.CreateTextInput("ui/textinput.ini", textInputsWindow, "", "UPPERCASE INPUT..");
            upperInput.InputMode = UITextInputMode.Uppercase;
            upperInput.MaxLength = 16;

            // add lower input
            UITextInput lowerInput = UI.CreateTextInput("ui/textinput.ini", textInputsWindow, "", "lowercase input..");
            lowerInput.InputMode = UITextInputMode.Lowercase;
            lowerInput.MaxLength = 16;

            // add upper alpha input
            UITextInput upperAlphaInput = UI.CreateTextInput("ui/textinput.ini", textInputsWindow, "", "UPPERCASE ALPHA INPUT..");
            upperAlphaInput.InputMode = UITextInputMode.Uppercase | UITextInputMode.AlphaOnly;
            upperAlphaInput.MaxLength = 16;

            // create additional window for columns
            UIWindow columnsWindow = UI.CreateWindow("ui/window.ini", _uiroot, "Columns");
            columnsWindow.AutoArrangeChildren = true;
            columnsWindow.SizePixels = new PointI(400, 450);
            columnsWindow.Offset = new PointI(340, 120);

            // create some test columns
            {
                UIElement column = columnsWindow.CreateColumn(null, 80);
                UIRectangle rect = UI.CreateRectangle(null, column);
                rect.SetSizeToMax();
                rect.Color = Color.Red;
                rect.Filled = false;
            }
            {
                UIElement column = columnsWindow.CreateColumn(null, 70);
                UIRectangle rect = UI.CreateRectangle(null, column);
                rect.SetSizeToMax();
                rect.Color = Color.Orange;
                rect.Filled = false;
            }
            {
                UIElement column = columnsWindow.CreateColumn(null, 80, alignment: UIAlignment.Right);
                UIRectangle rect = UI.CreateRectangle(null, column);
                rect.SetSizeToMax();
                rect.Color = Color.Blue;
                rect.Filled = false;
            }
            {
                UIElement column = columnsWindow.CreateColumn(null, 70, alignment: UIAlignment.Right);
                UIRectangle rect = UI.CreateRectangle(null, column);
                rect.SetSizeToMax();
                rect.Color = Color.Teal;
                rect.Filled = false;
            }
            {
                UIElement column = columnsWindow.CreateColumn(null, 50, alignment: UIAlignment.Center);
                UIRectangle rect = UI.CreateRectangle(null, column);
                rect.SetSizeToMax();
                rect.Color = Color.Black;
                rect.Filled = false;
            }
            UI.CreateText("ui/small_text.ini", columnsWindow,
                "Columns allow you to divide containers into sections. Its useful when you need to place elements side by side.");

            // order windows
            textInputsWindow.MoveToFront();
            checkboxSliderWindow.MoveToFront();
            buttonAndListWindow.MoveToFront();
        }

        // on updates do animations and controls
        protected override void Update(double deltaTime)
        {
            // if user click 'exit' action, exit game
            if (Input.Down("exit"))
            {
                Game.Exit();
            }

            // update UI
            UI.UpdateUI(_uiroot);
        }

        // draw scene
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.Cornflower);

            // draw ui
            UI.Draw(_uiroot, false);

            // draw calls and fps
            Gfx.DrawText(_font, "FPS: " + Diagnostics.FpsCount.ToString(), new PointF(10, 10), Color.White, Color.Black, 1, 22);
            Gfx.DrawText(_font, "Draw Calls: " + Diagnostics.GetCounter(DiagnosticsCounters.DrawCalls).ToString(), new PointF(10, 40), Color.White, Color.Black, 1, 22);

            // draw cursor above all
            UI.DrawCursor();

            // debug draw
            if (_debugDrawCheckbox.Checked)
            {
                UI.DebugDraw(_uiroot);
            }
        }
    }
}
