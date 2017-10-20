/*

 */
using System;
using System.Drawing;

namespace mapa.CreaturesToDo
{
	/// <summary>
	/// Description of DistanceBetweenPoints.
	/// </summary>
	public class DistanceBetweenPoints
	{
		public DistanceBetweenPoints()
		{
		}
		
		public double Distance(Point x, Point y){
			double dist = -1;
			dist = Math.Sqrt(Math.Pow((x.X-y.X),2)+Math.Pow((x.Y-y.Y),2));
			return dist;
		}
		
	}
}
