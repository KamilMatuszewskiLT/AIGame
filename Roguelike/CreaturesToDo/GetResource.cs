/*

 */
using System;
using System.Drawing;

namespace mapa.CreaturesToDo
{
	/// <summary>
	/// Description of GetResource.
	/// </summary>
	public class GetResource
	{
		OperacjeMapy.Pole[,] map;
		public GetResource(OperacjeMapy.Pole[,] map)
		{
			this.map=map;
		}
		
		public void ChopATree (Agent.Creature creature, Point tree){
			var AI = new BasicAIDij();
			AI.AttackMapEntity(creature,map,tree);
		}
		
	}
}
