using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace JamUtilities
{
    class IGameObjectGroup : IGameObject
    {
        public List<IGameObject> members { get; private set; }

        public IGameObjectGroup()
        {
            members = new List<IGameObject>();
        }


        public void Draw(RenderWindow rw)
        {
            foreach (IGameObject go in members)
            {
                go.Draw(rw);
            }
        }

        public void GetInput()
        {
            foreach (IGameObject go in members)
            {
                go.GetInput();
            }
        }

        public bool IsDead()
        {
            return false;
        }

        public void Update(TimeObject to)
        {
            foreach (IGameObject go in members)
            {
                go.Update(to);
            }
        }

        public Vector2f GetPosition()
        {
            return new Vector2f(0,0);
        }

        public void SetPosition(Vector2f newPos)
        {
#if DEBUG
            Console.WriteLine("cannot set position on GameObjectGroup!");
#endif
        }
    }
}
