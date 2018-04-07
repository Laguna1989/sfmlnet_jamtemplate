using System;
using JamUtilities;
using JamUtilities.Particles;
using JamUtilities.ScreenEffects;
using SFML.Graphics;
using SFML.Window;
using JamUtilities.Tweens;

namespace JamTemplate
{
    class Game
    {

        #region Fields

        public static JamUtilities.GameState _state;
        
        float _timeTilNextInput = 0.0f;

        #endregion Fields

        #region Methods

        public Game(GameState s)
        {

            //_state = s;
            SwitchState(s);
            //TODO  Default values, replace with correct ones !
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
        }

        public void GetInput()
        {
            if (_timeTilNextInput < 0.0f)
            {
                _state.GetInput();            
            }
        }
        
        public void Update(float deltaT)
        {
            if (_timeTilNextInput >= 0.0f)
            {
                _timeTilNextInput -= deltaT;
            }

            TimeObject to = Timing.Update(deltaT);
            Input.Update();
            TweenManager.Update(to);
            TimeManager.Update(to);
            _state.Update(to);

            CanBeQuit = false;
        
        }

        public void Draw(RenderWindow rw)
        {
            rw.Clear();
            _state.Draw(rw);

            _state.DrawOverlay(rw);
        }


        /// <summary>
        /// Immediately switches states
        /// </summary>
        /// <param name="gs">the new gamestate</param>
        public static void SwitchState (GameState gs)
        {   
            if (gs == null)
                throw new ArgumentNullException("gs","cannot switch to a gamestate which is null!");

            Game._state = gs;

            
            Game._state.Init();
        }

        
        private void DrawCredits(RenderWindow rw)
        {

            SmartText.DrawText("$GameTitle$", TextAlignment.MID, new Vector2f(400.0f, 20.0f), 1.5f, rw);

            SmartText.DrawText("A Game by", TextAlignment.MID, new Vector2f(400.0f, 100.0f), 0.75f, rw);
            SmartText.DrawText("$DeveloperNames$", TextAlignment.MID, new Vector2f(400.0f, 135.0f), rw);

            SmartText.DrawText("Visual Studio 2012 \t C#", TextAlignment.MID, new Vector2f(400, 170), 0.75f, rw);
            SmartText.DrawText("aseprite \t SFML.NET 2.1", TextAlignment.MID, new Vector2f(400, 200), 0.75f, rw);
            SmartText.DrawText("Cubase 5 \t SFXR", TextAlignment.MID, new Vector2f(400, 230), 0.75f, rw);

            SmartText.DrawText("Thanks to", TextAlignment.MID, new Vector2f(400, 350), 0.75f, rw);
            SmartText.DrawText("Families & Friends for their great support", TextAlignment.MID, new Vector2f(400, 375), 0.75f, rw);

            SmartText.DrawText("Created $Date$", TextAlignment.MID, new Vector2f(400.0f, 500.0f), 0.75f, rw);
            ScreenEffects.GetStaticEffect("vignette").Draw(rw);
            ScreenEffects.GetDynamicEffect("darkenLines").Draw(rw);
        }

        

        #endregion Methods

        #region Subclasses/Enums

        

        #endregion Subclasses/Enums


        public bool CanBeQuit { get; set; }
    }
}
