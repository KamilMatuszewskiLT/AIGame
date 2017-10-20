/*
 */
using System;
using System.Xml;
using System.Collections.Generic;

namespace mapa
{
	/// <summary>
	/// Description of MakeCreatures.
	/// </summary>
	public class MakeMapEntities
	{
		public List<Agent.MapEntity> entitiesList;
		
		public MakeMapEntities()
		{
			entitiesList = new List<Agent.MapEntity>();
		}
		
		public void MakeMapEntitiesList()
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("MapEntities.xml");
			XmlNodeList elemList = xmlDoc.GetElementsByTagName("entity");
			Console.WriteLine("Number of entities: {0}", elemList.Count);
			for (int i = 0; i < elemList.Count; i++) {
				var entity = new Agent.MapEntity();
				Console.WriteLine("Adding MapEntity no. {0}", i);
				entity.type = elemList[i].Attributes["type"].Value[0];
				Console.WriteLine("MapEntity type: {0}", entity.type);
				entity.name = elemList[i].Attributes["name"].Value;
				entity.passable = bool.Parse(elemList[i].Attributes["passable"].Value);
				entity.transluscent = bool.Parse(elemList[i].Attributes["transluscent"].Value);
				entity.HP = byte.Parse(elemList[i].Attributes["HP"].Value);
				entity.family = elemList[i].Attributes["family"].Value;
				if (elemList[i].Attributes["resources"].Value != "none") {
					string resources;
					resources = elemList[i].Attributes["resources"].Value;
					char[] separator1 = new char[] { ',' };
					char[] separator2 = { ':' };
					string[] splitString;
					splitString = resources.Split(separator1);
					string[] splitSplitString;
					List<String> res = new List<string>();
					List<int> amount = new List<int>();
					for(int k=0; k<splitString.GetLength(0);k++){
						splitSplitString = splitString[k].Split(separator2);
						for(int e=0; e<splitString.GetLength(0);e+=2){
							res.Add(splitSplitString[e]);
							Console.WriteLine(splitSplitString[e]);
						}
						for(int o=1; o<=splitString.GetLength(0);o+=2){
							amount.Add(Convert.ToInt16(splitSplitString[o]));
							Console.WriteLine(splitSplitString[o]);
						}
						
						
					}
				}
				
				entitiesList.Add(entity);
				
			}
			
			
			
			
			
		}
	}
}
