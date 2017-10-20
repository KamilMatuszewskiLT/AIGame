/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-29
 * Time: 19:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace mapa
{
	/// <summary>
	/// Description of IsEnemyInSight.
	/// </summary>
	public class EnemiesInSight
	{
		public GetFOV creatureFOV;
		public List<Agent.Creature> enemiesInSight;
		
		public EnemiesInSight(OperacjeMapy.Pole[,] mapa, Agent.Creature creature)
		{
			creatureFOV = new GetFOV(mapa, creature);
			enemiesInSight = new List<Agent.Creature>();
			creatureFOV.GetMyFOV();
			foreach(Point p in creatureFOV.FOVCalc.VisiblePoints){
				foreach(Agent.Creature kreatura in mapa[p.X,p.Y].Creature){
					if(kreatura.name == "player"){
						enemiesInSight.Add(kreatura);
						Console.WriteLine("Adding {0} to enemies", kreatura.name);
					}
				}
			}
		}
		
		
		
	}
}
