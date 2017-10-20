/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-30
 * Time: 17:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace mapa
{
	/// <summary>
	/// Description of Fight.
	/// </summary>
	public class Fight
	{
		public Fight(Agent.Creature attacker, Agent.Creature defender)
		{
			var mechanics = new FightingMechanics();
			List<FightingMechanics.CombatParam> attToHit= new List<FightingMechanics.CombatParam>();
			List<FightingMechanics.CombatParam> defToHit= new List<FightingMechanics.CombatParam>();
			List<FightingMechanics.CombatParam> atToDmg = new List<FightingMechanics.CombatParam>();
			FightingMechanics.CombatParam combatParam = new FightingMechanics.CombatParam();
		 	combatParam.param = attacker.attributes.strength;
		 	combatParam.weight = 0.2;
		 	atToDmg.Add(combatParam);
		 	
		 	combatParam.param = attacker.attributes.fighting;
		 	combatParam.weight = 1;
		 	attToHit.Add(combatParam);
		 	
		 	combatParam.param = attacker.attributes.agility;
		 	combatParam.weight = 0.5;
		 	attToHit.Add(combatParam);
		 	
		 	combatParam.param = defender.attributes.fighting;
		 	combatParam.weight = 1;
		 	defToHit.Add(combatParam);
		 	
		 	combatParam.param = defender.attributes.agility;
		 	combatParam.weight = 0.5;
		 	defToHit.Add(combatParam);
		 	
		 	var attDmgRoll = mechanics.DamageRoll(atToDmg);
		 	var DidItHit = mechanics.DidItHit(attToHit,defToHit);
		 	
		 	if(DidItHit) {
		 	//event hit
		 	} else {
		 	//event missed which shows message and logs it
		 	}
		 	
			
		}
	}
}
