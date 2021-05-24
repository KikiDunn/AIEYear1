using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathLibrary;


namespace Project2D
{
    class Game
    {
		//objects and variables declared
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;
		GameObject world;
		GameObject topCollider;
		GameObject bottomCollider; 
		GameObject leftCollider; 
		GameObject rightCollider;
		Tank player;
		CollisionManager collisionManager;
		public Game()
        {
        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

			//Initialize objects here
			collisionManager = new CollisionManager();
			world = new GameObject("");

			topCollider = new GameObject("");
			bottomCollider = new GameObject("");
			leftCollider = new GameObject("");
			rightCollider = new GameObject("");

			topCollider.collidable = true;
			topCollider.collider = new Vector2(1920/2, 30);
			topCollider.SetPosition(new Vector2(1920 / 2, -30));
			bottomCollider.collidable = true;
			bottomCollider.collider = new Vector2(1920 / 2, 30);
			bottomCollider.SetPosition(new Vector2(1920 / 2, 1080+ 30));
			leftCollider.collidable = true;
			leftCollider.collider = new Vector2(30, 1080);
			leftCollider.SetPosition(new Vector2(1920 + 30, 1080/2));
			rightCollider.collidable = true;
			rightCollider.collider = new Vector2(30, 1080);
			rightCollider.SetPosition(new Vector2(-30, 1080/2));

			player = new Tank("../Images/tank.png");
			player.SetPosition(new Vector2(1920 / 2, 1080 / 2));
			collisionManager.Add(player);

			collisionManager.Add(topCollider);
			collisionManager.Add(bottomCollider); 
			collisionManager.Add(leftCollider); 
			collisionManager.Add(rightCollider);
			world.AdoptChild(player);
		}

        public void Shutdown()
        {
        }

        public void Update()
        {
			//calculates delta time
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

			//goes through the heirarchy and updates all the objects 
			world.UpdateTransforms();
			world.Update(deltaTime);
			//checks all collisions
			collisionManager.Update();
		}

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(RLColor.WHITE);

			//Draw game objects here
            DrawText(fps.ToString(), 10, 10, 14, RLColor.RED);

			//DrawTexture(texture, GetScreenWidth() / 2 - texture.width / 2, GetScreenHeight() / 2 - texture.height / 2, RLColor.WHITE);
			world.Draw();
			EndDrawing();
			
        }

    }
}
