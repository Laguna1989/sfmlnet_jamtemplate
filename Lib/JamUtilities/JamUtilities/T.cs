﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamUtilities
{
    class T
    {
        // print this only in Debug mode
        public static void TraceD(string err)
        {
#if DEBUG
            Trace(err);
#endif
        }

        // print this all the time
        public static void Trace(string err)
        {

            Console.WriteLine(err);

        }
    }
}
