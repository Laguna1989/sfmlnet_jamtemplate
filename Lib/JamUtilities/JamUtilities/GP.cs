using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace JamUtilities
{
    public class GP
    {
        public static RenderWindow Window { get; set; } = null;
        public static View WindowGameView { get; set; } = null;
        public static Vector2u WindowSize { get; private set; } = new Vector2u(800,600);

        public static string WindowGameName { get; private set; } = "$GameTitle$";

        
    }
}
