using JamUtilities;
using JamUtilities.Particles;
using JamUtilities.ScreenEffects;
using SFML.Graphics;
using SFML.Window;
using System;

namespace JamTemplate
{
    class Program
    {
        #region Event handlers

        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            SFML.Graphics.RenderWindow window = (SFML.Graphics.RenderWindow)sender;
            window.Close();
        }

        #endregion Event handlers

        static void Main(string[] args)
        {
            var applicationWindow = new RenderWindow(new VideoMode(GP.WindowSize.X, GP.WindowSize.Y, 32), "$WindowTitle$");

            applicationWindow.Clear();
            applicationWindow.Display();

            //////////////////////////////////////////////////////////////////////////////
            // setting up global properties
            SmartSprite._scaleVector = new Vector2f(2.0f, 2.0f);
            ScreenEffects.Init(new Vector2u(800, 600));
            ParticleManager.SetPositionRect(new FloatRect(-500, 0, 1400, 600));
            //ParticleManager.Gravity = GameProperties.GravitationalAcceleration;
            try
            {
                SmartText._font = new Font("../GFX/font.ttf");

                SmartText._lineLengthInChars = 18;
                SmartText._lineSpread = 1.2f;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //////////////////////////////////////////////////////////////////////////////
            //


            applicationWindow.SetFramerateLimit(60);
            applicationWindow.SetVerticalSyncEnabled(true);

            applicationWindow.Closed += new EventHandler(OnClose);

            Game myGame = new Game(new StateIntro());

            JamUtilities.Mouse.Window = applicationWindow;

            int startTime = Environment.TickCount;
            int endTime = startTime;
            float time = 16.7f/1000; // 60 fps -> 16.7 ms per frame

            while (applicationWindow.IsOpen())
            {
                if (startTime != endTime)
                {
                    time = (float)(endTime - startTime) / 1000.0f;
                }
                startTime = Environment.TickCount;

                applicationWindow.DispatchEvents();

                myGame.GetInput();
                if (myGame.CanBeQuit)
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                    {
                        applicationWindow.Close();
                    }
                }

                JamUtilities.Mouse.Update();

                myGame.Update(time);

                myGame.Draw(applicationWindow);

                applicationWindow.Display();
                endTime = Environment.TickCount;
            }
        }
    }
}
