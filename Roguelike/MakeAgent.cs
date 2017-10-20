/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-05-15
 * Time: 16:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace mapa
{
	
	public class MakeAgent
	{
		
		public Agent.Creature MakeCreature(Agent.Creature creature, 
		                                   string name, 
		                                   byte HP, 
		                                   byte fighting ,
		                                   char type, 
		                                   byte bravery,
		                                   byte charisma,
		                                   byte agility,
		                                   byte initiative,
		                                   byte inteligence,
		                                   byte strength,
		                                   byte morale,
		                                   byte visualrange,
		                                   AILoop.AIType aiType
		                                  )
		{
			
			creature.attributes.AIType = aiType;
			creature.attributes.bravery = bravery;
			creature.attributes.charisma = charisma;
			creature.attributes.agility = agility;
			creature.attributes.HP = HP;
			creature.attributes.initiative = initiative;
			creature.attributes.inteligence = inteligence;
			creature.attributes.morale = morale;
			creature.attributes.strength = strength;
			creature.attributes.fighting = fighting;
			creature.name = name;
			creature.type = type;
			creature.attributes.visualrange = visualrange;
			return creature;
		}
		
		public OperacjeMapy.Pole[,] InsertCreature(Agent.Creature creature, int x, int y, OperacjeMapy.Pole[,] mapa)
		{
			
			if (!mapa[x, y].passable) {
				Console.WriteLine("W polu o współrzędnych [{0},{1}] nie można wstawić agenta. \nPodaj nowe współrzędne:", x, y);
				int k, j;
				k = Convert.ToInt16(Console.ReadLine());
				j = Convert.ToInt16(Console.ReadLine());
				InsertCreature(creature, --k, --j, mapa);
			} else {
				creature.currentpossition = new Point (x,y);
				mapa[x, y].Creature.Add(creature);
				mapa[x, y].passable=false;
				Console.WriteLine("wsadzam na pozycji [{0}] [{1}] ",creature.currentpossition.X, creature.currentpossition.Y);
			}
			
			return mapa;
		}
		
		
		
	}
}
