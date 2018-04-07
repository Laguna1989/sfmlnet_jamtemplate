using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamUtilities
{
    namespace Tweens
    {
        public class ShapeAlphaTween : Tween
        {
            private Shape _shp;


            public ShapeAlphaTween(float mt, Shape shp, float end, Action done = null)
            {
                maxTime = mt;
                _shp = shp;
                valueStart = shp.FillColor.A;
                valueEnd = end;
                OnDone = done;
            }

            public void DoAlphaTween()
            {
                float t = age / maxTime;
                float dy = valueEnd - valueStart;
                float val = valueStart + dy * t;
                //Console.WriteLine("do alpha tween" + val.ToString());
                Color newCol = new Color(_shp.FillColor);
                newCol.A = (byte)(val);
                _shp.FillColor = newCol;
            }

            public override void DoPerform()
            {
                base.DoPerform();
                DoAlphaTween();
            }


            public static ShapeAlphaTween createAlphaTween(Shape shp, float end = 0, float time = 1, Action done = null)
            {
                ShapeAlphaTween t = new ShapeAlphaTween(time, shp, end, done);
                
                TweenManager.Add(t);
                return t;
            }




        }
    }
}