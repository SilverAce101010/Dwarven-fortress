using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
//using System.Drawing;

namespace Dwarven_fortress
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private static Texture2D rect;

        private int _width = 15;
        private int _height = 15;

        private int _terrainHeight = 5;

        private int _pixelWidth = 25;
        private int _pixelHeight = 25;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 15d);// / 15d);
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = _width * (_pixelWidth+1);
            _graphics.PreferredBackBufferHeight = _height * (_pixelWidth+1);
            _graphics.ApplyChanges();

            // make list tovist and visted


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // creates rect
            rect = new Texture2D(GraphicsDevice, 1, 1);
            rect.SetData(new Color[] { Color.White });
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // paste copy of rect on each tile

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            List<int[]> toVisit = new List<int[]>();
            List<int[]> visited = new List<int[]>();

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if (i == (_width) / 2 && j == (_height) / 2)
                    {
                        _spriteBatch.Draw(rect, new Rectangle(i * (_pixelWidth + 1), j * (_pixelHeight + 1), _pixelWidth, _pixelHeight), Color.Gray);
                        toVisit.Add(new int[] { i * (_pixelWidth + 1), j * (_pixelHeight + 1) });
                    }
                    else
                    {
                        _spriteBatch.Draw(rect, new Rectangle(i * (_pixelWidth + 1), j * (_pixelHeight + 1), _pixelWidth, _pixelHeight), Color.CornflowerBlue);
                    }
                }
            }

            // generate from lists tovist and visited

            int[] coord = toVisit[0];
            int x = coord[0];
            int y = coord[1];
            coord.RemoveAt(0);

            _spriteBatch.Draw(rect, new Rectangle(x , y, _pixelWidth, _pixelHeight), Color.Red);
            


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
