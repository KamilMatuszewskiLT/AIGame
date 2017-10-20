/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-26
 * Time: 20:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
namespace mapa
{
	/// <summary>
	/// Description of CommandLine.
	/// </summary>
	public class CommandLine
	{
		private String input;
		
		public CommandLine()
		{
			input = "";
		}
		
		public void DrawCommandMenu(List<Agent.Weapon> wpnList, List<Agent.Creature> crtList, OperacjeMapy.Pole[,] mapa, List<Agent.Resource> resourcesList)
		{
			Point coords;
			bool coordsIsOK = true;
			while (input != "1") {
				Console.WriteLine("\n");
				Console.WriteLine("1. Exit command menu.");
				Console.WriteLine("2. Spawn an item.");
				Console.WriteLine("3. Spawn a creature.");
				Console.WriteLine("4. Spawn a mapEntity.");
				input = Console.ReadLine();
				switch (input) {
					case "1":
						{
							
							break;
						}
					case "2":
						{
							var spawner = new ItemSpawner();
							string whichItem;
							Console.WriteLine("Which kind of item would you like to spawn?\n 1.Weapon\n 2.null");
							whichItem = Console.ReadLine();
							switch (whichItem) {
								case"1":
									{
										Console.WriteLine("Which weapon would you like to spawn (type in ID number for answer):");
										int i = 0;
										foreach (Agent.Weapon wpn in wpnList) {
											Console.WriteLine("ID: {4}\t{0}\tMinDamage: {1}\tMaxDamage: {2}\tWeaponLength: {3}\n", wpn.name, wpn.minDamage, wpn.maxDamage, wpn.weaponLength, i);
											i++;
										}
										int wpnID = Convert.ToInt16(Console.ReadLine());
										var answerWeapon = new Agent.Weapon();
										answerWeapon = wpnList[wpnID];
										
										Console.WriteLine("Would you like to spawn the weapon to a creatures inventory(1) or on the map(2)?");
										string answer = Console.ReadLine();

										switch (answer) {
											case "1":
												{
													
													break;
												}
											case "2":
												{
													//do{
													Console.WriteLine("Where would you like to spawn the weapon (coord x and y):");
													int x, y;
													x = Convert.ToInt16(Console.ReadLine());
													y = Convert.ToInt16(Console.ReadLine());
													coords = new Point(y--, x--);
													
													spawner.SpawnWeapons(coords, answerWeapon, mapa);
													//}while(coordsIsOK);
													break;
												}
											default:
												{
													break;
												}
										}
										
										break;
									}
									
								case"2":
									{
										break;
									}									
							}
							break;
						}
					case "3":
						{
							
							var spawner = new CreatureSpawner();
							Console.WriteLine("Which creature would you like to spawn (type in ID number for answer):");
							int i = 0;
							foreach (Agent.Creature crt in crtList) {
								Console.WriteLine("ID: {1}\t{0}\n", crt.name, i);
								i++;
							}
							int crtID = Convert.ToInt16(Console.ReadLine());
							var answerCreature = new Agent.Creature();
							answerCreature = crtList[crtID];
							//do{
							Console.WriteLine("Where would you like to spawn the creature (coord x and y):");
							int x, y;
							x = Convert.ToInt16(Console.ReadLine());
							y = Convert.ToInt16(Console.ReadLine());
							coords = new Point(y--, x--);
							
							spawner.SpawnCreature(coords, answerCreature, mapa);
							//}while(coordsIsOK);
							break;
						}
					default:
						{
							break;
						}
				}
				break;
			}
			
		}
		
		
	}
}

