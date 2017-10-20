/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-05-13
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace mapa
{
	
	public class OperacjeMapy
	{
		MakeMapFields mapFields;
		public OperacjeMapy(MakeMapFields mapFields)
		{
			this.mapFields = mapFields;
		}
		
		public class Pole
		{
			public string name { get; set; }
			public char type { get; set; }
			// Frequency of occurence - Prawdopobienstwo stworzenia nowe pola, jezeli sasiad jest polem INNEGO typu.
			public byte foo { get; set; }
			// Weight - Prawdopobienstwo stworzenia nowe pola, jezeli sasiad jest polem TEGO SAMEGO typu.
			public byte weight { get; set; }
			public bool passable { get; set; }
			public bool transluscent { get; set; }
			public List<Agent.Creature> Creature { get; set; }
			public List<Agent.Item> Items { get; set; }
			public Agent.MapEntity mapEntities { get; set; }
			public bool isExplored { get; set; }
			public ConsoleColor colour { get; set; }
			
			public Pole()
			{
				name = "null";
				type = '!';
				foo = 0;
				weight = 0;
				passable = false;
				Creature = new List<Agent.Creature>();
				Items = new List<Agent.Item>();
				mapEntities = new Agent.MapEntity();
				transluscent = true;
				isExplored = false;
				colour = ConsoleColor.Black;
			}
			
			public Pole(OperacjeMapy.Pole pole)
			{
				name = pole.name;
				type = pole.type;
				foo = pole.foo;
				weight = pole.weight;
				passable = pole.passable;
				Creature = new List<Agent.Creature>();
				Items = new List<Agent.Item>();
				mapEntities = new Agent.MapEntity();
				transluscent = pole.transluscent;
				isExplored = false;
				colour = pole.colour;
			}
		}
		
		
		
		Pole[] RodzajePol(Pole[] obiekty)
		{
			
			Pole drzewo = new Pole();
			Pole nic = new Pole();
			
			drzewo.name = "drzewo";
			drzewo.type = 'T';
			drzewo.foo = 0;
			drzewo.weight = 0;
			drzewo.passable = false;
			List<Agent.Creature> creature = new List<Agent.Creature>();
			drzewo.Creature = creature;
			List<Agent.Item> items = new List<Agent.Item>();
			drzewo.Items = items;
			drzewo.transluscent = false;
			drzewo.colour = ConsoleColor.Green;
			nic.name = "Nic";
			nic.type = '_';
			nic.foo = 60;
			nic.weight = 60;
			nic.passable = true;
			nic.Creature = creature;
			nic.Items = items;
			nic.colour = ConsoleColor.White;
			nic.transluscent = true;
			obiekty[0] = drzewo;
			obiekty[1] = nic;
			
			return obiekty;
			
		}
		
		private class Chance
		{
			public Pole pole { get; set; }
			public byte chance{ get; set; }
			public Chance()
			{
				pole = new Pole();
				chance = 0;
			}
			
		}
		
		Pole UstawPole(List<OperacjeMapy.Pole> obiekty, Pole polewej, Pole ponad)
		{
			byte[] szansa = new byte[obiekty.Count];
			Chance next = new Chance();
			Random r = new Random(Guid.NewGuid().GetHashCode());
			if (polewej == null) {
				for (int i = 0; i < obiekty.Count; i++) {
					if (obiekty[i] == polewej)
						szansa[i] = obiekty[i].weight;
					else
						szansa[i] = obiekty[i].foo;
				}
			} else if (ponad == null) {
				for (int i = 0; i < obiekty.Count; i++) {
					if (obiekty[i] == ponad)
						szansa[i] = obiekty[i].weight;
					else
						szansa[i] = obiekty[i].foo;
				}
			} else {
				for (int i = 0; i < obiekty.Count; i++) {
					if (obiekty[i] == polewej || obiekty[i] == ponad)
						szansa[i] = obiekty[i].weight;
					else
						szansa[i] = obiekty[i].foo;
				}
			}
			
			
			//next.pole = obiekty[0];
			next.chance = szansa[0];
			int k = 0;
			for (int i = 1; i < obiekty.Count; i++) {
				int x = r.Next(1, 100);
				int y = r.Next(1, 100);
				if (next.chance + x < szansa[i] + y) {
					//next.pole = obiekty[i];
					next.chance = szansa[i];
					k = i;
				}
			}
			next.pole = new Pole(obiekty[k]);
			return next.pole;
		}
		
		
		public Pole[,] Populate(Pole[,] tab)
		{
			
			Random r = new Random();
			
			for (int j = 0; j < tab.GetLength(1); j++) {
				for (int i = 0; i < tab.GetLength(0); i++) {
					Pole nastepny = new Pole();
					if (i == 0 && j == 0) {
						int x = r.Next(mapFields.mapFieldsList.Count);
						while (mapFields.mapFieldsList[x].foo == 0) {
							x = r.Next(mapFields.mapFieldsList.Count);
						}
						nastepny = mapFields.mapFieldsList[x];
						tab[i, j] = nastepny;
					} else if (i == 0) {
						nastepny = UstawPole(mapFields.mapFieldsList, tab[i, j - 1], null);
						tab[i, j] = nastepny;
					} else if (j == 0) {
						nastepny = UstawPole(mapFields.mapFieldsList, null, tab[i - 1, j]);
						tab[i, j] = nastepny;
					} else {
						nastepny = UstawPole(mapFields.mapFieldsList, tab[i, j - 1], tab[i - 1, j]);
						tab[i, j] = nastepny;
					}
				}
				
			}
			
			
			return tab;
		}
		
		public Pole[,] PopulateWithMapEntities(Pole[,] tab, List<Agent.MapEntity> mapEntitiesList)
		{
			
			Random r = new Random(Guid.NewGuid().GetHashCode());
			for (int j = 0; j < tab.GetLength(1); j++) {
				for (int i = 0; i < tab.GetLength(0); i++) {
					
					var entity = new Agent.MapEntity();
					entity.name = mapEntitiesList[0].name;
					entity.currentpossition = new Point(i,j);
					entity.HP= mapEntitiesList[0].HP;
					entity.passable=mapEntitiesList[0].passable;
					entity.transluscent=mapEntitiesList[0].passable;
					entity.type=mapEntitiesList[0].type;
					entity.family=mapEntitiesList[0].family;
					
					var k = r.Next(1, 100);
					if (k > 80) {
						tab[i, j].mapEntities = entity;
						if (!(mapEntitiesList[0].passable)) {
							tab[i, j].passable = false;
						}
						if (!(mapEntitiesList[0].transluscent)) {
							tab[i, j].transluscent = false;
						}
					}
				}
			}
			
			
			return tab;
		}
		
		public Pole[,] NonRandPopulate(Pole[,] tab)
		{
			
			Random r = new Random(Guid.NewGuid().GetHashCode());
			int k = -1;
			for (int j = 0; j < tab.GetLength(1); j++) {
				for (int i = 0; i < tab.GetLength(0); i++) {
					k++;
					Pole[] obiekty = new Pole[2];
					RodzajePol(obiekty);
					Pole nastepny = new Pole();
					string textmap = File.ReadAllText(@"textmap.txt", Encoding.UTF8);
					var map = textmap.ToCharArray();
					if (map[k] == '1') {
						tab[i, j] = obiekty[0];
					} else if (map[k] == '0') {
						tab[i, j] = obiekty[1];
					} else
						tab[i, j] = obiekty[1];
				}
				
			}
			
			
			return tab;
		}
		
		public void Draw(Pole[,] tab)
		{
			for (int j = 0; j < tab.GetLength(1); j++) {
				for (int i = 0; i < tab.GetLength(0); i++) {
					if (tab[i, j].Creature.Count != 0) {
						Console.Write("{0}", tab[i, j].Creature[tab[i, j].Creature.Count - 1].type);
						
					} else if (tab[i, j].mapEntities.name!="item_null") {
						Console.Write("{0}", tab[i, j].mapEntities.type);
					} else if (tab[i, j].Items.Count != 0) {
						Console.Write("{0}", tab[i, j].Items[tab[i, j].Items.Count - 1].type);
					} else {
						Console.Write("{0}", tab[i, j].type);
					}
				}
				Console.WriteLine("\n");
				
				
			}
		}
		
		public void DrawPassable(Pole[,] tab)
		{
			for (int j = 0; j < tab.GetLength(1); j++) {
				for (int i = 0; i < tab.GetLength(0); i++) {
					if (tab[i, j].passable)
						Console.Write("0");
					else
						Console.Write("1");
					
				}
				Console.WriteLine("\n");
			}
		}
		public void DRAWCreatureCoun(Pole[,] tab)
		{
			for (int j = 0; j < tab.GetLength(1); j++) {
				for (int i = 0; i < tab.GetLength(0); i++) {
					Console.Write("{0}", tab[i, j].Creature.Count);
					
				}
				Console.WriteLine("\n");
			}
			
		}
		
		public void DrawFOV(Pole[,] tab, int pX, int pY, byte sightRange)
		{
			var FOVCalc = new FOVRecurse();
			FOVCalc.player.Y = pX;
			FOVCalc.player.X = pY;
			FOVCalc.VisualRange = sightRange;
			
			
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
			
			FOVCalc.GetVisibleCells();
			
			for (int j = 0; j < tab.GetLength(1); j++) {
				for (int i = 0; i < tab.GetLength(0); i++) {
					Point xy = new Point();
					xy.X = j;
					xy.Y = i;
					Console.ForegroundColor = tab[i, j].colour;
					if(tab[i,j].mapEntities.name!="item_null"){
						Console.ForegroundColor = ConsoleColor.Green;
					}
					if (FOVCalc.VisiblePoints.Contains(xy)) {
						tab[i, j].isExplored = true;
						if (tab[i, j].Creature.Count != 0) {
							Console.Write("{0}", tab[i, j].Creature[tab[i, j].Creature.Count - 1].type);
							
						} else if (tab[i, j].mapEntities.name!="item_null") {
							Console.Write("{0}", tab[i, j].mapEntities.type);
						} else if (tab[i, j].Items.Count != 0) {
							Console.Write("{0}", tab[i, j].Items[tab[i, j].Items.Count - 1].type);
						} else {
							Console.Write("{0}", tab[i, j].type);
						}
					} else if (tab[i, j].isExplored) {
						Console.ForegroundColor = ConsoleColor.Black;
						if (tab[i, j].Creature.Count != 0) {
							Console.Write("{0}", tab[i, j].Creature[tab[i, j].Creature.Count - 1].type);
						} else if (tab[i, j].mapEntities.name != "item_null") {
							Console.Write("{0}", tab[i, j].mapEntities.type);
						} else if (tab[i, j].Items.Count != 0) {
							Console.Write("{0}", tab[i, j].Items[tab[i, j].Items.Count - 1].type);
						} else {
							Console.Write("{0}", tab[i, j].type);
						}
					} else
						Console.Write("#");
				}
				Console.WriteLine();
			}
			
			
			
		}
	}
}