
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace Dwarven_fortress
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private static Texture2D rect;

        List<int[]> toVisit;
        List<int[]> visited;

        int[,] grid;

        private int[] next;

        private int _width = 25;
        private int _height = 25;

        private int _terrainHeight = 5;

        private int _pixelWidth = 15;
        private int _pixelHeight = 15;

        private int red = 0;
        private int green = 25;
        private int blue = 0;

        Color terriancolor;

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

            toVisit = new List<int[]>();
            visited = new List<int[]>();

            terriancolor = new Color(red, green, blue);

            next = new int[0];

            grid = new int[_width, _height];
            toVisit.Add(new int[] { _width / 2, _height / 2 });
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

            terriancolor = new Color(red, green * 10, blue);

            int[] coord = toVisit[0];
            int x = coord[0];
            int y = coord[1];

            visited.Add(coord);
            toVisit.RemoveAt(0);
            grid[coord[0], coord[1]] = 1;

            if (coord[0] != 1 && coord[1] != 1 && coord[0] != _width && coord[1] != _height)
            {
                toVisit.Add(new int[] { x + 1, y });
                toVisit.Add(new int[] { x - 1, y });
                toVisit.Add(new int[] { x, y + 1 });

                next = new int[] { x, y - 1 };
                if (!toVisit.Contains(next) && !visited.Contains(next))
                {
                    toVisit.Add(next);
                }
            }
            
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
                    if (grid[i, j] == 1)
                    {
                        _spriteBatch.Draw(rect, new Rectangle(i * (_pixelWidth + 1), j * (_pixelHeight + 1), _pixelWidth, _pixelHeight), terriancolor);
                    }
                    else
                    {
                        _spriteBatch.Draw(rect, new Rectangle(i * (_pixelWidth + 1), j * (_pixelHeight + 1), _pixelWidth, _pixelHeight), Color.CornflowerBlue);

                    }
                }
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
