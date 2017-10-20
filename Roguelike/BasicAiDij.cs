/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-05-21
 * Time: 15:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace mapa
{
	/// <summary>
	/// BasicAI.
	/// </summary>
	public class BasicAIDij
	{
		public bool[,] passMap;
		public Size mapSize;
		//public OperacjeMapy mapOperator;
		public delegate int Fighters(Agent.Creature Attacker, Agent.Creature Defender);
		
		public BasicAIDij(){
			mapSize = new Size(12,12);
			passMap = new bool[mapSize.Width,mapSize.Height];
			// = new OperacjeMapy();
			
			
		}
		
		public void InitializeAI(Agent.Creature creature, OperacjeMapy.Pole[,] mapa){
			if(creature.attributes.AIType == AILoop.AIType.BasicAi){
				Console.WriteLine("My AI is BasicAi: {0}", creature.name);
				var stateMachine = new StateMachineBasic();
				var ai = new BasicAIDij();
				
				if(creature.attributes.HP < creature.attributes.morale) stateMachine.ProcessEvent(StateMachineBasic.Events.HPLow);
				var enemies = new EnemiesInSight(mapa, creature);
				if(enemies.enemiesInSight.Count !=0){
					stateMachine.ProcessEvent(StateMachineBasic.Events.EnemyInSight);
					Console.WriteLine("Theres {1} enemy in sight. My current state is {2}: {0}", creature.name, enemies.enemiesInSight.Count, stateMachine.State);
					ai.Attack(creature,mapa,enemies.enemiesInSight[0]);
				}
				else stateMachine.ProcessEvent(StateMachineBasic.Events.NoEnemyInSight);
				Needs.CheckNeeds.CheckCreaturesNeeds(creature);
				
				
				if(stateMachine.State == StateMachineBasic.States.Roaming) ai.Roam(creature,mapa);
				//Console.WriteLine(" My current state is {1}: {0}", creature.name, stateMachine.State);
				
			} 
		}
		
		
		
		public void SetMap(OperacjeMapy.Pole[,] map2)
		{
			
			//Console.WriteLine("SetMap:");
			for (int j = 0; j < map2.GetLength(0); j++) {
				for (int i = 0; i < map2.GetLength(1); i++) {
					if (map2[i, j].passable) {
						passMap[i, j] = true;
					} else
						passMap[i, j] = false;
					//if(passMap[i,j])Console.Write("0"); else Console.Write("1");
				}
				//Console.WriteLine();
			}
			
		}
		
		
		public OperacjeMapy.Pole[,] GoTo(Point startPos, Point endPos, OperacjeMapy.Pole[,] map2, Agent.Creature creature)
		{
			Point start = new Point { X = startPos.X, Y = startPos.Y };
			Point end = new Point { X = endPos.X, Y = endPos.Y };
			
			
			/*
			for (int i = 0; i < map.GetLength(0); i++) {
				for (int j = 0; j < map.GetLength(1); j++) {
					if(map[i,j]) Console.Write("0"); else Console.Write("1");

				}
				Console.WriteLine();
				
			}
			 */
			
			//Console.WriteLine("Init Dij");
			Dijkstra dij = new Dijkstra();
			SetMap(map2);
			dij.InitializeMap(mapSize.Height,mapSize.Width,start,end,passMap);
			//Console.WriteLine("Map inited");
			var path = new List<Point>();
			path = dij.FindPath();
			//Console.WriteLine("Path Found");
			/*foreach (Point p in path){
				Console.Write("[{0}] [{1}] || ",p.X,p.Y);
			}
			
			for (int j = 0; j < map2.GetLength(1); j++) {
				for (int i = 0; i < map2.GetLength(0); i++) {
					map2[i,j].colour = ConsoleColor.White;
					}
				
				}
				
			
			for (int i = 0; i < path.Count; i++) {
				map2[path[i].X,path[i].Y].colour = ConsoleColor.DarkMagenta;
			}
			 */

			
			CreatureActions actuator = new CreatureActions();
			if (path.Count > 0) {
				Point moveto = new Point(path[0].X, path[0].Y);
				map2 = actuator.MoveCreature(moveto, map2, creature);
			}

			return map2;
		}
		public void Attack(Agent.Creature attacker, OperacjeMapy.Pole[,] mapa, Agent.Creature defender)
		{
			BasicAIDij ai = new BasicAIDij();
			Random r = new Random();
			int damageDone = r.Next(1, 10);
			
			
			bool defenderIsAdjacent;
			
			
			int aPX = attacker.currentpossition.X;
			int aPY = attacker.currentpossition.Y;
			int dPX = defender.currentpossition.X;
			int dPY = defender.currentpossition.Y;

			if (aPX - 1 == dPX && aPY == dPY)
				defenderIsAdjacent = true;
			else if (aPX + 1 == dPX && aPY == dPY)
				defenderIsAdjacent = true;
			else if (aPX == dPX && aPY + 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX == dPX && aPY - 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX - 1 == dPX && aPY - 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX - 1 == dPX && aPY + 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX + 1 == dPX && aPY - 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX + 1 == dPX && aPY + 1 == dPY)
				defenderIsAdjacent = true;
			else
				defenderIsAdjacent = false;
			
			if (defenderIsAdjacent) {
				Console.WriteLine("DefenderIsAdjacent: {0}", defenderIsAdjacent);
				Console.WriteLine("Hadzia!");
				
			} else {
				Console.WriteLine("DefenderIsAdjacent: {0}", defenderIsAdjacent);
				ai.GoTo(attacker.currentpossition, defender.currentpossition, mapa, attacker);
			}
			//return mapa;
		}
		
		public void AttackMapEntity(Agent.Creature attacker, OperacjeMapy.Pole[,] mapa, Point defender)
		{
			BasicAIDij ai = new BasicAIDij();
			Random r = new Random();
			int damageDone = r.Next(1, 10);
			
			var kill = new KillAgent(defender,mapa,CreaturesToDo.FindEntity.KindOfEntity.mapEntity);
			bool defenderIsAdjacent;
			
			
			int aPX = attacker.currentpossition.X;
			int aPY = attacker.currentpossition.Y;
			int dPX = defender.X;
			int dPY = defender.Y;

			if (aPX - 1 == dPX && aPY == dPY)
				defenderIsAdjacent = true;
			else if (aPX + 1 == dPX && aPY == dPY)
				defenderIsAdjacent = true;
			else if (aPX == dPX && aPY + 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX == dPX && aPY - 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX - 1 == dPX && aPY - 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX - 1 == dPX && aPY + 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX + 1 == dPX && aPY - 1 == dPY)
				defenderIsAdjacent = true;
			else if (aPX + 1 == dPX && aPY + 1 == dPY)
				defenderIsAdjacent = true;
			else
				defenderIsAdjacent = false;
			
			if (defenderIsAdjacent) {
				Console.WriteLine("DefenderIsAdjacent: {0}", defenderIsAdjacent);
				Console.WriteLine("Hadzia!");
				var dmg = Convert.ToByte(r.Next(attacker.weaponsWielded[0].minDamage,attacker.weaponsWielded[0].maxDamage));
				mapa[dPX,dPY].mapEntities.HP -= dmg;
				if(mapa[dPX,dPY].mapEntities.HP<=0){
				kill.Kill();
				}
				
			} else {
				Console.WriteLine("DefenderIsAdjacent: {0}", defenderIsAdjacent);
				ai.GoTo(attacker.currentpossition, defender, mapa, attacker);
			}
			//return mapa;
		}
		
		
		public void Idle(){
			
		}
		
		public void Roam(Agent.Creature creature, OperacjeMapy.Pole[,] mapa){
			Random r = new Random(Guid.NewGuid().GetHashCode());
			
			BasicAIDij ai = new BasicAIDij();
			//Point whereTo = new Point();
			//whereTo = creature.currentpossition;
			var adjecent = new List<Point>();
			adjecent = GetAdjecentPassablePoints(mapa,creature.currentpossition);
			int randDir = r.Next(0,adjecent.Count);
			ai.GoTo(creature.currentpossition, adjecent[randDir],mapa,creature);
			
			/*switch (randDir){
				case 1:
					{
						whereTo.X--;
						whereTo.Y++;
						ai.GoTo(creature.currentpossition, whereTo, mapa, creature);
						break;
					}
				case 2:
					{
						whereTo.Y++;
						ai.GoTo(creature.currentpossition, whereTo, mapa, creature);
						break;
					}
				case 3:
					{
						whereTo.X++;
						whereTo.Y++;
						ai.GoTo(creature.currentpossition, whereTo, mapa, creature);
						break;
					}
				case 4:
					{
						whereTo.X--;
						ai.GoTo(creature.currentpossition, whereTo, mapa, creature);
						break;
					}
				case 5:
					{
						
						break;
					}
				case 6:
					{
						whereTo.X++;
						ai.GoTo(creature.currentpossition, whereTo, mapa, creature);
						break;
					}
				case 7:
					{
						whereTo.X--;
						whereTo.Y--;
						ai.GoTo(creature.currentpossition, whereTo, mapa, creature);
						break;
					}
				case 8:
					{
						
						whereTo.Y--;
						ai.GoTo(creature.currentpossition, whereTo, mapa, creature);
						break;
					}
				case 9:
					{
						whereTo.X++;
						whereTo.Y--;
						ai.GoTo(creature.currentpossition, whereTo, mapa, creature);
						break;
					}
			}
			*/
			
			
		}
		
		public void Run(Agent.Creature creature, Point chaserPos, OperacjeMapy.Pole[,] mapa){
			var ai = new BasicAIDij();
			var random = new Random();
			
			var r = creature.currentpossition;
			var c = chaserPos;
			var vectorX = r.X-c.X;
			var vectorY= r.Y-c.Y;
			var adjPassPoints = GetAdjecentPassablePoints(mapa,r);
			var escapeTo = new Point(r.X+vectorX,r.Y+vectorY);
			if(adjPassPoints.Contains(escapeTo)){
				ai.GoTo(r,escapeTo,mapa,creature);
			} else {
				var rand = random.Next(0,adjPassPoints.Count);
				ai.GoTo(r,adjPassPoints[rand],mapa,creature);
			}
			
		}
		
		
		
		
		private List<Point> GetAdjecentPassablePoints (OperacjeMapy.Pole[,] mapa, Point fromPos){
			var AdjPassPoints = new List<Point>();
			var adjPoint = new Point();
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if (fromPos.X+i < 0 || fromPos.X+i >= this.mapSize.Width || fromPos.Y+j < 0 || fromPos.Y+j >= this.mapSize.Height) {
						continue;
					} 
					if(mapa[fromPos.X+i,fromPos.Y+j].passable)
						adjPoint = new Point(fromPos.X+i,fromPos.Y+j);
						AdjPassPoints.Add(adjPoint);
				}
			}
			return AdjPassPoints;
		}
		
		
		
		
		
		
		
	}
	
	
	
	
	
	
	
	
}
