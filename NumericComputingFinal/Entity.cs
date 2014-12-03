using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace NumericComputingFinal
{
    abstract class Entity
    {
        public Vector2 position;
        public Vector2 facing;
        public Vector2 velocity;
        private float health;
        private float armor;
        private List<IBehaviour> behaviourList = new List<IBehaviour>();

        public Entity()
        {
            position = new Vector2(0, 0);
            facing = new Vector2(0, 0);
            velocity = new Vector2(0, 0);
            health = 1.0f;
            armor = 0;
        }

        public abstract BoundingBox getBB();
        public abstract List<Render> getAllRenders();
        public abstract void onCollideWithEntity(Entity entity);
        public abstract void onCollideWithTile(Tile tile);

        public void update(GameTime time)
        {
            foreach (IBehaviour beh in behaviourList)
            {
                beh.update(time);
            }

            int delta = time.ElapsedGameTime.Milliseconds;
            position += velocity * delta;
        }

        public void draw(GameTime time, SpriteBatch batch)
        {
            IBehaviour drawBehaviour = null;
            foreach (IBehaviour beh in behaviourList)
            {
                if (drawBehaviour == null)
                {
                    drawBehaviour = beh;
                }
                else if(beh.getDrawPriority() > drawBehaviour.getDrawPriority())
                {
                    drawBehaviour = beh;
                }
            }

            drawBehaviour.draw(time, batch);
        }

        public void addBehaviour(IBehaviour b)
        {
            behaviourList.Add(b);
        }

        public bool removeBehaviour(IBehaviour b)
        {
            return behaviourList.Remove(b);
        }

        public void setVelocity(Vector2 v)
        {
            velocity = v;
        }

        public void addVelocity(Vector2 v)
        {
            velocity += v;
        }

        public void setHp(float hp)
        {
            health = hp;
        }

        public float getHp()
        {
            return health;
        }

        public void setArmor(float a)
        {
            armor = a;
        }

        public float getArmor()
        {
            return armor;
        }
    }
}
