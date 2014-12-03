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
        private Entity owner;
        public Render(Entity e, Texture2D t)
        {
            owner = e;
            texture = t;
        }

        public Matrix getTranslations()
        {
            double theta = Math.Asin((double)(owner.facing.Y / owner.facing.Length()));
            Matrix result = Matrix.CreateTranslation(owner.position.X, owner.position.Y, 0.0f);
            result = result * Matrix.CreateRotationZ((float)theta);
            return result;
        }

        public Texture2D getTexture()
        {
            return texture;
        }
    }
}
