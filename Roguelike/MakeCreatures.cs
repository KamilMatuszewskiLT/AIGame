/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-07-03
 * Time: 12:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.Collections.Generic;

namespace mapa
{
	/// <summary>
	/// Description of MakeCreatures.
	/// </summary>
	public class MakeCreatures
	{
		public List<Agent.Creature> creaturesList;
		
		public MakeCreatures()
		{
			creaturesList = new List<Agent.Creature>();
		}
		
		public void MakeCreaturesList(){
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("Creatures.xml");
			XmlNodeList elemList = xmlDoc.GetElementsByTagName("creature");
			      	Console.WriteLine("Number of creatures: {0}",elemList.Count);
			      	for(int i=0; i<elemList.Count; i++){
			      		var creature = new Agent.Creature();
			      		Console.WriteLine("Adding creature no. {0}", i);
			      		creature.type = elemList[i].Attributes["type"].Value[0];
			      		Console.WriteLine("Creature type: {0}",creature.type);
			      		creature.name = elemList[i].Attributes["name"].Value;
			      		creature.attributes.fighting = byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.bravery = byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.charisma = byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.agility = byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.initiative = byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.inteligence= byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.strength= byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.morale = byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.visualrange = byte.Parse(elemList[i].Attributes["fighting"].Value);
			      		creature.attributes.AIType = AILoop.AIType.BasicAi;
			      		creaturesList.Add(creature);
			      		
			      	}
			    
			      		
			      		
			      	
			
		}
	}
}
