using JamUtilities;
using SFML;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamTemplate
{
    class StateIntro : JamUtilities.GameState
    {

        #region Fields

        private Sprite _logo;
        private Shape _overlay;
        private Shader _pixelate;
        private RenderStates _states;
        private float _timeToDisplay;

        private float _timeFadeIn; 
        private float _initialTimeFadeIn;
        private float _fadeAlphaIn = 1.0f;

        private float _timeFadeOut;
        private float _initialTimeFadeOut;
        private float _fadeAlphaOut;

        private int _screenCounter;

        public GameState nextState = new StateMenu();
        
        
        #endregion Fields

        public StateIntro(GameState next = null )
        {
            if (next != null)
                nextState = next;
        }

        public override void Init()
        {
            base.Init();
            _timeToDisplay = 2.0f;

            _initialTimeFadeIn = 1.25f;
            _timeFadeIn = _initialTimeFadeIn;

            _initialTimeFadeOut = 1.75f;
            _timeFadeOut = _initialTimeFadeOut;

            try
            {
                LoadGraphics();
            }
            catch (LoadingFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public override void Draw(RenderWindow rw)
        {
            base.Draw(rw);

            if (Shader.IsAvailable)
            {
                rw.Draw(_logo, _states);
            }
            else
            {
                rw.Draw(_logo);
            }
            rw.Draw(_overlay);

            
        }

        public override void Update(TimeObject to)
        {
            base.Update(to);

            _timeFadeIn -= to.ElapsedGameTime;

            if (_timeFadeIn <= 0.0f)
            {
                _timeToDisplay -= to.ElapsedGameTime;

                if (Math.Abs(_timeFadeOut - _initialTimeFadeOut) < 0.01f)
                {
                    _overlay.FillColor = new Color(0, 0, 0, 0);
                }

                if (_timeToDisplay <= 0.0f)
                {
                    _timeFadeOut -= to.ElapsedGameTime;

                    if (_overlay.FillColor.A == byte.MaxValue)
                    {
                        Game.SwitchState(nextState);
                        return;
                    }

                    FadeLogoOut();
                }
            }
            else
            {
                FadeLogoIn();
            }
        }

        private void LoadGraphics()
        {
            _logo = new Sprite(new Texture("../GFX/runvs.png"));
            _overlay = new RectangleShape( new Vector2f(GP.WindowSize.X, GP.WindowSize.Y));
            _overlay.FillColor = new Color(0, 0, 0, 255);

            if (Shader.IsAvailable)
            {
                _pixelate = new Shader(null, "../GFX/pixelate.frag");
                _pixelate.SetParameter("tex", _logo.Texture);
                _pixelate.SetParameter("strength", 0.0f);
                _states = new RenderStates(_pixelate);
            }
        }

        private void FadeLogoIn()
        {
            _fadeAlphaIn = _timeFadeIn / _initialTimeFadeIn;
            _overlay.FillColor = new Color(0, 0, 0, (byte)(_fadeAlphaIn * 255));
        }

        /// <summary>
        /// Fades the logo out.
        /// </summary>
        private void FadeLogoOut()
        {
            _fadeAlphaOut = 1.0f - (_timeFadeOut / _initialTimeFadeOut);

            if (_fadeAlphaOut > 1.0f)
            {
                _fadeAlphaOut = 1.0f;
            }

            if (Shader.IsAvailable)
            {
                _pixelate.SetParameter("strength", _fadeAlphaOut * 50.0f);
            }

            _overlay.FillColor = new Color(0, 0, 0, (byte)(_fadeAlphaOut * 255));
        }

    }
}
