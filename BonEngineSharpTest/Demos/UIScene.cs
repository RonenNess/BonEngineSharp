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

            // create main window
            var window = UI.CreateWindow("ui/window.ini", _uiroot, "UI Example");
            window.AutoArrangeChildren = true;
            window.Offset = new PointI(100, 80);

            // add into text and button
            UI.CreateText("ui/small_text.ini", window, "This demo shows some built-in UI elements. \nFor example, here's a button:");
            var button = UI.CreateButton("ui/button.ini", window, "Click Me!");
            int clickCounts = 1;
            button.OnMouseReleased((UIElement elem) =>
            {
                button.Caption.Text = "Thanks! Clicks: " + clickCounts++;
            });

            // add a list
            var listTitle = UI.CreateText("ui/small_text.ini", window, "And here's a list:");
            var list = UI.CreateList("ui/list.ini", window);
            for (var i = 1; i <= 15; ++i)
            {
                list.AddItem("Item #" + i);
            }

            // add text to show selected
            var listSelected = UI.CreateText("ui/small_text.ini", window, "Selected: ");
            list.OnValueChange((UIElement element) =>
            {
                listSelected.Text = "Selected: " + list.SelectedItem;
            });

            // create another window
            var secondWindow = UI.CreateWindow("ui/window.ini", _uiroot, "Some More..");
            secondWindow.Offset = new PointI(200, 100);
            secondWindow.AutoArrangeChildren = true;

            // some checkboxes
            UI.CreateText("ui/small_text.ini", secondWindow, "Checkboxes: ");
            var checkbox1 = UI.CreateCheckBox("ui/checkbox.ini", secondWindow, "This is a checkbox");
            _debugDrawCheckbox = UI.CreateCheckBox("ui/checkbox.ini", secondWindow, "Debug draw UI");

            // some radio buttons
            var radioIntro = UI.CreateText("ui/small_text.ini", secondWindow, "Radio buttons: ");
            for (var i = 1; i <= 3; ++i)
            {
                var radio = UI.CreateRadioButton("ui/radiobutton.ini", secondWindow, "Radio Button #" + i);
            }

            // add slider
            var sliderText = UI.CreateText("ui/small_text.ini", secondWindow, "Slider Input [value=0]:");
            var slider = UI.CreateSlider("ui/slider.ini", secondWindow);
            slider.OnValueChange((UIElement element) =>
            {
                sliderText.Text = "Slider Input [value=" + slider.Value + "]:";
            });

            // make original window front
            window.MoveToFront();
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
            Gfx.ClearScreen(Color.FromBytes(32, 150, 242));

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
