using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoColisor.GameObjects
{
    public class Pothole: GameObject2D
    {
        public int Damage { get; set; }
        public void SetaPosicaoAleatoria(ref GraphicsDeviceManager graphics)
        {
            var random = new Random();

            // Gera um número aleatório entre 0 e o tamanho da tela menos a largura da textura.
            var posX = random.Next(0, graphics.GraphicsDevice.DisplayMode.Width - _textura.Width);

            // Gera um número aleatório entre 60% NEGATIVO da altura da tela e 0.
            var posY = random.Next((int)(graphics.GraphicsDevice.DisplayMode.Height * -0.6), 0);

            Posicao = new Vector2(posX, posY);
        }
    }
}
