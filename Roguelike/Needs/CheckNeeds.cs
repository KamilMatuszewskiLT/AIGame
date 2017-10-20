/*

 */
using System;

namespace mapa.Needs
{
	/// <summary>
	/// Description of CheckNeeds.
	/// </summary>
	public class CheckNeeds
	{
		public CheckNeeds()
		{
			
			
		}
		
		public static void CheckCreaturesNeeds(Agent.Creature creature)
		{
			if(!(basicShelterNeed.HasBasicShelter(creature))){
				var need = needs.basicShelter;
				creature.needs.Add(need);
			}
		}
	}
}
