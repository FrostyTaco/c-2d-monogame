using System;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace SpecialProjectTry8
{
    public class Player
    {
        Texture2D playerTexture;
        Texture2D texture;

        Rectangle playerSource;
        Rectangle playerDisplay;

        Color playerColor;
        Vector2 position;
        
        int currFrame;

        float timer;
        float interval = 200f;
        float elapsed;
        float delay = 200f;

        public Player(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
        }

        public Player(Texture2D playerTexture, Rectangle playerSource, Rectangle playerDisplay, Color playerColor)
        {
            this.playerTexture = playerTexture;
            this.playerSource = playerSource;
            this.playerDisplay = playerDisplay;
            this.playerColor = playerColor;
            
        }

        public Texture2D PlayerTexture { get => playerTexture; set => playerTexture = value; }
        public Rectangle PlayerSource { get => playerSource; }
        public Rectangle PlayerDisplay { get => playerDisplay; }
        public Color PlayerColor { get => playerColor; }

        public void playerDirection(int direction, GameTime gameTime)
        {
            playerSource = new Rectangle(currFrame * 126 / 4, 0, 126 / 4, 37);
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                
                currFrame++;
                timer = 0;
                if (currFrame > 3)
                    currFrame = 0;
                interval = 200f;
                return;
            }

            if (direction == 1)
            {
                playerSource.Y = 0;
                if (playerSource.X < playerTexture.Width - playerTexture.Width / 2)
                {
                    playerSource.X += playerTexture.Width / 2;
                }
                else { playerSource.X = 0; }
            }
            if (direction == 2)
            {
                playerSource.Y = 0;
                if (playerSource.X < playerTexture.Width - playerTexture.Width / 7)
                {
                    playerSource.X += playerTexture.Width / 7;
                }
                else { playerSource.X = 0; }
            }
            if (direction == 3)
            {
                playerSource.Y = 0;
                if (playerSource.X < playerTexture.Width - playerTexture.Width / 7)
                {
                    playerSource.X += playerTexture.Width / 7;
                }
                else { playerSource.X = 0; }
            }
            if (direction == 0)
            {
                playerSource.Y = 0;
                if (playerSource.X < playerTexture.Width - playerTexture.Width / 2)
                {
                    playerSource.X += playerTexture.Width / 2;
                }
                else { playerSource.X = 0; }
            }
        }

        public void Animation(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (currFrame >= 3)
                    currFrame = 0;
                else
                    currFrame++;
                elapsed = 0;
            }
            playerSource = new Rectangle(playerTexture.Width * currFrame, 0, playerTexture.Width, playerTexture.Height);
        }

        public void playerMovement(Point position, Point boundary)
        {
            Vector2 spritePosition = new Vector2(position.X, position.Y);
            spritePosition = Vector2.Clamp(spritePosition, new Vector2(0, 0), new Vector2(boundary.X - playerDisplay.Width, boundary.Y - playerDisplay.Height - 45));
            playerDisplay.Location = new Point((int)spritePosition.X, (int)spritePosition.Y);
        }
    }
}
