/*

 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace mapa.CreaturesToDo
{
	/// <summary>
	/// Description of ChopWood.
	/// </summary>
	public class FindEntity
	{
		
		OperacjeMapy.Pole[,] map;
		Agent.Creature creature;
		GetFOV creatureFOV;
		String name;
		public List<Point> nearestEntities;
		public List<Point> entitiesFound;
		public enum KindOfEntity
		{
			item,
			mapEntity,
			creature
		}
		public KindOfEntity kindOfEntity;
		
		
		public FindEntity(OperacjeMapy.Pole[,] map, Agent.Creature creature, String entitysName, KindOfEntity kindOfEntity)
		{
			this.map = map;
			this.creature = creature;
			creatureFOV = new GetFOV(this.map, this.creature);
			creatureFOV.GetMyFOV();
			this.name = entitysName;
			this.nearestEntities = new List<Point>();
			this.entitiesFound = new List<Point>();
			this.kindOfEntity = kindOfEntity;
		}
		
		public bool FindNearestEntity()
		{
			bool entityFound = false;
			Point entitysPoss = new Point();
			Random r = new Random(Guid.NewGuid().GetHashCode());
			foreach (Point p in creatureFOV.FOVCalc.VisiblePoints) {
				Console.WriteLine("Checking square [{0},{1}].", p.X, p.Y);
				if (kindOfEntity == KindOfEntity.mapEntity) {
							if (map[p.X, p.Y].mapEntities.name == name) {
								entitysPoss = new Point(p.X, p.Y);
								entitiesFound.Add(entitysPoss);
								Console.WriteLine("Found an entity.");
								entityFound = true;
					}
				}
				if (kindOfEntity == KindOfEntity.item) {
					if (map[p.X, p.Y].Items.Count != 0) {
						for (int i = 0; i < map[p.X, p.Y].Items.Count; i++) {
							if (map[p.X, p.Y].Items[i].name == name) {
								entitysPoss = new Point(p.X, p.Y);
								entitiesFound.Add(entitysPoss);
								Console.WriteLine("Found an entity.");
								entityFound = true;
							}
						}
					}
				}
				if (kindOfEntity == KindOfEntity.creature) {
					if (map[p.X, p.Y].Creature.Count != 0) {
						for (int i = 0; i < map[p.X, p.Y].Creature.Count; i++) {
							if (map[p.X, p.Y].Creature[i].name == name) {
								entitysPoss = new Point(p.X, p.Y);
								entitiesFound.Add(entitysPoss);
								Console.WriteLine("Found an entity.");
								entityFound = true;
							}
						}
					}
				}
			}

			if (entitiesFound.Count > 1) {
				Point currentNearestEntity = new Point(entitiesFound[0].X, entitiesFound[0].Y);
				DistanceBetweenPoints distance = new DistanceBetweenPoints();
				double dist2;
				double distToPlayer;
				for (int i = 1; i < entitiesFound.Count; i++) {
					dist2 = distance.Distance(entitiesFound[i], creature.currentpossition);
					distToPlayer = distance.Distance(currentNearestEntity, creature.currentpossition);
					if (dist2 < distToPlayer) {
						currentNearestEntity = new Point(entitiesFound[i].X, entitiesFound[i].Y);
						Console.WriteLine("Checking tree dist {0} v {1}]. Adding tree [{2},{3}]", dist2, distToPlayer, currentNearestEntity.X, currentNearestEntity.Y);
					}
					
				}
				//this.nearestEntities.Add(currentNearestEntity);
				for (int i = 0; i < entitiesFound.Count; i++) {
					dist2 = distance.Distance(entitiesFound[i], creature.currentpossition);
					distToPlayer = distance.Distance(currentNearestEntity, creature.currentpossition);
					Console.WriteLine("Checking tree dist {0} v {1}].", dist2, distToPlayer);
					if (Math.Round(dist2) == Math.Round(distToPlayer)) {
						Console.WriteLine("Checking tree dists rounded {0} v {1}].", Math.Round(dist2), Math.Round(distToPlayer));
						this.nearestEntities.Add(entitiesFound[i]);
					}
					
				}
				
			}
			if (entitiesFound.Count == 1)
				this.nearestEntities.Add(entitiesFound[0]);
			
			return entityFound;
			
			
		}
	}
}
