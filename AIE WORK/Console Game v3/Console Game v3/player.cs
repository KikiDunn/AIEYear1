using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
class Player
{
	int ID;
	int ID2;
	bool togglev;
	bool fire = false;
	BufferEngine engine;
	int[,] frame1;
	int[,] frame2;
	int[,] frame3;
	int[,] frame4;
	int[,] defaultf;
	int lasers = 100;
	int LID;
	double[] lx;
	double[] ly;
	double[] la;

	public Player(BufferEngine engine, int[,] playerSprite, int[,] playerSprite2, int[,] playerSprite3, int[,] playerSprite4, int[,] playerSprite5, int[,] playerSprite6, int[,] laser)
	{
		lx = new double[lasers];
		ly = new double[lasers];
		la = new double[lasers];
		this.engine = engine;
		ID = engine.addSprite(playerSprite, 0, 0, false);
		ID2 = engine.addSprite(playerSprite2, 0, 0, false);
		LID = engine.addParticle(laser, lx, ly, true, lasers);
		frame1 = playerSprite3;
		frame2 = playerSprite4;
		frame3 = playerSprite5;
		frame4 = playerSprite6;
		defaultf = playerSprite2;
		togglev = false;
		animate();
		
	}
	public void moveUp()
	{
		engine.moveSprite(ID, Math.Cos((engine.getAngle(ID)-90)*Math.PI/180)*5, Math.Sin((engine.getAngle(ID) - 90) * Math.PI / 180)*5);
		engine.moveSprite(ID2, Math.Cos((engine.getAngle(ID) - 90) * Math.PI / 180) * 5, Math.Sin((engine.getAngle(ID) - 90) * Math.PI / 180) * 5);
	}
	public void moveDown()
	{
		engine.moveSprite(ID, -Math.Cos((engine.getAngle(ID) - 90) * Math.PI / 180)*5, -Math.Sin((engine.getAngle(ID) - 90) * Math.PI / 180)*5);
		engine.moveSprite(ID2, -Math.Cos((engine.getAngle(ID) - 90) * Math.PI / 180) * 5, -Math.Sin((engine.getAngle(ID) - 90) * Math.PI / 180) * 5);
	}
	public void moveLeft()
	{
		engine.moveSprite(ID, -2.5, 0);
	}
	public void moveRight()
	{
		engine.moveSprite(ID, 2.5, 0);
	}
	public void rotateLeft()
	{
		engine.rotateSprite(ID, -5);
		if (togglev)
		{
			rotateTLeft();
		}
	}
	public void rotateRight()
	{
		engine.rotateSprite(ID, 5);
		if (togglev)
		{
			rotateTRight();
		}
	}
	public void rotateTLeft()
	{
		engine.rotateSprite(ID2, -5);
	}
	public void rotateTRight()
	{
		engine.rotateSprite(ID2, 5);
	}
	public void shoot()
	{
		fire = true;
	}
	public void toggle()
	{
		if (togglev)
		{
			togglev = false;
		}
		else
		{
			togglev = true;
		}
	}
	public void animate()
	{
		new Thread(() =>
		{
			while (true)
			{
				Thread.CurrentThread.IsBackground = true;
				if (fire)
				{
					engine.changeFrame(ID2, frame1);
					Thread.Sleep(300);
					engine.changeFrame(ID2, frame2);
					Thread.Sleep(300);
					engine.changeFrame(ID2, frame3);
					Thread.Sleep(300);
					engine.changeFrame(ID2, frame4);
					Thread.Sleep(300);
					engine.hideParticle(LID, false);
					
					int laserfired = 0;
					for(int i = 0; i < lasers; i++)
					{
						lx[i] = engine.getSpriteX(ID) + 80;
						ly[i] = engine.getSpriteY(ID) + 120;
						la[i] = engine.getAngle(ID2);
					}
					engine.setPose(LID, lx, ly, la);
					Stopwatch sw = new Stopwatch();
					sw.Start();
					while (sw.ElapsedMilliseconds < 5000)
					{
						if (laserfired < lasers)
						{
							la[laserfired] = engine.getAngle(ID2);
							lx[laserfired] = engine.getSpriteX(ID) + 80;
							ly[laserfired] = engine.getSpriteY(ID) + 120;
							laserfired++;
						}
						
						
						for (int i = 0; i < laserfired; i++)
						{
							lx[i] += Math.Cos((la[i] - 90) * Math.PI / 180) * 20;
							ly[i] += Math.Sin((la[i] - 90) * Math.PI / 180) * 20;
						}
						Thread.Sleep(10);
						
					}
					engine.hideParticle(LID, true);
					engine.changeFrame(ID2, defaultf);
					fire = false;
				}
			}
		}).Start();		
	}
}

