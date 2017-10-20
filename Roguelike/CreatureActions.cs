/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-05-24
 * Time: 15:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace mapa
{
	/// <summary>
	/// Description of MoveCreature.
	/// </summary>
	public class CreatureActions
	{
		public CreatureActions()
		{
		}
		
		public OperacjeMapy.Pole[,] MoveCreature(Point whereTo, OperacjeMapy.Pole[,] mapa, Agent.Creature creature)
		{
			mapa[whereTo.X, whereTo.Y].Creature.Add(creature);
			mapa[whereTo.X, whereTo.Y].passable = false;
			Console.WriteLine();
			Console.WriteLine("Adding creature to [{0}],[{1}]", whereTo.X, whereTo.Y);
			
			mapa[creature.currentpossition.X, creature.currentpossition.Y].Creature.Remove(creature);
			mapa[creature.currentpossition.X, creature.currentpossition.Y].passable = true;
			Console.WriteLine("Removing creature from [{0}],[{1}]", creature.currentpossition.X, creature.currentpossition.Y);
			
			mapa[whereTo.X, whereTo.Y].Creature[0].currentpossition = whereTo;
			Console.WriteLine("Adding currposs [,] to [{0}],[{1}]", creature.currentpossition.X, creature.currentpossition.Y);
			
			return mapa;
		}
		
		
		
	}
	
	
}

