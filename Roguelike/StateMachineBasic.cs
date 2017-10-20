/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-29
 * Time: 17:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapa
{
	/// <summary>
	/// Description of StateMachineBasic.
	/// </summary>
	class StateMachineBasic
	{
		public enum States
		{
			Attacking,
			Running,
			Roaming,
			
		}

		;
		public States State { get; set; }

		public enum Events
		{
			EnemyInSight,
			HPLow,
			NoEnemyInSight
		
		}

		;

		private Action[,] fsm;

		public StateMachineBasic()
		{
			this.fsm = new Action[3, 3] {
				//EnemyInSight,     HPLow,                  NoEnemyInSight,
				{ this.DoNothing,	this.Run,				this.Roam },     //Attacking
				{ this.DoNothing,    this.DoNothing,   		this.Roam },     //Running
				{ this.Attack,	  	this.DoNothing,		    this.DoNothing }      //Roaming
			};
		}
		public void ProcessEvent(Events theEvent)
		{
			this.fsm[(int)this.State, (int)theEvent].Invoke();
		}
		private void DoNothing()
		{
			return;
		}
		private void Run()
		{
			this.State = States.Running;
		}
		private void Attack()
		{
			this.State = States.Attacking;
		}
		private void Roam()
		{
			this.State = States.Roaming;
		}
	}
}

