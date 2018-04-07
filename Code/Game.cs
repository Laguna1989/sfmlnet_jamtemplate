﻿using System;
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

        public static View gameView;

        float _timeTilNextInput = 0.0f;

        private static Shape _background;
        

        #endregion Fields

        #region Methods

        public Game(GameState s)
        {

            //_state = s;
            SwitchState(s);
            //TODO  Default values, replace with correct ones !
            SmartSprite._scaleVector = new Vector2f(2.0f, 2.0f);
            ScreenEffects.Init(new Vector2u(800, 600));
            gameView = new View(new FloatRect(0, 0, GP.WindowSize.X, GP.WindowSize.Y));
            ParticleManager.SetPositionRect(new FloatRect(-500, 0, 1400, 600));
            //ParticleManager.Gravity = GameProperties.GravitationalAcceleration;
            _background = new RectangleShape(new Vector2f(GP.WindowSize.X, GP.WindowSize.Y));
            _background.FillColor = Color.Black;

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
            rw.Draw(_background);
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

        public static void SetBackgroundColor (Color c)
        {
            _background.FillColor = c;
        }
        
        

        #endregion Methods

        #region Subclasses/Enums

        

        #endregion Subclasses/Enums


        public bool CanBeQuit { get; set; }
    }
}
