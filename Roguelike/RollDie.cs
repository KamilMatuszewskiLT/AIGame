/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-30
 * Time: 17:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace mapa
{
	/// <summary>
	/// Description of RollDie.
	/// </summary>
	public class RollDie
	{
		public double rolled;
		public RollDie(byte sides)
		{
			
			var rand = new Random();
			this.rolled = rand.Next(1,sides);
			
		}
		public RollDie()
		{
			
			var rand = new Random();
			this.rolled = rand.Next(1,20);
		}
	}
}
