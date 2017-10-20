/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-26
 * Time: 19:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.Collections.Generic;


namespace mapa
{
	/// <summary>
	/// Description of MakeAgents.
	/// </summary>
	public class MakeItems
	{
		
		public List<Agent.Weapon> weaponsList;
		public List<Agent.Resource> resourcesList;
		
		public MakeItems()
		{
			this.weaponsList = new List<Agent.Weapon>();
			this.resourcesList = new List<Agent.Resource>();
			
		}
		
		public void MakeWeapons(){
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("Weapons.xml");
			XmlNodeList elemList = xmlDoc.GetElementsByTagName("weapon");
			      	Console.WriteLine("Number of weapons: {0}",elemList.Count);
			      	for(int i=0; i<elemList.Count; i++){
			      		var weapon = new Agent.Weapon();
			      		Console.WriteLine("Adding Weapon no. {0}", i);
			      		weapon.type = elemList[i].Attributes["type"].Value[0];
			      		Console.WriteLine("Weapon type: {0}",weapon.type);
			      		weapon.name = elemList[i].Attributes["name"].Value;
			      		weapon.weight = int.Parse(elemList[i].Attributes["weight"].Value);
			      		weapon.minDamage = int.Parse(elemList[i].Attributes["minDamage"].Value);
			      		weapon.maxDamage = int.Parse(elemList[i].Attributes["maxDamage"].Value);
			      		weapon.weaponLength = byte.Parse(elemList[i].Attributes["weaponLength"].Value);
			      		string special, dmgtype;
			      		special = elemList[i].Attributes["special"].Value;
			      		dmgtype = elemList[i].Attributes["damageType"].Value;
			      		char[] separator = new char[] {','};
			      		string[] splitString;
			      		splitString = special.Split(separator);
			      		foreach(String attr in splitString){
			      			var specialAttr = new Agent.specialWeaponQualities();
			      			if(attr=="woodchopping") {
			      				specialAttr = Agent.specialWeaponQualities.woodchopping;
			      				weapon.special.Add(specialAttr);
			      			}
			      		}
			      		splitString = dmgtype.Split(separator);
			      		foreach(String attr in splitString){
			      			var specialAttr = new Agent.kindOfDamage();
			      			if(attr=="slashing") {
			      				specialAttr = Agent.kindOfDamage.slashing;
			      				weapon.damageType.Add(specialAttr);
			      			}
			      			if(attr=="blunt") {
			      				specialAttr = Agent.kindOfDamage.blunt;
			      				weapon.damageType.Add(specialAttr);
			      			}
			      		}
			      		
			      		weaponsList.Add(weapon);
			      		
			      	}      	
			
		}
		
		public void MakeResources(){
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("Resources.xml");
			XmlNodeList elemList = xmlDoc.GetElementsByTagName("resource");
			      	Console.WriteLine("Number of resources: {0}",elemList.Count);
			      	for(int i=0; i<elemList.Count; i++){
			      		var resource = new Agent.Resource();
			      		Console.WriteLine("Adding resource no. {0}", i);
			      		resource.type = elemList[i].Attributes["type"].Value[0];
			      		Console.WriteLine("Resource type: {0}",resource.type);
			      		resource.name = elemList[i].Attributes["name"].Value;
			      		resource.weight = int.Parse(elemList[i].Attributes["weight"].Value);
			      		String resType = elemList[i].Attributes["resourceType"].Value;
			      		if(resType=="wood") resource.resourceType = Agent.ResourceType.wood;
			      		
			      		resourcesList.Add(resource);
			      		
			      	}      	
			
		}
		
	}
}
