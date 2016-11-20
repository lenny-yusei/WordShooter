using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShooter.Scene
{
    sealed class Game : asd.Scene
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

            Random r = new Random();
            int i = r.Next(words.Length);
            char c = words[i];

            System.Console.WriteLine(c);
            enemy1 = new Charactor.Enemy(gameLayer, 'Z', pos1);
            gameLayer.AddObject(enemy1);
            enemy2 = new Charactor.Enemy(gameLayer, 'X', pos2);
            gameLayer.AddObject(enemy2);

            AddLayer(gameLayer);
        }

        protected override void OnUpdated()
        {
            if (!enemy1.IsAlive && !enemy2.IsAlive)
                asd.Engine.ChangeScene(new Scene.Clear());
            if (!player.IsAlive)
                asd.Engine.ChangeScene(new Scene.GameOver());
            CollisionPlayerAndBullet();
            //CollisionEnemyAndShot();
        }

        private void CollisionPlayerAndBullet()
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

       /* private void CollisionEnemyAndShot()
        {
            gameLayer.Objects.ToList().RemoveAll(o =>
            {
                if (!(o is Charactor.Shot))
                    return false;
                if (!(enemy1.IsHit(o as Charactor.Shot)) && !(enemy2.IsHit(o as Charactor.Shot)))
                   return false; 
                
                o.Dispose();
                enemy1.damage(o as Charactor.Shot);
                enemy2.damage(o as Charactor.Shot);
                return true;
            }); 
        }*/
        private Charactor.Player player;
        private Charactor.Enemy enemy1;
        private Charactor.Enemy enemy2;
        private asd.Layer2D gameLayer = new asd.Layer2D();
        private readonly string words = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
