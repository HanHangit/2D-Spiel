using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SFML.Window;
using SFML.Graphics;
using System.IO;

namespace Test
{
    class Map
    {
        Tile[,] tiles;
        public float TileSize { get { return 50; } }

        public Vector2f map;
        static string white = System.Drawing.Color.FromArgb(255, 255, 255).Name;
        static string black = System.Drawing.Color.FromArgb(0, 0, 0).Name;
        
        public Map(Bitmap mask) //Vorlesung bla bla bla
        {
            map = new Vector2f(mask.Width * TileSize, mask.Height * TileSize);
            //Mapstring(mask);
            tiles = new Tile[mask.Width, mask.Height];
            for (int i = 0; i < tiles.GetLength(0); ++i)
            {
                for (int j = 0; j < tiles.GetLength(1); ++j)
                {
                    if (mask.GetPixel(i, j).Name.Equals(black))
                    {
                        if((i < 2 || i > mask.Width - 2 || j < 2 || j > mask.Height - 2))
                            tiles[i, j] = new Tile(SFML.Graphics.Color.Black, new Vector2f(i, j) * TileSize, false, false, new Vector2f(TileSize, TileSize));
                        else
                            tiles[i, j] = new Tile(SFML.Graphics.Color.Black, new Vector2f(i, j) * TileSize, false, false, new Vector2f(TileSize, TileSize));
                    }
                    else
                    {
                        tiles[i, j] = new Tile(SFML.Graphics.Color.White, new Vector2f(i, j) * TileSize, true, true, new Vector2f(TileSize, TileSize));
                    }
                }
            }
        }

        public void Mapstring(Bitmap mask) //Vorlesung bla bla bla
        {
            StreamWriter text;
            text = new StreamWriter("C:/Users/" + Environment.UserName + "/Desktop/IslandData.txt");
            String[,] tiles = new String[mask.Width, mask.Height];
            String[,] tilesgrav = new String[mask.Width, mask.Height];
            for (int i = 0; i < tiles.GetLength(0); ++i)
            {
                for (int j = 0; j < tiles.GetLength(1); ++j)
                {
                    if (mask.GetPixel(i, j).Name.Equals(black))
                    {
                        if ((i < 30 || i > mask.Width - 30 || j < 30 || j > mask.Height - 30))
                        {
                            tiles[i, j] = tilesgrav[i, j] = "false";
                        }
                        else
                        {
                            tiles[i, j] = "false";
                            tilesgrav[i, j] = "false";
                        }
                    }
                    else
                    {
                        tiles[i, j] = tilesgrav[i, j] = "true";
                    }
                }
            }
            //System.IO.File.Create("Collision.txt");
            //System.IO.File.Create("Collisiongrav.txt");
            //System.IO.File.WriteAllText("Collision.txt", );
            //System.IO.File.WriteAllText("Collisiongrav.txt", tilesgrav.ToString());
        }



        public bool IsWalkable(GameObject gObj) //COllision mit Wand[Rechts,Links]
        {
            int x = (int)((gObj.Position.X - (gObj.sprite.TextureRect.Width / 2) + gObj.MovingDirection.X) / TileSize); 
            int y = (int)((gObj.Position.Y - (gObj.sprite.TextureRect.Height / 2) + gObj.MovingDirection.Y) / TileSize); 


            int sx = (int)((gObj.Position.X + (gObj.sprite.TextureRect.Width / 2) + gObj.MovingDirection.X) / TileSize);
            int sy = (int)((gObj.Position.Y - (gObj.sprite.TextureRect.Height / 2) + gObj.MovingDirection.Y) / TileSize );

            Console.WriteLine("x: " + x + "; y: " + y);
            // Console.WriteLine("x-sx: " + (x - sx) + " y-sy: "+ (y-sy));

            try
            {
                // Console.WriteLine("x: " + x + "; sx: " + sx);

                // return Wert fixen!!! ... es funktioniert allerdings leider noch nicht richtig
                // Problem war die Nutzung der falschen Variable(x war variabel und y fest)
                return tiles[x, y].Walkable && tiles[sx, sy].Walkable;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public bool IsWalkablegrav(GameObject gObj) //COllision nur mit Untergrund
        {
            int x = (int)((gObj.Position.X / TileSize + gObj.MovingDirection.X / TileSize));
            int y = (int)(((gObj.Position.Y - gObj.sprite.TextureRect.Height / 2) + gObj.MovingDirection.Y) / TileSize );

            int sx = (int)(gObj.Position.X / TileSize + gObj.MovingDirection.X / TileSize);
            int sy = (int)((gObj.Position.Y + gObj.sprite.TextureRect.Height / 2 + gObj.MovingDirection.Y) / TileSize );
            try
            {
                return tiles[x, sy].Walkablegrav && tiles[sx, sy].Walkablegrav;
            }
            catch(IndexOutOfRangeException)
            {
                return false;
            }
        }
        public void Draw(RenderWindow win)
        {

            
            /*
            foreach (Tile t in tiles)
            {
                t.Draw(win);
            }
            */
        }
    }
}
