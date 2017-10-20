/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-29
 * Time: 19:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace mapa
{
	/// <summary>
	/// Description of EnemyInFOV.
	/// </summary>
	public class GetFOV
	{	public FOVRecurse FOVCalc;
		public OperacjeMapy.Pole[,] tab;
		public Agent.Creature creature;
		public GetFOV(OperacjeMapy.Pole[,] tab, Agent.Creature creature)
		{
			FOVCalc = new FOVRecurse();
			this.tab = tab;
			this.creature = creature;
		}

		public void GetMyFOV()
		{
			
			FOVCalc.player.Y = creature.currentpossition.X;
			FOVCalc.player.X = creature.currentpossition.Y;
			
			
			
			for (int j = 0; j < tab.GetLength(0); j++) {
				for (int i = 0; i < tab.GetLength(1); i++) {
					if (!(tab[j, i].transluscent)) {
						//	Console.Write("{0} , {1} is not transluscent", i, j);
						FOVCalc.Point_Set(i, j, 1);
					} else
						FOVCalc.Point_Set(i, j, 0);
					// Console.WriteLine();
				}
			}
			FOVCalc.VisualRange = creature.attributes.visualrange;
			FOVCalc.GetVisibleCells();
			
		}
	}
}
