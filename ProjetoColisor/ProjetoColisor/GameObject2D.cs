using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjetoColisor.GameObjects
{
    public class GameObject2D
    {
        protected Texture2D _textura;
        public Texture2D Textura { get { return _textura; } }

        public Vector2 Posicao;
        public Vector2 Velocidade;
        public Vector2 Origem = Vector2.Zero;

        public Rectangle Limites
        {
            get
            {
                if (_textura != null && Posicao != null)
                    return new Rectangle((int)Posicao.X, (int)Posicao.Y, _textura.Width, _textura.Height);

                return Rectangle.Empty;
            }
        }

        public virtual void Load(ContentManager content, string assetName)
        {
            // Carrega a sprite/imagem é atribui o resultado á variavel _texture
            // para ser utilizada posteriomente no método Draw.
            _textura = content.Load<Texture2D>(assetName);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _textura,               // A textura que será desenhada.
                Posicao,                // Um objeto do tipo Vector2 contendo a posição para que a textura seja desenhada.
                null,                   // Uma região especifica na textura que será desenhada. Se null desenha a textura completa.
                Color.White,            // Máscara de cor.
                0f,                     // Rotaciona a sprite/imagem.
                Origem,                 // Um objeto do tipo Vector2 contendo a origem de movimentação e rotação. O padrão é X = 0 e Y = 0.
                Vector2.One,            // Dimensionamento da sprite/imagem.
                SpriteEffects.None,     // Efeito aplicado no momento de desenhar a textura.
                0f                      // Uma profundidade da camada da sprite.
                );
        }

    }
}
