/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-26
 * Time: 20:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace mapa
{
	/// <summary>
	/// Description of ItemSpawner.
	/// </summary>
	public class ItemSpawner
	{
		
		public int coordX;
		public int coordY;
			
		public ItemSpawner()
		{
			coordX = 0;
			coordY = 0;
		}
		
		// Spawn weapon into coordinates x,y;
		public void SpawnWeapons(Point coords, Agent.Weapon weapon, OperacjeMapy.Pole[,] map){		
			map[coords.X,coords.Y].Items.Add(weapon);
			Console.WriteLine("Spawning {0} to X{1},Y{2}.",weapon.name,coords.X,coords.Y);
		}
		public void SpawnWeapons(Agent.Creature creature, Agent.Weapon weapon, OperacjeMapy.Pole[,] map){		
			for(int i = 0; i<map[creature.currentpossition.X,creature.currentpossition.Y].Creature.Count;i++){
				if(map[creature.currentpossition.X,creature.currentpossition.Y].Creature[i]==creature){
				map[creature.currentpossition.X,creature.currentpossition.Y].Creature[i].inventory.Add(weapon);
				}
			}
			Console.WriteLine("Spawning {0} to {1}s inventory.",weapon.name,creature.name);
		}
		public void SpawnItem(Point coords, Agent.Item item, OperacjeMapy.Pole[,] map){
			bool added = false;
			if(item.isStackable){
				foreach(Agent.Item i in map[coords.X,coords.Y].Items){
					if(i.name == item.name && i.stackSize<255){
						i.stackSize++;
						added = true;
						break;
					}  
				}
				if(!(added)){
				map[coords.X,coords.Y].Items.Add(item);
				}
			}
			Console.WriteLine("Spawning {0} to X{1},Y{2}.",item.name,coords.X,coords.Y);
		}
		public byte SpawnItem(Point coords, Agent.Item item, OperacjeMapy.Pole[,] map, byte stackSize){
			bool done = false;
			item.stackSize=stackSize;
			if (!(item.isStackable)){ Console.WriteLine("Item [{0}] is not stackable.",item.name);
				return 0;
			} else {
				foreach(Agent.Item i in map[coords.X,coords.Y].Items){
					
					if(i.name == item.name && i.stackSize+item.stackSize<=255){
						i.stackSize+=item.stackSize;
						done=true;
						break;
					} else if(i.name==item.name){
						
						item.stackSize-=Convert.ToByte(255-i.stackSize);
						i.stackSize=255;
						
					
					} if(item.stackSize==0){
						done=true;
						break;
					}
					
				}
				if(!(done)) map[coords.X,coords.Y].Items.Add(item);
				
			}
			Console.WriteLine("Spawning {0} to X{1},Y{2}.",item.name,coords.X,coords.Y);
			return 1;
		}
		
	}
}
