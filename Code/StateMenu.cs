using JamUtilities;
using JamUtilities.ScreenEffects;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamTemplate
{
    class StateMenu : GameState
    {

        private bool exiting = false;

        public override void Init()
        {
            base.Init();
            
        }

        public override void Draw(RenderWindow rw)
        {
            base.Draw(rw);

            SmartText.DrawText(GP.WindowGameName, TextAlignment.MID, new Vector2f(400.0f, 150.0f), 1.5f, rw);

            SmartText.DrawText("Start [Return]", TextAlignment.MID, new Vector2f(400.0f, 250.0f), rw);
            SmartText.DrawText("W A S D & LShift", TextAlignment.MID, new Vector2f(530.0f, 340.0f), rw);
            SmartText.DrawText("Arrows & RCtrl", TextAlignment.MID, new Vector2f(180.0f, 340.0f), rw);

            ScreenEffects.GetStaticEffect("vignette").Draw(rw);
        }

        public override void Update(TimeObject timeObject)
        {
            
            base.Update(timeObject);
        
            if (Input.justPressed[Keyboard.Key.Return])
            {
                if (!exiting)
                {
                    StatePlay state = new StatePlay();
                    JamUtilities.Tweens.ShapeAlphaTween.createAlphaTween(_overlay, 255, 0.5f, () => Game.SwitchState(state));
                    exiting = true;
                }
                
            }    
        }
    }
}
