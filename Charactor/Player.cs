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

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = (asd.Keys)(i + 19);//asd.KeysのAからZ
            }
        }

        protected override void OnUpdate()
        {
            var position = this.Position;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold
                && Texture.Size.Y >= 0)
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
            return (bullet.Position - Position).Length < 5;
        }
        public void damage()
        {
            hp--;
            if (hp <= 0)
                Dispose();
        }
        void pushedKey()
        {
            /*
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
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.G) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'G'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.H) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'H'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.I) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'I'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.J) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'J'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.K) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'K'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.L) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'L'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.M) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'M'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.N) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'N'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.O) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'O'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.P) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'P'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Q) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'Q'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.R) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'R'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.S) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'S'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.T) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'T'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.U) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'U'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.V) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'V'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.W) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'W'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.X) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'X'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Y) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'Y'));
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                gameLayer.AddObject(new Charactor.Shot(Position, 'Z'));
            */
            for (int i = 0; i < words.Length; i++)
            {
                if (asd.Engine.Keyboard.GetKeyState(words[i]) == asd.KeyState.Push)
                {
                    char word = (char)((int)'A' + i);
                    gameLayer.AddObject(new Charactor.Shot(Position, word));
                }

            }
            System.Console.WriteLine(words[0]);
            
        }

        private asd.Vector2DF Size { get; } = new asd.Vector2DF(64.0f, 128.0f);
        private const float speed = 5;
        private int hp = 3;
        private asd.Keys[] words = new asd.Keys[26];

        private asd.Layer2D gameLayer;
    }
}
