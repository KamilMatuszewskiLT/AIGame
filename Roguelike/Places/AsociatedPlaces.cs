/*

 */
using System;
using System.Collections.Generic;

namespace mapa.Places
{
	/// <summary>
	/// Description of AosciatedPlaces.
	/// </summary>
	public struct AsociatedPlaces
	{
		public Place place {get;set;}
		public List<Place.placeType> typesOfThePlace {get;set;}
	}
}
