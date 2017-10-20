/*

 */
using System;
using System.Collections.Generic;

namespace mapa
{
	/// <summary>
	/// Description of Groups.
	/// </summary>
	public struct Group
	{
		public Agent.Creature leader;
		public List<Agent.Creature> members;
		public Place headquarters;
		
		public Group(Agent.Creature leader)
		{
			this.leader = leader;
			this.members = new List<Agent.Creature>();
			this.members.Add(leader);
			this.headquarters = new Place();
		}
	}
}
