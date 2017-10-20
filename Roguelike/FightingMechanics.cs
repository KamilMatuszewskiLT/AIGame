/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-28
 * Time: 17:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace mapa
{
	/// <summary>
	/// Description of FightingMEchanics.
	/// </summary>
	public class FightingMechanics
	{
		public struct CombatParam{
			public byte param {get;set;}
			public double weight {get;set;}
		}
		
		
		public FightingMechanics()
		{
		}
		
		
		
		public double DamageRoll(List<CombatParam> paramList){
			double damageRolled = 0;
			
			foreach(CombatParam p in paramList){
				damageRolled += p.param*p.weight;
			}
			return damageRolled;
		}
		public bool DidItHit(List<CombatParam> paramListHitter, List<CombatParam> paramListTaker){
			double HitStr = 0;
			double TakerStr = 0 ;
			bool wasHit;
			var die = new RollDie();
			foreach(CombatParam p in paramListHitter){
				HitStr += p.param*p.weight;
			}
			foreach(CombatParam p in paramListTaker){
				TakerStr += p.param*p.weight;
			}
			
			HitStr+=die.rolled;
		
			TakerStr+=die.rolled;
			if (HitStr>TakerStr) wasHit = false; else wasHit = true;
			return wasHit;
		}
	}
}
