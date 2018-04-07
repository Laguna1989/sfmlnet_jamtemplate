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
        //private Animation an;
        private SmartSprite an;
        private Shape _overlay;
        private float _fadeInTime = 1.25f;


        public override void Init()
        {
            base.Init();
            
            //an = new Animation("../GFX/Soldier.png", new Vector2u(24, 24));
            //an.Add("idle", new List<int>(new int[] { 0, 1, 2, 3, 4, 5 }), 0.3f);
            //an.Play("idle");
            //an.Position = new Vector2f(200, 10);
            //Add(an);
            an = new SmartSprite("../GFX/Soldier.png");
            an.Sprite.TextureRect = new IntRect(0, 0, 24, 24);
            an.Position = new Vector2f(200, 10);
            Add(an);
        }

        public override void Draw(RenderWindow rw)
        {
            base.Draw(rw);

            SmartText.DrawText("$GameTitle$", TextAlignment.MID, new Vector2f(400.0f, 150.0f), 1.5f, rw);

            SmartText.DrawText("Start [Return]", TextAlignment.MID, new Vector2f(400.0f, 250.0f), rw);
            SmartText.DrawText("W A S D & LShift", TextAlignment.MID, new Vector2f(530.0f, 340.0f), rw);
            SmartText.DrawText("Arrows & RCtrl", TextAlignment.MID, new Vector2f(180.0f, 340.0f), rw);

            SmartText.DrawText("[C]redits", TextAlignment.LEFT, new Vector2f(30.0f, 550.0f), rw);
            ScreenEffects.GetStaticEffect("vignette").Draw(rw);
        }

        public override void Update(TimeObject timeObject)
        {
            
            base.Update(timeObject);
            if (Input.justPressed[Keyboard.Key.X])
            {
                an.Flash(Color.Red, 0.5f);
            }
            if (Input.justReleased[Keyboard.Key.X])
            {
                an.Flash(Color.Blue, 0.5f);
            }
            if (Input.justPressed[Keyboard.Key.C])
            {
                an.Shake(0.5f, 0.02f, 5);
            }
        }
    }
}
