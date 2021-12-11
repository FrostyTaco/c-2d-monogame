using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SpecialProjectTry8
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player;
        List<Coins> coin;
        Texture2D coinsTexture, playerTexture;

        Rectangle[] platform;
        
        int direction = 1;
        bool lookRight = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            playerTexture = Content.Load<Texture2D>("RunRightM");
            playerTexture = Content.Load<Texture2D>("RunLeftM");
            coin = new List<Coins>();
            int posX = 20;

            for (int i = 0; i < 7; i++)
            {
                coinsTexture = Content.Load<Texture2D>("Coins");
                coin.Add(new Coins(coinsTexture, new Rectangle(posX, 370, 30, 30),
                new Rectangle(coinsTexture.Width / 8, coinsTexture.Height / 4, coinsTexture.Width / 8, coinsTexture.Height / 4),
                Color.White));
                posX += 40;
            }
            int posX1 = 520;

            for (int i = 0; i < 7; i++)
            {
                coinsTexture = Content.Load<Texture2D>("Coins");
                coin.Add(new Coins(coinsTexture, new Rectangle(posX1, 370, 30, 30),
                new Rectangle(coinsTexture.Width / 8, coinsTexture.Height / 4, coinsTexture.Width / 8, coinsTexture.Height / 4),
                Color.White));
                posX1 += 40;
            }
            int posX2 = 700;

            for (int i = 0; i < 2; i++)
            {
                coinsTexture = Content.Load<Texture2D>("Coins");
                coin.Add(new Coins(coinsTexture, new Rectangle(posX2, 250, 30, 30),
                new Rectangle(coinsTexture.Width / 8, coinsTexture.Height / 4, coinsTexture.Width / 8, coinsTexture.Height / 4),
                Color.White));
                posX2 += 40;
            }
            int posX3 = 20;

            for (int i = 0; i < 2; i++)
            {
                coinsTexture = Content.Load<Texture2D>("Coins");
                coin.Add(new Coins(coinsTexture, new Rectangle(posX3, 250, 30, 30),
                new Rectangle(coinsTexture.Width / 8, coinsTexture.Height / 4, coinsTexture.Width / 8, coinsTexture.Height / 4),
                Color.White));
                posX3 += 40;
            }
            int posX4 = 250;

            for (int i = 0; i < 7; i++)
            {
                coinsTexture = Content.Load<Texture2D>("Coins");
                coin.Add(new Coins(coinsTexture, new Rectangle(posX4, 220, 30, 30),
                new Rectangle(coinsTexture.Width / 8, coinsTexture.Height / 4, coinsTexture.Width / 8, coinsTexture.Height / 4),
                Color.White));
                posX4 += 40;
            }
            int posX5 = 520;

            for (int i = 0; i < 7; i++)
            {
                coinsTexture = Content.Load<Texture2D>("Coins");
                coin.Add(new Coins(coinsTexture, new Rectangle(posX5, 80, 30, 30),
                new Rectangle(coinsTexture.Width / 8, coinsTexture.Height / 4, coinsTexture.Width / 8, coinsTexture.Height / 4),
                Color.White));
                posX5 += 40;
            }
            int posX6 = 20;

            for (int i = 0; i < 7; i++)
            {
                coinsTexture = Content.Load<Texture2D>("Coins");
                coin.Add(new Coins(coinsTexture, new Rectangle(posX6, 80, 30, 30),
                new Rectangle(coinsTexture.Width / 8, coinsTexture.Height / 4, coinsTexture.Width / 8, coinsTexture.Height / 4),
                Color.White));
                posX6 += 40;
            }

            platform = new Rectangle[]{new Rectangle(0, 563, 800, 46),
                new Rectangle(0, 403, 300, 25), new Rectangle(500, 404, 300, 25),
                new Rectangle(0, 283, 100, 25), new Rectangle(700, 283, 100, 25),
                new Rectangle(200, 260, 400, 25),
                new Rectangle(0, 115, 350, 25), new Rectangle(450, 115, 350, 25),};

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(playerTexture, new Rectangle(0, 0, playerTexture.Width / 4, playerTexture.Height),
            new Rectangle(200, 500, 50, 50), Color.White);
        }
        bool checkCol = false;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Point currentPosition = player.PlayerDisplay.Location;

            if (Keyboard.GetState().GetPressedKeys() == null || Keyboard.GetState().GetPressedKeys().Length == 0 && !checkCol)
            {
                direction = 1;

                if(lookRight)
                    player.PlayerTexture = Content.Load<Texture2D>("IdleM");

                else
                    player.PlayerTexture = Content.Load<Texture2D>("IdleM2");



                currentPosition.Y += 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                player.PlayerTexture = Content.Load<Texture2D>("RunLeftM");
                direction = 3;
                lookRight = false;
                currentPosition.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                player.PlayerTexture = Content.Load<Texture2D>("RunRightM");
                direction = 2;
                lookRight = true;
                currentPosition.X += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                

                if (lookRight)
                    player.PlayerTexture = Content.Load<Texture2D>("JumpRightM");

                else
                    player.PlayerTexture = Content.Load<Texture2D>("JumpLeftM");

                direction = 0;
                currentPosition.Y -= 5;
            }

            player.playerMovement(currentPosition, Window.ClientBounds.Size);
            player.playerDirection(direction, gameTime);

            foreach (Coins c in coin)
            { c.CoinAnimate(); }

            foreach (Rectangle p in platform)
            {
                if (p.Intersects(new Rectangle(currentPosition, player.PlayerDisplay.Size)) && p.Top < player.PlayerDisplay.Bottom)
                {
                    checkCol = true;
                    break;
                }
                else if (!p.Intersects(new Rectangle(currentPosition, player.PlayerDisplay.Size)))
                { checkCol = false; }
            }
            if (checkCol)
            { player.playerMovement(currentPosition, Window.ClientBounds.Size); }

            for (int i = 0; i < coin.Count; i++)
            {
                if (player.PlayerDisplay.Intersects(coin[i].CoinDisplay))
                {
                    coin.Remove(coin[i]);
                    goto A;
                }
            }
        A:

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null);
            _spriteBatch.Draw(Content.Load<Texture2D>("GameStage"), new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            _spriteBatch.Draw(player.PlayerTexture, player.PlayerDisplay, player.PlayerSource, player.PlayerColor);

            for (int i = 0; i < coin.Count; i++)
            {
                _spriteBatch.Draw(coin[i].CoinTexture, coin[i].CoinDisplay, coin[i].CoinSource, coin[i].CoinColor);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
