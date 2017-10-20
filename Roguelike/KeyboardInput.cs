/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-05-16
 * Time: 16:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;

namespace mapa
{
	/// <summary>
	/// Ruch agenta po mapie
	/// </summary>
	public class KeyboardInput
	{
		public OperacjeMapy.Pole[,] MoveAgent(ConsoleKey keypressed, OperacjeMapy.Pole[,] mapa, Agent.Creature creature, List<Agent.Weapon> weaponList, List<Agent.Creature> creatureList, List<Agent.Resource> resourcesList)
		{
			int posX = creature.currentpossition.X;
			int posY = creature.currentpossition.Y;
			
			
			switch (keypressed) {
					
				case ConsoleKey.F1:
					{
						var cmd = new CommandLine();
						cmd.DrawCommandMenu(weaponList, creatureList, mapa, resourcesList);
						break;
					}
					
				case ConsoleKey.NumPad8:
					//Console.WriteLine("Wcisnieto górną strzałkę.");
					if (creature.currentpossition.Y == 0) {
						break;
					}
					if (mapa[posX, posY - 1].passable) {
						mapa[posX, posY - 1].Creature.Add(creature);
						mapa[posX, posY - 1].passable = false;
						creature.currentpossition = new Point(creature.currentpossition.X,creature.currentpossition.Y-1);
						mapa[posX, posY].Creature.Remove(creature);
						mapa[posX, posY].passable = true;
					}
					break;
				case ConsoleKey.NumPad2:
					//Console.WriteLine("Wcisnieto dolną strzałkę.");
					if (creature.currentpossition.Y == mapa.GetLength(1) - 1) {
						break;
					}
					if (mapa[posX, posY + 1].passable) {
						mapa[posX, posY + 1].Creature.Add(creature);
						mapa[posX, posY + 1].passable = false;
						creature.currentpossition = new Point(creature.currentpossition.X,creature.currentpossition.Y+1);
						mapa[posX, posY].Creature.Remove(creature);
						mapa[posX, posY].passable = true;
					}
					break;
				case ConsoleKey.NumPad6:
					//Console.WriteLine("Wcisnieto prawą strzałkę.");
					if (creature.currentpossition.X == mapa.GetLength(0) - 1) {
						break;
					}
					if (mapa[posX + 1, posY].passable) {
						mapa[posX + 1, posY].Creature.Add(creature);
						mapa[posX + 1, posY].passable = false;
						creature.currentpossition = new Point(creature.currentpossition.X+1,creature.currentpossition.Y);
						mapa[posX, posY].Creature.Remove(creature);
						mapa[posX, posY].passable = true;
					}
					break;
				case ConsoleKey.NumPad4:
					//Console.WriteLine("Wcisnieto lewą strzałkę.");
					if (creature.currentpossition.X == 0) {
						break;
					}
					if (mapa[posX - 1, posY].passable) {
						mapa[posX - 1, posY].Creature.Add(creature);
						mapa[posX - 1, posY].passable = false;
						creature.currentpossition = new Point(creature.currentpossition.X-1,creature.currentpossition.Y);
						mapa[posX, posY].Creature.Remove(creature);
						mapa[posX, posY].passable = true;
					}
					break;
				case ConsoleKey.NumPad7:
					//Console.WriteLine("Wcisnieto górną-lewą strzałkę.");
					if (creature.currentpossition.X == 0 || creature.currentpossition.Y == 0) {
						break;
					}
					if (mapa[posX - 1, posY - 1].passable) {
						mapa[posX - 1, posY - 1].Creature.Add(creature);
						mapa[posX - 1, posY - 1].passable = false;
						creature.currentpossition = new Point(creature.currentpossition.X-1,creature.currentpossition.Y-1);
						mapa[posX, posY].Creature.Remove(creature);
						mapa[posX, posY].passable = true;
					}
					break;
				case ConsoleKey.NumPad1:
					//Console.WriteLine("Wcisnieto dolną-lewą strzałkę.");
					if (creature.currentpossition.X == 0 || creature.currentpossition.Y == mapa.GetLength(1) - 1) {
						break;
					}
					if (mapa[posX - 1, posY + 1].passable) {
						mapa[posX - 1, posY + 1].Creature.Add(creature);
						mapa[posX - 1, posY + 1].passable = false;
						creature.currentpossition = new Point(creature.currentpossition.X-1,creature.currentpossition.Y+1);
						mapa[posX, posY].Creature.Remove(creature);
						mapa[posX, posY].passable = true;
					}
					break;
				case ConsoleKey.NumPad9:
					//Console.WriteLine("Wcisnieto górną-prawą strzałkę.");
					if (creature.currentpossition.X == mapa.GetLength(0) - 1 || creature.currentpossition.Y == 0) {
						break;
					}
					if (mapa[posX + 1, posY - 1].passable) {
						mapa[posX + 1, posY - 1].Creature.Add(creature);
						mapa[posX + 1, posY - 1].passable = false;
						creature.currentpossition= new Point(creature.currentpossition.X+1,creature.currentpossition.Y-1);
						mapa[posX, posY].Creature.Remove(creature);
						mapa[posX, posY].passable = true;
					}
					break;
				case ConsoleKey.NumPad3:
					//Console.WriteLine("Wcisnieto dolną-prawą strzałkę.");
					if (creature.currentpossition.X == mapa.GetLength(0) - 1 || creature.currentpossition.Y == mapa.GetLength(1) - 1) {
						break;
					}
					if (mapa[posX + 1, posY + 1].passable) {
						mapa[posX + 1, posY + 1].Creature.Add(creature);
						mapa[posX + 1, posY + 1].passable = false;
						creature.currentpossition = new Point(creature.currentpossition.X+1,creature.currentpossition.Y+1);
						mapa[posX, posY].Creature.Remove(creature);
						mapa[posX, posY].passable = true;
					}
					break;
				case ConsoleKey.NumPad5:
					//Console.WriteLine("Wcisnieto środkową strzałkę.");
					
					break;
			/*
				default:
					Console.WriteLine("ConsoleKey pressed value is not a strzałka ;(");
					break;
					 */
			}
			return mapa;
		}
		
		
	}
}
