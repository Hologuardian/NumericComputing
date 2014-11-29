using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace NumericComputingFinal
{
    abstract class Tile
    {
        private Vector2 position;

        public Tile()
        {
            position = new Vector2(0);
        }

        public abstract void draw();
        public abstract void onCollideWithEntity(Entity entity);
        public abstract BoundingBox getBB();
    }
}
