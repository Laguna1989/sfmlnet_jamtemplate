using JamUtilities;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamTemplate
{
    class StatePlay : JamUtilities.GameState
    {
        public override void Init()
        {
            base.Init();


            for (int i = 0; i != 10; ++i)
            {
                Animation an = new Animation("../GFX/Soldier.png", new Vector2u(24, 24));
                an.Add("idle", new List<int>(new int[] { 0, 1, 2, 3, 4, 5 }), 0.3f);
                an.Play("idle");
                an.Position = RandomGenerator.GetRandomVector2fInRect(new FloatRect(0,0,GP.WindowSize.X, GP.WindowSize.Y));
                Add(an);
            }
        }

        public override void Draw(RenderWindow rw)
        {
            base.Draw(rw);


        }

        public override void Update(TimeObject timeObject)
        {
            base.Update(timeObject);

            if (Input.pressed[Keyboard.Key.D])
            {
                Game.gameView.Move(new Vector2f(10 * timeObject.ElapsedGameTime, 0));
            }
            else if (Input.pressed[Keyboard.Key.A])
            {
                Game.gameView.Move(new Vector2f(-10 * timeObject.ElapsedGameTime, 0));
            }

            //Console.WriteLine(Game.gameView.Center);
        }
    }
}
