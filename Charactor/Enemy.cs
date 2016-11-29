using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShooter.Charactor
{
    sealed class Enemy : asd.TextureObject2D
    {
        public Enemy(asd.Layer2D layer, char wordtype, asd.Vector2DF pos, EnemyShot.Type t)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resource/game_enemy/enemy_" + wordtype + ".png");
            Scale = new asd.Vector2DF(Size.X / Texture.Size.X /2, Size.Y / Texture.Size.Y /2);
            CenterPosition = Texture.Size.To2DF() / 2;
            Position = new asd.Vector2DF(pos.X, -pos.Y);
   
            gameLayer = layer;
            this.wordtype = wordtype;
            typ = t;
        }

        protected override void OnUpdate()
        {
            Move(targetPositionA);
            
            EnemyShot.ShotTypeA(count, Position, gameLayer);

            CollisionEnemyAndShot();
            count = (count + 1) % 1200;
        }

        public bool IsHit(Charactor.Shot shot)
        {
            return (shot.Position - Position).Length < 16;
        }

        public void damage(Charactor.Shot shot)
        {
            if (shot.shotType == this.wordtype)
                hp = 0; 
            else
                hp--;
            if (hp < 4)
                Texture = asd.Engine.Graphics.CreateTexture2D("Resource/game_enemy/enemy_" + wordtype + ".png");
            if (hp <= 0)
                this.Dispose();
        }

        public void Move(asd.Vector2DF target)//Moveを色々作る
        {
            var position = Position;
            position.Y = position.Y * 0.99f + target.Y * 0.01f;
            Position = position;
        }
        
        private void CollisionEnemyAndShot()
        {
            gameLayer.Objects.ToList().RemoveAll(o =>
            {
                if (!(o is Charactor.Shot))
                    return false;
                if (!(this.IsHit(o as Charactor.Shot)))
                    return false;

                o.Dispose();
                this.damage(o as Charactor.Shot);
                
                return true;
            });
        }

        public char wordtype;

        private asd.Vector2DF Size = new asd.Vector2DF(128.0f, 128.0f);
        private readonly asd.Vector2DF targetPositionA = new asd.Vector2DF(240, 120);
        private readonly asd.Vector2DF targetPositionB = new asd.Vector2DF(480, 120);
        private asd.Layer2D gameLayer;

        public EnemyShot.Type typ;
        private int count = 0;
        private int hp = 10;
    }
}
