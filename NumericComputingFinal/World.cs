﻿#region Using Statements
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
    class World
    {
        List<Entity> entityList = new List<Entity>();
        Tile[][] tileMap;

        public void update(GameTime gameTime)
        {
            foreach(Entity e in entityList)
            {
                e.update(gameTime);
            }
        }

        public bool checkCollision(Entity entity)
        {
            BoundingBox bb = entity.getBB();
            foreach (Entity e in entityList)
            {
                if (e.getBB().Intersects(bb))
                {
                    entity.onCollideWithEntity(e);
                    e.onCollideWithEntity(entity);
                    return true;
                }
            }
            foreach (Tile[] tiles in tileMap)
            {
                foreach (Tile t in tiles)
                {
                    if (t.getBB().Intersects(bb))
                    {
                        t.onCollideWithEntity(entity);
                        entity.onCollideWithTile(t);
                        return true;
                    }
                }
            }
            return false;
        }

        public void updateDraw(GameTime gameTime, SpriteBatch graphics)
        {
            foreach (Entity e in entityList)
            {
                e.draw(gameTime, graphics);
            }

            foreach (Tile[] tiles in tileMap)
            {
                foreach (Tile t in tiles)
                {
                    t.draw(gameTime, graphics);
                }
            }
        }

        public void registerEntity(Entity e)
        {
            entityList.Add(e);
        }

        public void removeEntity(Entity e)
        {
            entityList.Remove(e);
        }

        public void loadMap(Map map)
        {
            tileMap = map.getTileMap(); 
        }
    }
}
