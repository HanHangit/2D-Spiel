using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class GameTime
    {
        Stopwatch watch;
        public TimeSpan Total { get; private set; }
        public TimeSpan Ellapsed { get; private set; }

        public GameTime()
        {
            watch = new Stopwatch();
            Total = new TimeSpan();
            Ellapsed = new TimeSpan();

            watch.Start();
        }

        public void Update()
        {
            if (watch.ElapsedMilliseconds == 0)
                Ellapsed = TimeSpan.FromMilliseconds(1);
            else
                Ellapsed = watch.Elapsed - Total;
            Total = watch.Elapsed;
            Console.WriteLine(Ellapsed.Milliseconds);
        }
    }
}