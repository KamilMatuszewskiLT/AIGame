/*

 */
using System;

namespace mapa.Needs
{
	/// <summary>
	/// Description of basicShelterNeed.
	/// </summary>
	public class basicShelterNeed
	{
		
		public basicShelterNeed()
		{
			
		}
		
		public static bool HasBasicShelter(Agent.Creature creature){
			for(int i = 0; i<creature.asociatedPlaces.Count; i++){
				foreach(Place.placeType placetype in creature.asociatedPlaces[i].typesOfThePlace){
					if(placetype == Place.placeType.basicShelter) return true;
				}
			}
			return false;
	}
}

}