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
            Init();
        }

        public void Add(IGameObject go)
        {
            _objects.Add(go);
        }

        /// <summary>
        /// function will be called upon construction
        /// </summary>
        public virtual void Init ()
        {
            _objects = new List<IGameObject>();
        }

        /// <summary>
        /// function will be called when this state becomes active
        /// </summary>
        public virtual void OnStart()
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

        virtual public void Update(TimeObject timeObject)
        {
            foreach(IGameObject go in _objects)
            {
                go.Update(timeObject);
            }
        }
    }
}
