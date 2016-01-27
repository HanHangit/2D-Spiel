using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;

namespace Test
{
    class ParticleHandler
    {
        List<Particlemove> particlesmove;
        List<Particlecoll> particlescoll;
        Random r = new Random();
        float count,movecount;
        public ParticleHandler()
        {
            particlesmove = new List<Particlemove>(); //Liste für die Partikel
            particlescoll = new List<Particlecoll>();
        }

        public void SpawnMoveParticles(float maxnumber, float time, GameTime gTime,Vector2f start, Vector2f dir, float speed)
        {
            movecount += gTime.Ellapsed.Milliseconds;
            if(particlesmove.Count < maxnumber && movecount > time)
            {
                movecount = 0;
                particlesmove.Add(new Particlemove(start, dir, speed));
            }
        }

        public void SpawnCollParticles(int maxnumber, Vector2f start)
        {
            for (int i = 0; i < maxnumber; ++i)
            {
                particlescoll.Add(new Particlecoll(start, (float)r.NextDouble() * 5));
            }
        }

        public void Update(GameTime gTime)
        {
            count += gTime.Ellapsed.Milliseconds;
            for(int i = 0; i < particlesmove.Count(); ++i) //Alle Partikel werden geupdate
            {
                if (!particlesmove[i].isAlive) //Falls Partikel Tod -> dann entfernen
                {
                    particlesmove.RemoveAt(i);
                    --i;
                    continue;
                }

                particlesmove[i].Update(gTime);
            }
            for (int i = 0; i < particlescoll.Count(); ++i) //Alle Partikel werden geupdate
            {
                if (!particlescoll[i].isAlive) //Falls Partikel Tod -> dann entfernen
                {
                    particlescoll.RemoveAt(i);
                    --i;
                    continue;
                }

                particlescoll[i].Update(gTime);
            }
        }

        public void Draw(RenderWindow win)
        {
            foreach( Particlemove p in particlesmove) //Zeichnen der Partikel
            {
                p.Draw(win);
            }
            foreach (Particlecoll p in particlescoll)
            {
                p.Draw(win);
            }
        }
    }
}
