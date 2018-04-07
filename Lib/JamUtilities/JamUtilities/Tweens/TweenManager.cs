using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamUtilities
{
    namespace Tweens
    {
        public class TweenManager
        {
            private static List<Tween> _alltweens = null;

            private static void Initialize()
            {
                if (_alltweens == null)
                    _alltweens = new List<Tween>();
            }

            public static void Update(TimeObject to)
            {
                Initialize();
                foreach (Tween t in _alltweens)
                {
                    t.Update(to.ElapsedGameTime);
                }
                CleanUp();
            }

            private static void CleanUp()
            {
                Initialize();
                List<Tween> nt = new List<Tween>();
                foreach (Tween t in _alltweens)
                {
                    if (t.alive)
                    {
                        nt.Add(t);
                    }
                }
                _alltweens = nt;
            }

            internal static void Add(Tween t)
            {
                Initialize();
                if (t != null)
                {
                    _alltweens.Add(t);
                }
            }
            public static void Clear()
            {
                Initialize();
                _alltweens.Clear();
            }
        }
    }
}