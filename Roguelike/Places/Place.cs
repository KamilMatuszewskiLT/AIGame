/*

 */
using System;
using System.Drawing;
using System.Collections.Generic;

namespace mapa
{
	/// <summary>
	/// Description of Place.
	/// </summary>
	public class Place
	{
		public struct Rectangle{
			public Point topLeft {get;set;}
			public Point bottomRight {get;set;}
		}
		
		public enum placeType{
			basicShelter = 0,
			workshop = 1,
			
			
		}
		
		public String name;
		public placeType type;
		public List<Rectangle> area;
		public Agent.Creature owner;
		public Place()
		{
			this.area = new List<Rectangle>();
			this.owner = null;
		}
		
		public bool PointIsInArea(Point point, Place area){
			bool pointIsInArea;
			pointIsInArea = false;
			for (int i = 0; i<area.area.Count;i++){
				if(point.X >= area.area[i].topLeft.X && point.X <= area.area[i].bottomRight.X && point.Y >= area.area[i].bottomRight.Y && point.Y <= area.area[i].topLeft.Y){
					pointIsInArea = true;
				} 
			}
			
			return pointIsInArea;
		}
	}
	
	
}
