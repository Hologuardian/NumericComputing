#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace NumericComputingFinal
{
    abstract class Render
    {
        private Texture2D texture;
        public Render(Entity e, Texture2D t)
        {
            texture = t;
        }

        public abstract void draw(GameTime time, SpriteBatch graphics);
    }
}
