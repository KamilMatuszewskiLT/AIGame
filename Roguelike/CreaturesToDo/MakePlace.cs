/*

 */
using System;
using System.Drawing;
using System.Collections.Generic;

namespace mapa.CreaturesToDo
{
	/// <summary>
	/// Description of MakePlace.
	/// </summary>
	public class MakePlace
	{
		public MakePlace(Point p, String name, Agent.Creature owner, Place.placeType type)
		{
			var newPlace = new Place();
			var area = new Place.Rectangle();
			area.topLeft = new Point(p.X,p.Y);
			area.bottomRight = new Point(p.X,p.Y);
			newPlace.area.Add(area);
			newPlace.name = name;
			newPlace.owner = owner;
			newPlace.type = type;
			var asociatePlace = new Places.AsociatedPlaces();
			asociatePlace.place = newPlace;
			asociatePlace.typesOfThePlace.Add(type);
			owner.asociatedPlaces.Add(asociatePlace);
		}
		public MakePlace(List<Place.Rectangle> area, String name, Agent.Creature owner, Place.placeType type)
		{
		}
	}
}
