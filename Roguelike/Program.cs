/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-05-13
 * Time: 11:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using mapa;
using System.Collections.Generic;
using System.Drawing;
using mapa.CreaturesToDo;
using mapa.Needs;
using mapa.Places;

public class Program
{
	
	
	
	public static void Main()
	{
		
		int x=12;
		int y=12;   // map dimmensions, also change in FOV class
		
		int turntimer = 0;
		
		
		OperacjeMapy.Pole[,] mapa = new OperacjeMapy.Pole[x,y];
		var items = new MakeItems();
		items.MakeWeapons();
		items.MakeResources();
		var creatures = new MakeCreatures();
		creatures.MakeCreaturesList();
		var mapFields = new MakeMapFields();
		mapFields.MakeFieldsForMap();
		OperacjeMapy mapbuilder = new OperacjeMapy(mapFields);
		var mapEntities = new MakeMapEntities();
		mapEntities.MakeMapEntitiesList();
		
		
		//mapbuilder.NonRandPopulate(mapa);
		mapbuilder.Populate(mapa);
		mapbuilder.Draw(mapa);
		mapbuilder.PopulateWithMapEntities(mapa,mapEntities.entitiesList);
		mapbuilder.Draw(mapa);
		
		
		Console.WriteLine("");
		Console.WriteLine("x = {0} y = {1}",mapa.GetLength(0),mapa.GetLength(1));
		MakeAgent agentspawner = new MakeAgent();
		Console.WriteLine("Gdzie wsadzić gracza?");
		int x2,y2;
		x2=Convert.ToInt16(Console.ReadLine());
		y2=Convert.ToInt16(Console.ReadLine());
		
		
		Console.WriteLine("Gdzie wsadzić monstera?");
		int x3,y3;
		x3=Convert.ToInt16(Console.ReadLine());
		y3=Convert.ToInt16(Console.ReadLine());
		
		Agent.Creature player = new Agent.Creature();
		
	    Agent.Creature monster = new Agent.Creature();
		
		agentspawner.MakeCreature(player, "player", 100, 12,'@',15,15,12,10,10,12,10,2,AILoop.AIType.Null);
		
		agentspawner.MakeCreature(monster, "monster", 100, 10,'M',10,10,8,10,10,8,10,5,AILoop.AIType.BasicAi);

		agentspawner.InsertCreature(player, --x2,--y2,mapa);
		mapbuilder.Draw(mapa);
		agentspawner.InsertCreature(monster, --x3,--y3,mapa);
		
	//	Console.WriteLine("player currpos is [{0}],[{1}]", player.currentpossition.X, player.currentpossition.Y);
	//	Console.WriteLine("Creature currpos is [{0}],[{1}]", monster.currentpossition.X, monster.currentpossition.Y);
		
	//	Console.WriteLine("\n");			
	
		//mapbuilder.Draw(mapa);
		
		KeyboardInput KeyboarbListener= new KeyboardInput();
		
		BasicAIDij ai = new BasicAIDij();
		var aiLoop = new AILoop(mapa);
		aiLoop.AllCreatures.Add(monster);
		
	//	Console.WriteLine("Press <Escape> to exit... ");
		
		var asd = new FindEntity(mapa,player,"tree", FindEntity.KindOfEntity.mapEntity);
		asd.FindNearestEntity();
		foreach(Point p in asd.entitiesFound){
			Console.WriteLine("Tree poss X{0}, Y{1}",p.X+1,p.Y+1);
		}
		foreach(Point p in asd.nearestEntities){
			Console.WriteLine("Nearest tree poss X{0}, Y{1}",p.X+1,p.Y+1);
		}
	
	
		while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)) {
			//keypressed = Console.ReadKey().Key;
			//if (Console.ReadKey().Key == ConsoleKey.LeftArrow || Console.ReadKey().Key == ConsoleKey.RightArrow || Console.ReadKey().Key == ConsoleKey.UpArrow || Console.ReadKey().Key == ConsoleKey.DownArrow){
				
			KeyboarbListener.MoveAgent(Console.ReadKey().Key, mapa, player,items.weaponsList, creatures.creaturesList, items.resourcesList);
			turntimer++;
			//Console.Clear();
		//	Console.WriteLine("Player AI is: {0}.", player.attributes.AIType);
			aiLoop.CallAIs();
			
			
		//	Console.WriteLine("Creature currpos is [{0}],[{1}]", monster.currentpossition.X, monster.currentpossition.Y);
		//	Console.WriteLine("Player currpos is [{0}],[{1}]", player.currentpossition.X, player.currentpossition.Y);
			
			//mapbuilder.Draw(mapa);
			
			mapbuilder.DrawFOV(mapa, player.currentpossition.X, player.currentpossition.Y, player.attributes.visualrange);
			//mapbuilder.DrawPassable(mapa);
			//mapbuilder.DRAWCreatureCoun(mapa);
			
			}
			
		}
	}
//}
