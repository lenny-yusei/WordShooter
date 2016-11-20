using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShooter.Charactor
{
    sealed class Player : asd.TextureObject2D
    {
        public Player(asd.Layer2D layer)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resource/myship.png");
            Scale = new asd.Vector2DF(2, 2);
            CenterPosition = Texture.Size.To2DF() / 2;
            Position = Resource.Window.Size.To2DF() / 2;

            gameLayer = layer;
        }

        protected override void OnUpdate()
        {
            var position = this.Position;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
                position.Y -= speed;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
                position.Y += speed;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
                position.X -= speed;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
                position.X += speed;
            this.Position = position;

            pushedKey();
        }

        public bool IsHit(Bullet bullet)
        {
            return (bullet.Position - Position).Length < 4;
        }
        public void damage()
        {
            hp--;
            if (hp < 0)
                Dispose();
        }
        void pushedKey()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.A) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'A'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.B) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'B'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.C) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'C'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.D) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'D'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.E) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'E'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.F) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'F'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'Z'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.X) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'X'));
        }

        private asd.Vector2DF Size { get; } = new asd.Vector2DF(64.0f, 128.0f);
        private const float speed = 5;
        private int hp = 3;

        private asd.Layer2D gameLayer;
    }
}
