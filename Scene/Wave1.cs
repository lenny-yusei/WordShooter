﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordShooter.Scene
{
    class Wave1 : Game
    {
        private Charactor.Enemy enemy1;
        private Charactor.Enemy enemy2;
        asd.Vector2DF pos1 = new asd.Vector2DF(280f, 30f);
        asd.Vector2DF pos2 = new asd.Vector2DF(480f, 0f);

        public Wave1()
        {
            char c = getRandomChar();

            System.Console.WriteLine(c);
            enemy1 = new Charactor.Enemy(gameLayer, 'Z', pos1, Charactor.EnemyShot.Type.t1);
            gameLayer.AddObject(enemy1);
            enemy2 = new Charactor.Enemy(gameLayer, 'A', pos2, Charactor.EnemyShot.Type.t2);
            gameLayer.AddObject(enemy2);
        }

        protected override void OnUpdated()
        {
            if (!enemy1.IsAlive && !enemy2.IsAlive)
                asd.Engine.ChangeScene(new Scene.Wave2(player));
            if (!player.IsAlive)
                asd.Engine.ChangeScene(new Scene.GameOver());
            CollisionPlayerAndBullet();
        }
    }
}
