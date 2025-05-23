using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCA.Monogame
{
    public class Debug
    {
        private Texture2D _pixel;
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;

        public Debug(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            _pixel = new Texture2D(graphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
        }

        public void DrawPixel(Vector2 position, Color color)
        {
            _spriteBatch.Draw(_pixel, position, color);
        }

        public void DrawLine(Vector2 p0, Vector2 p1, Color color)
        {
            // Linha Horizontal
            if ((int)p0.Y == (int)p1.Y)
            {
                int x = (int)Math.Min(p0.X, p1.X);
                int w = (int)Math.Abs(p1.X - p0.X);
                _spriteBatch.Draw(_pixel, new Rectangle(x, (int)p0.Y, w, 1), color);
            }
            // Linha Vertical
            else if ((int)p0.X == (int)p1.X)
            {
                int y = (int)Math.Min(p0.Y, p1.Y);
                int h = (int)Math.Abs(p1.Y - p0.Y);
                _spriteBatch.Draw(_pixel, new Rectangle((int)p0.X, y, 1, h), color);
            }
            // Linha Diagonal
            else
            {
                // p0.Y = p0.X * m + b
                // p1.Y = p1.X * m + b

                // b = p0.Y - p0.X * m
                // p1.Y = p1.X * m + p0.Y - p0.X * m <=>
                // p1.Y - p0.Y = p1.X * m - p0.X * m <=>
                // p1.Y - p0.Y = m(p1.X - p0.X) <=>

                // m = (p1.Y - p0.Y) / (p1.X - p0.X)
                // b = p0.Y - p0.X * (p1.Y - p0.Y) / (p1.X - p0.X)

                float m = (p1.Y - p0.Y) / (p1.X - p0.X);
                float b = p0.Y - p0.X * m;

                // Diagonal "horizontal"
                if (Math.Abs(p0.X - p1.X) > Math.Abs(p0.Y - p1.Y))
                {
                    int x0 = (int)Math.Min(p0.X, p1.X);
                    int x1 = (int)Math.Max(p0.X, p1.X);
                    for (int x = x0; x <= x1; x++)
                    {
                        Vector2 pos = new Vector2(x, m * x + b);
                        _spriteBatch.Draw(_pixel, pos, color);
                    }
                }
                else // Diagonal "vertical"
                {
                    int y0 = (int)Math.Min(p0.Y, p1.Y);
                    int y1 = (int)Math.Max(p0.Y, p1.Y);
                    for (int y = y0; y <= y1; y++)
                    {
                        // y = mx + b <=> mx = y - b <=> x = (y-b)/m
                        Vector2 pos = new Vector2((y - b) / m, y);
                        _spriteBatch.Draw(_pixel, pos, color);
                    }
                }
            }

        }
        public void DrawCircle(Vector2 center, float radius, Color color)
        {
            float inc = MathF.PI / (4 * radius);
            for (float theta = 0; theta < MathF.PI * 2; theta += inc)
            {
                Vector2 vec = new Vector2(MathF.Cos(theta), MathF.Sin(theta)) * radius;
                _spriteBatch.Draw(_pixel, center + vec, color);
            }
        }

    }
}