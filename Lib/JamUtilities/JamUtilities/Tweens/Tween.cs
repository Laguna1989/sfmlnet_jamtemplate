using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamUtilities
{
    namespace Tweens
    {
        public class Tween
        {
            public float age = 0;
            public float maxTime;
            public bool alive = true;
            public float valueStart;
            public float valueEnd;
            internal Action OnDone = null;
            public PennerDoubleAnimation.EquationType ease;


            internal void Update(float elapsed)
            {
                age += elapsed;

                if (age >= maxTime)
                {
                    alive = false;
                    
                }
                else
                {
                    DoPerform();
                }
            }

            public virtual void DoPerform()
            {
                // nothing to see here
            }

            
        }
    }
}