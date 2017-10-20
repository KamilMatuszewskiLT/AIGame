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
	/*
	 		public string name { get; set; }
			public char type { get; set; }
			// Frequency of occurence - Prawdopobienstwo stworzenia nowe pola, jezeli sasiad jest polem INNEGO typu.
			public byte foo { get; set; }
			// Weight - Prawdopobienstwo stworzenia nowe pola, jezeli sasiad jest polem TEGO SAMEGO typu.
			public byte weight { get; set; }
			public bool passable { get; set; }
			public bool transluscent { get; set; }
			public List<Agent.Creature> Creature { get; set; }
			public List<Agent.Item> Items { get; set; }
			public bool isExplored { get; set; }
			public ConsoleColor colour { get; set; }
	 
	 */
	
	public class MakeMapFields
	{
		
		public List<OperacjeMapy.Pole> mapFieldsList;
		
		public MakeMapFields()
		{
			mapFieldsList = new List<OperacjeMapy.Pole>();
		}
		
		public void MakeFieldsForMap(){
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("MapFields.xml");
			XmlNodeList elemList = xmlDoc.GetElementsByTagName("field");
			      	Console.WriteLine("Number of fields: {0}",elemList.Count);
			      	for(int i=0; i<elemList.Count; i++){
			      		var mapField = new OperacjeMapy.Pole();
			      		Console.WriteLine("Adding field no. {0}", i);
			      		mapField.type = elemList[i].Attributes["type"].Value[0];
			      		Console.WriteLine("Field type: {0}",mapField.type);
			      		mapField.name = elemList[i].Attributes["name"].Value;
			      		mapField.weight = byte.Parse(elemList[i].Attributes["weight"].Value);
			      		mapField.foo = byte.Parse(elemList[i].Attributes["foo"].Value);
			      		Console.WriteLine("Field foo: {0}",mapField.foo);
			      		mapField.passable = bool.Parse(elemList[i].Attributes["passable"].Value);
			      		mapField.transluscent = bool.Parse(elemList[i].Attributes["transluscent"].Value);
			      		ConsoleColor[] colors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
			      		String colour = elemList[i].Attributes["colour"].Value;
			      		foreach(var color in colors){
			      			if (colour.Equals(Convert.ToString(color),StringComparison.OrdinalIgnoreCase)){
			      				mapField.colour = color;
			      			}
			      		}
			      		
			      		mapField.Creature = new List<Agent.Creature>();
			      		mapField.isExplored = false ;
			      		mapField.Items = new List<Agent.Item>();

			      		mapFieldsList.Add(mapField);
			      		
			      	}
			    
			      		
			      		
			      	
			
		}
		
		
	}
}
