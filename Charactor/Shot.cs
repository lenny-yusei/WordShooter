using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShooter.Charactor
{
    sealed class Shot : asd.TextureObject2D
    {
        public Shot(asd.Vector2DF pos, char wordtype)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resource/plbullet.png");
            Scale = new asd.Vector2DF(Size.X / Texture.Size.X, Size.Y / Texture.Size.Y);
            CenterPosition = Texture.Size.To2DF() / 2;
            Position = pos;
            this.shotType = wordtype;
        }

        protected override void OnUpdate()
        {
            Position += new asd.Vector2DF(0.0f, -speed);
            if (Position.Y < 0)
                Dispose();
        }

        public char shotType;
        private asd.Vector2DF Size { get; } = new asd.Vector2DF(16.0f, 32.0f);
        private const float speed = 6;
    }
}
