using System;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace SpecialProjectTry8
{
    public class Coins
    {
        Texture2D coinsTexture;
        Rectangle coinsDisplay, coinsSource;
        Color coinsColor;

        public Texture2D CoinTexture { get => coinsTexture; }
        public Rectangle CoinDisplay { get => coinsDisplay; }
        public Rectangle CoinSource { get => coinsSource; }
        public Color CoinColor { get => coinsColor; }

        public Coins(Texture2D coinTexture, Rectangle coinDisplay, Rectangle coinSource, Color coinColor)
        {
            this.coinsTexture = coinTexture;
            this.coinsDisplay = coinDisplay;
            this.coinsSource = coinSource;
            this.coinsColor = coinColor;
        }

        public void CoinAnimate()
        {
            coinsSource.Y = coinsTexture.Height / 4;
            if (coinsSource.X < coinsTexture.Width - coinsTexture.Width / 8)
            {
                coinsSource.X += coinsTexture.Width / 8;
            }
            else { coinsSource.X = 0; }
        }
    }
}
