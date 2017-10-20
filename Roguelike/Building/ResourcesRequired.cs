/*

 */
using System;

namespace mapa.Building
{
	/// <summary>
	/// Description of ResourcesRequired.
	/// </summary>
	public class ResourcesRequired
	{
		Agent.MapEntity building;
		Agent.Creature creature;
		public bool sufficientResources;
		
		public ResourcesRequired(Agent.MapEntity building, Agent.Creature creature)
		{
			this.building = building;
			this.creature = creature;
			
			
			
		}
		
		
	}
}
