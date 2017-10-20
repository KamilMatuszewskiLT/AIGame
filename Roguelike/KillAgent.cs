/*

 */
using System;
using System.Drawing;
using mapa.CreaturesToDo;

namespace mapa
{
	/// <summary>
	/// Description of KillAgent.
	/// </summary>
	public class KillAgent
	{
		Point agentToKill;
		OperacjeMapy.Pole[,] map;
		FindEntity.KindOfEntity kindOfAgentToKill;
		ItemSpawner spawner;
		
		public KillAgent(Point agentToKill, OperacjeMapy.Pole[,] map, FindEntity.KindOfEntity kindOfAgentToKill)
		{
			this.agentToKill = agentToKill;
			this.map = map;
			this.kindOfAgentToKill = kindOfAgentToKill;
			this.spawner = new ItemSpawner();
			
		}
		
		public void Kill(){
			if(kindOfAgentToKill == FindEntity.KindOfEntity.mapEntity){
				if(map[agentToKill.X,agentToKill.Y].mapEntities.family == "wood"){
					map[agentToKill.X,agentToKill.Y].mapEntities = new Agent.MapEntity();
					var pileOfWood = new Agent.Resource(Agent.ResourceType.wood);
					pileOfWood.stackSize=40;
					spawner.SpawnItem(agentToKill,pileOfWood,map);
				}
			}
		}
		
		
	}
}
