/*

 */
using System;

namespace mapa.CreaturesToDo
{
	/// <summary>
	/// Description of UnEquip.
	/// </summary>
	public class UnWield
	{
		Agent.Creature creature;
		public UnWield(Agent.Creature creature)
		{
			this.creature = creature;
		}
		
		public void Unwield(Agent.Weapon weapon){
			if(creature.weaponsWielded[0] == weapon){
				creature.inventory.Add(weapon);
				creature.weaponsWielded.Remove(weapon);
			}
			if(creature.weaponsWielded[1] == weapon){
				creature.inventory.Add(weapon);
				creature.weaponsWielded.Remove(weapon);
			}
		}
		
		public void Wield(Agent.Weapon weapon){
			if(creature.weaponsWielded.Count==1){
				Unwield(creature.weaponsWielded[0]);
				Wield(weapon);
			}
			if(creature.weaponsWielded.Count==0){
				creature.weaponsWielded.Add(weapon);
				creature.inventory.Remove(weapon);
			}
		}
		
	}
}
