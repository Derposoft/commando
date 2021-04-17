using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Commando
{
    class StartInterface
    {
        Vector2 START_GAME_LABEL_POS;
        Vector2 QUIT_GAME_LABEL_POS;
        Vector2 MONEY_LABEL_POS;

        Vector3 shipPos;
        Color startColor = Color.Yellow, quitColor = Color.Yellow;

        public bool startDone = false;
        public float timer;
        int money;

        Game1 game;

        public StartInterface(Game1 Game)
        {
            game = Game;
            shipPos = new Vector3(0, 0, 0);
            START_GAME_LABEL_POS = new Vector2(400, 100);
            QUIT_GAME_LABEL_POS = new Vector2(400, 250);
            MONEY_LABEL_POS = new Vector2(400, 500);
            money = game.money;
        }

        public void Update()
        {
            timer += 1;
            money = game.money;
            startColor = Color.Yellow;
            quitColor = Color.Yellow;

            if (Mouse.GetState().X > START_GAME_LABEL_POS.X && Mouse.GetState().X < START_GAME_LABEL_POS.X + 200 &&
                Mouse.GetState().Y > START_GAME_LABEL_POS.Y && Mouse.GetState().Y < START_GAME_LABEL_POS.Y + 40)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    startDone = true;
                startColor = Color.Red;
            }

            if (Mouse.GetState().X > QUIT_GAME_LABEL_POS.X && Mouse.GetState().X < QUIT_GAME_LABEL_POS.X + 200 &&
                Mouse.GetState().Y > QUIT_GAME_LABEL_POS.Y && Mouse.GetState().Y < QUIT_GAME_LABEL_POS.Y + 40)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    game.Exit();
                quitColor = Color.Red;
            }
        }

        public void Draw(SpriteBatch SB, SpriteFont spriteFont, GraphicsDevice graphicsDevice, Texture2D crossHairs)
        {
            graphicsDevice.Clear(Color.SpringGreen);

            SB.Begin();

            SB.Draw(crossHairs, new Vector2(
                Mouse.GetState().X - crossHairs.Bounds.Width / 2,
                    Mouse.GetState().Y - crossHairs.Bounds.Height / 2), null,
                        Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 1);

            SB.DrawString(spriteFont, "Play Game", START_GAME_LABEL_POS, startColor);
            SB.DrawString(spriteFont, "Quit Game", QUIT_GAME_LABEL_POS, quitColor);
            SB.DrawString(spriteFont, ("$" + money), MONEY_LABEL_POS, Color.Yellow);

            SB.End();

            //draws a spaceship if an option is highlighted << this is fake ?<what was I thinking lol

            if ((Mouse.GetState().X > START_GAME_LABEL_POS.X && Mouse.GetState().X < START_GAME_LABEL_POS.X + 200 &&
                Mouse.GetState().Y > START_GAME_LABEL_POS.Y && Mouse.GetState().Y < START_GAME_LABEL_POS.Y + 40) ||
                (Mouse.GetState().X > QUIT_GAME_LABEL_POS.X && Mouse.GetState().X < QUIT_GAME_LABEL_POS.X + 200 &&
                Mouse.GetState().Y > QUIT_GAME_LABEL_POS.Y && Mouse.GetState().Y < QUIT_GAME_LABEL_POS.Y + 40))
            {
            }
        }
    }
}
