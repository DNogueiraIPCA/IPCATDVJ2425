using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IPCA.Monogame;
using System.Diagnostics;

namespace Poligonos
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IPCA.Monogame.Debug _debug;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _debug = new IPCA.Monogame.Debug(GraphicsDevice, _spriteBatch);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _debug.DrawPixel(Vector2.One * 100, Color.DarkRed); //(1,1)*100 => (100,100)

            _debug.DrawLine(new Vector2(50, 100), new Vector2(400, 100), Color.Red); // Horizontal Line
            _debug.DrawLine(new Vector2(50, 100), new Vector2(50, 400), Color.Red); // Vertical Line
            _debug.DrawLine(new Vector2(50, 100), new Vector2(100, 400), Color.White); // Diagonal Vertical
            _debug.DrawLine(new Vector2(50, 100), new Vector2(400, 200), Color.White); // Diagonal Horizontal

            _debug.DrawCircle(new Vector2(400, 200), 100, Color.Yellow);

            _spriteBatch.End();

            base.Draw(gameTime);


        }
    }
}