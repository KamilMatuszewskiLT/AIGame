/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-26
 * Time: 19:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace mapa
{
	/// <summary>
	/// Description of CreatureSpawner.
	/// </summary>
	public class CreatureSpawner
	{
		public int coordX;
		public int coordY;
			
		public CreatureSpawner()
		{
			coordX = 0;
			coordY = 0;
		}
		
		// Spawn creature into coordinates x,y;
		public void SpawnCreature(Point pos, Agent.Creature creature, OperacjeMapy.Pole[,] mapa){		
			mapa[pos.X,pos.Y].Creature.Add(creature);
			mapa[pos.X,pos.Y].passable=false;
			Console.WriteLine("Spawning {0} to X{1},Y{2}.",creature.name,pos.X,pos.Y);
		}
	}
}
