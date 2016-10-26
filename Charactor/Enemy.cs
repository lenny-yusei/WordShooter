using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word.Charactor
{
    sealed class Enemy : asd.TextureObject2D
    {
        public Enemy(asd.Layer2D layer, char wordtype)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resource/enemy_Z.png");
            Scale = new asd.Vector2DF(Size.X / Texture.Size.X /2, Size.Y / Texture.Size.Y /2);
            CenterPosition = Texture.Size.To2DF() / 2;
            Position = new asd.Vector2DF(targetPositionA.X, -Size.Y);

            gameLayer = layer;
            this.wordtype = wordtype;
        }

        protected override void OnUpdate()
        {
            Move(targetPositionA);

            if (count%5 == 0)
            {
                for (int i=0; i<12; i++)
                {
                    var angle = 2 * Math.PI * (i / 12.0f);
                    var bulletPos = Position + 36.0f * new asd.Vector2DF((float)Math.Cos(angle), (float)Math.Sin(angle));

                    angle *= 360.0f / (2 * Math.PI); // rad to degree

                    if ((count / 30) % 2 == 0)
                    {
                        angle += 90;
                        bulletPos.X += 0.0f;
                    }
                    else
                    {
                        angle -= 90;
                        bulletPos.X -= 0.0f;
                    }

                    gameLayer.AddObject(new Bullet(bulletPos, (float)angle));
                }
            }
            
            count = (count + 1) % 1200;
        }

        public bool IsHit(Charactor.Shot shot)
        {
            return (shot.Position - Position).Length < 16;
        }

        public void damage(Charactor.Shot shot)
        {
           
            if (shot.shottype == this.wordtype)
                hp = 0; 
            else
                hp--;
            if (hp < 4)
                Texture = asd.Engine.Graphics.CreateTexture2D("Resource/自機.png");
            if (hp <= 0)
                Dispose();
        }

        public void Move(asd.Vector2DF target)//Moveを色々作る
        {
            var position = Position;
            position.Y = position.Y * 0.99f + target.Y * 0.01f;
            Position = position;
        }
        public char wordtype;

        private asd.Vector2DF Size = new asd.Vector2DF(128.0f, 128.0f);
        private readonly asd.Vector2DF targetPositionA = new asd.Vector2DF(240, 120);
        private asd.Layer2D gameLayer;

        private int count = 0;
        private int hp = 10;
    }
}
