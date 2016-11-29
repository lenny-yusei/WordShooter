using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShooter.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            var backgroundLayer = new asd.Layer2D();
            var background = new asd.TextureObject2D();
            background.Texture = asd.Engine.Graphics.CreateTexture2D("Resource/background.png");
            backgroundLayer.AddObject(background);
            AddLayer(backgroundLayer);

            player = new Charactor.Player(gameLayer);
            gameLayer.AddObject(player);
            asd.Vector2DF pos1 = new asd.Vector2DF(280f , 30f);
            asd.Vector2DF pos2 = new asd.Vector2DF(480f, 0f);

            char c = getRandomChar();

            AddLayer(gameLayer);
        }

        protected override void OnUpdated()
        {
            
            //CollisionPlayerAndBullet();
        }

        protected void CollisionPlayerAndBullet()
        {
            Func<bool> isHit = () =>
            {
                foreach (var obj in gameLayer.Objects)
                {
                    if (!(obj is Charactor.Bullet))
                        continue;
                    if (player.IsHit(obj as Charactor.Bullet))
                        return true;
                }
                return false;
            };

            if (isHit())
            {
                player.damage();
                gameLayer.Objects.ToList().RemoveAll(o =>
                {
                    if (!(o is Charactor.Bullet))
                        return false;
                    o.Dispose();
                    return true;
                });
            }
        }

        protected char getRandomChar()
        {
            Random r = new Random();
            int i = r.Next(words.Length);
            char c = words[i];
            return c;
        }

        protected Charactor.Player player;
        protected asd.Layer2D gameLayer = new asd.Layer2D();
        protected readonly string words = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
