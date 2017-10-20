/*

 */
using System;
using System.Drawing;

namespace mapa.CreaturesToDo
{
	/// <summary>
	/// Description of Build.
	/// </summary>
	public class Build
	{
		Agent.MapEntity building;
		OperacjeMapy.Pole[,] map;
		Point theSpot;
		public byte check;
		
		public Build(Agent.MapEntity building, OperacjeMapy.Pole[,] map, Point theSpot)
		{
			this.building = building;
			this.map = map;
			this.theSpot = new Point(theSpot.X,theSpot.Y);
			ErectBuilding();
			
		}
		
		public byte CheckIfSpotOk(Point spot){
			if(map[spot.X, spot.Y].mapEntities.name=="null_name"){
				if(map[spot.X, spot.Y].Creature.Count==0){
					return 0;	
				} else return 1;
				
			} else return 2;
		}
		
		public void ErectBuilding(){
			
			if(CheckIfSpotOk(theSpot)==0){
				map[theSpot.X, theSpot.Y].mapEntities = new Agent.MapEntity(building);
				map[theSpot.X, theSpot.Y].passable = building.passable;
				map[theSpot.X, theSpot.Y].transluscent = building.transluscent;
				this.check = 0;
			} if(CheckIfSpotOk(theSpot)==1) {
				Console.WriteLine("Creature occupying spot.");
				this.check = 1;
			} if (CheckIfSpotOk(theSpot)==2){
				Console.WriteLine("Entity occupying spot.");
				this.check = 2;
			}
			this.check = 255;
		}
		
	}
}
