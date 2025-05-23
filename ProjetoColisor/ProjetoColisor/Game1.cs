using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjetoColisor.GameObjects;
using System.Collections.Generic;

namespace ProjetoColisor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Objetos do jogo.
        Car _carro;
        //Pothole _buraco;
        List<Pothole> _buracos;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

           //_graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

        }

        protected override void Initialize()
        {
            
            // Instância os objetos do jogo definindo uma posição inicial.
            _carro = new Car { Posicao = Vector2.Zero };
            //_buraco = new Pothole { Posicao = new Vector2(200, 100) };
            _buracos = new List<Pothole>();

            // Cria os buracos com uma velocidade para o eixo X de Zero
            // e eixo Y de 11 adicionando o mesmo na lista.
            for (int i = 0; i < 5; i++)
                _buracos.Add(new Pothole { Velocidade = new Vector2(0, 11) });

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Carrega os sprites/imagens.
            // Utilizando o método Load herdado da classe GameObject2D.
            _carro.Load(Content, "car");
            //_buraco.Load(Content, "pothole");
            
            foreach (var buraco in _buracos)
                buraco.Load(Content, "pothole");

            // Seta a posição inicial dos objetos do jogo.
            foreach (var buraco in _buracos)
                buraco.SetaPosicaoAleatoria(ref _graphics);

            _carro.SetaPosicaoInicial(ref _graphics);

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

            _spriteBatch.Begin(); // Chamada obrigatória antes de desenhar os objetos

            // Desenha os objetos do jogo;
            // Utilizando o método Draw herdado da classe GameObject2D.
            _carro.Draw(_spriteBatch);
            //_buraco.Draw(_spriteBatch);
            foreach (var buraco in _buracos)
                buraco.Draw(_spriteBatch);

            _spriteBatch.End(); // Chamada obrigatória após de desenhar os objetos

            base.Draw(gameTime);
        }
    }
}