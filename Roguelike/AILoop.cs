/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-29
 * Time: 15:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace mapa
{
	/// <summary>
	/// Description of AILoop.
	/// </summary>
	public class AILoop
	{
		
		public List<Agent.Creature> AllCreatures;
		public OperacjeMapy.Pole[,] mapa;
		
		public enum AIType{
			BasicAi, Null
		};
		
		public AILoop(OperacjeMapy.Pole[,] mapa)
		
		{
			AllCreatures = new List<Agent.Creature>();
			this.mapa = mapa;
		}
		
		public void CallAIs ()
		{
			AllCreatures.Sort((x, y) => y.attributes.initiative.CompareTo(x.attributes.initiative));
			
			foreach (Agent.Creature creature in AllCreatures){
					var ai = new BasicAIDij();
					ai.InitializeAI(creature, mapa);
					//Console.WriteLine("My AI was initialized: {0}", creature.name);
				}
			}
			
		}
		
	}

