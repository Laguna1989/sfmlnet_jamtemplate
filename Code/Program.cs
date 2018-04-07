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
            var window = new RenderWindow(new VideoMode(GP.WindowSize.X, GP.WindowSize.Y, 32), "$WindowTitle$");

            window.Clear();
            window.Display();

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


            window.SetFramerateLimit(60);
            window.SetVerticalSyncEnabled(true);

            window.Closed += new EventHandler(OnClose);

            Game myGame = new Game(new StateIntro());
            window.SetView(Game.gameView);

            JamUtilities.Mouse.Window = window;

            int startTime = Environment.TickCount;
            int endTime = startTime;
            float time = 16.7f/1000; // 60 fps -> 16.7 ms per frame

            while (window.IsOpen())
            {
                window.DispatchEvents();

                if (startTime != endTime)
                {
                    time = (float)(endTime - startTime) / 1000.0f;
                }
                startTime = Environment.TickCount;

                

                
                

                myGame.GetInput();
                if (myGame.CanBeQuit)
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                    {
                        window.Close();
                    }
                }


                JamUtilities.Mouse.Update();

                myGame.Update(time);
                window.SetView(Game.gameView);

                myGame.Draw(window);

                window.Display();
                endTime = Environment.TickCount;
            }
        }
    }
}
