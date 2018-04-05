using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace JamUtilities
{
    public class GameState : IGameObject
    {
        public List<IGameObject> _objects;

        public GameState()
        {           
            Create();
        }

        public void Add(IGameObject go)
        {
            _objects.Add(go);
        }

        /// <summary>
        /// function will be called upon construction Do only basic (lightwight) construction here
        /// </summary>
        public virtual void Create ()
        {
            _objects = new List<IGameObject>();
        }

        /// <summary>
        /// function will be called when this state becomes active 
        /// Load Resources here
        /// </summary>
        public virtual void Init()
        {

        }

        virtual public void Draw(RenderWindow rw)
        {
            foreach (IGameObject go in _objects)
            {
                go.Draw(rw);
            }
        }

        virtual public void GetInput()
        {
            foreach(IGameObject go in _objects)
            {
                go.GetInput();
            }
        }

        public bool IsDead()
        {
            return false;
        }

        virtual public void Update(TimeObject to)
        {
            foreach(IGameObject go in _objects)
            {
                go.Update(to);
            }
        }
    }
}
