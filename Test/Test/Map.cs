using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SFML.Window;
using SFML.Graphics;

namespace Test
{
    class Map
    {
        Tile[,] tiles;
        public float TileSize { get { return 1; } }
        

        static string white = System.Drawing.Color.FromArgb(255, 255, 255).Name;
        static string black = System.Drawing.Color.FromArgb(0, 0, 0).Name;
        
        public Map(Bitmap mask)
        {
            tiles = new Tile[mask.Width, mask.Height];
            for (int i = 0; i < tiles.GetLength(0); ++i)
            {
                for (int j = 0; j < tiles.GetLength(1); ++j)
                {
                    if (mask.GetPixel(i, j).Name.Equals(black))
                    {
                        if((i < 30 || i > mask.Width - 30 || j < 30 || j > mask.Height - 30))
                            tiles[i, j] = new Tile(SFML.Graphics.Color.Black, new Vector2f(i, j) * TileSize, false, false, new Vector2f(TileSize, TileSize));
                        else
                            tiles[i, j] = new Tile(SFML.Graphics.Color.Black, new Vector2f(i, j) * TileSize, false, true, new Vector2f(TileSize, TileSize));
                    }
                    else
                    {
                        tiles[i, j] = new Tile(SFML.Graphics.Color.White, new Vector2f(i, j) * TileSize, true, true, new Vector2f(TileSize, TileSize));
                    }
                }
            }
        }

        public bool IsWalkable(GameObject gObj)
        {
            int x = (int)(gObj.Position.X - gObj.sprite.TextureRect.Width / 2 / TileSize + gObj.MovingDirection.X / TileSize);
            int y = (int)(gObj.Position.Y - gObj.sprite.TextureRect.Height / 2 / TileSize + gObj.MovingDirection.Y / TileSize );

            int sx = (int)(gObj.Position.X / TileSize + gObj.sprite.TextureRect.Width / 2 / TileSize + gObj.MovingDirection.X / TileSize);
            int sy = (int)(gObj.Position.Y / TileSize + gObj.sprite.TextureRect.Height / 2 / TileSize + gObj.MovingDirection.Y / TileSize );

            try
            {
                return tiles[x, 150].Walkable && tiles[sx, 150].Walkable;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public bool IsWalkablegrav(GameObject gObj)
        {
            int x = (int)((gObj.Position.X - gObj.sprite.TextureRect.Width / 2) + gObj.MovingDirection.X / TileSize);
            int y = (int)((gObj.Position.Y - gObj.sprite.TextureRect.Height / 2) + gObj.MovingDirection.Y / TileSize - 3);

            int sx = (int)(gObj.Position.X / TileSize + gObj.sprite.TextureRect.Width / 2 + gObj.MovingDirection.X / TileSize);
            int sy = (int)(gObj.Position.Y / TileSize + gObj.sprite.TextureRect.Height / 2 + gObj.MovingDirection.Y / TileSize -3);
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
