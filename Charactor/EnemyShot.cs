using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace WordShooter.Charactor
{
    public class EnemyShot : asd.TextureObject2D
    {
        public Type type;

        public EnemyShot(Type type, int count, Vector2DF pos, Layer2D gameLayer)
        {
            if (type == Type.t1)
                ShotTypeA(count, pos, gameLayer);
            else
                ShotTypeB(count, pos, gameLayer);
        }
        
        public static void ShotTypeA(int count, Vector2DF pos, Layer2D gameLayer)
        {
            if (count % 7 == 0)
            {
                for (int i = 0; i < 12; i++)
                {
                    var angle = 2 * Math.PI * (i / 12.0f);
                    var bulletPos = pos + 36.0f * new asd.Vector2DF((float)Math.Cos(angle), (float)Math.Sin(angle));

                    angle *= 360.0f / (2 * Math.PI); // rad to degree

                    if ((count / 30) % 3 == 0)
                    {
                        angle += 90;
                        bulletPos.X += 0.0f;
                    }
                    else if ((count / 30) % 3 == 1)
                    {
                        angle -= 90;
                        bulletPos.X -= 0.0f;
                    }
                    else { }
                    gameLayer.AddObject(new Bullet(bulletPos, (float)angle));
                }
            }
        }
        public static void ShotTypeB(int count, Vector2DF pos, Layer2D gameLayer)
        {
            if (count % 10 == 0)
            {
                var bulletPos = new asd.Vector2DF(pos.X, pos.Y + 30);
                gameLayer.AddObject(new Bullet(bulletPos, +90));
                gameLayer.AddObject(new Bullet(bulletPos, +110));
                gameLayer.AddObject(new Bullet(bulletPos, +70));
            }
        }

        public enum Type
        {
            t1, t2
        }
    }
}
