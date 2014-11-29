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
    interface IBehaviour
    {
        private Entity owner;
        public abstract void update(GameTime time);
        public abstract void draw(GameTime time, SpriteBatch graphics);
        public abstract int getDrawPriority();
    }
}
