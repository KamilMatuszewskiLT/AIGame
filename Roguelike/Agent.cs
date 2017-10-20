/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-05-13
 * Time: 19:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace mapa
{
	
	public class Agent
	{
		public String name {get;set;}
		public char type {get;set;}
		public Point currentpossition {get;set;}
		
		public Agent(){
			name = "item_null";
			type = '?';
			currentpossition = new Point();
		}
		
		public struct CreatureAttributes{
			public byte HP {get;set;}
			public byte fighting {get;set;}
			public byte bravery {get;set;}
			public byte morale {get;set;}
			public byte strength {get;set;}
			public byte agility {get;set;}
			public byte inteligence {get;set;}
			public byte charisma {get;set;}
			public byte initiative {get;set;}
			public byte visualrange {get;set;}
			public AILoop.AIType AIType {get;set;}
		}
		public class Creature : Agent 
		{	 
			//public bool isPlayer {get;set;}
			public CreatureAttributes attributes;
			public List<Item> inventory{get;set;}
			public List<Weapon> weaponsWielded {get;set;}
			public List<Group> groups{get;set;}
			public List<needs> needs{get;set;}
			public Queue<toDo> todo {get;set;}
			public List<Places.AsociatedPlaces> asociatedPlaces{get;set;}
			
			public Creature() {
				//isPlayer=false;
				attributes.HP = 50;
				name = "null_name";
				type = '!';
				attributes.bravery = 10;
				attributes.morale = 10;
				attributes.strength = 10;
				attributes.agility=10;
				attributes.inteligence=10;
				attributes.charisma=10;
				attributes.initiative=1;
				attributes.visualrange=10;
				attributes.AIType = AILoop.AIType.BasicAi;
				weaponsWielded = new List<Weapon>();
				inventory = new List<Item>();
				needs = new List<needs>();
				todo = new Queue<toDo>();
				asociatedPlaces = new List<mapa.Places.AsociatedPlaces>();
			}
		}
		
		
		public class Item : Agent
		{
			public int weight {get;set;}
			public Creature owner {get;set;}
			public bool isStackable{get;set;}
			public byte stackSize{get;set;}

			public Item(){
				owner = null;
				isStackable = false;
				stackSize = 1;
				weight = 0*stackSize;
				
			}
		}
		public enum ResourceType{
			nullResource = 0,
			wood = 1,
		}
		
		public class Resource:Item{
			public ResourceType resourceType;
			public Resource(){
				this.resourceType = ResourceType.nullResource;
			}
			public Resource(ResourceType resType){
				if(resType==ResourceType.wood){
					this.resourceType = ResourceType.wood;
					this.isStackable = true;
					this.name = "wood";
					this.type = '=';
					this.weight = 0;
				}
			}
			
		}
		
		public class Weapon : Item
		{
			public int minDamage {get;set;}
			public int maxDamage {get;set;}
			public byte weaponLength {get;set;}
			public List<specialWeaponQualities> special{get;set;}
			public List<kindOfDamage> damageType{get;set;}
			
			public Weapon(){
				minDamage = 1;
				maxDamage = 1;
				weaponLength = 0;
				special = new List<specialWeaponQualities>();
				damageType = new List<kindOfDamage>();
				var blunt = kindOfDamage.blunt;
				damageType.Add(blunt);
			}
		}
		
		public enum specialWeaponQualities{
			woodchopping = 0,
			
		}
		
		public enum kindOfDamage{
			slashing = 0,
			blunt=1,
		}
		
		public class Container : Agent
		{
			public Container(){
				
			}
		}
		
		public class ResourceRequirement{
			public Agent.Resource resource;
			public int amount;
			public ResourceRequirement(){
				this.resource = new Agent.Resource();
				this.amount = 0;
			}
		}
		
		public class MapEntity:Agent
		{
			public bool passable;
			public bool transluscent;
			public byte HP;
			public String family;
			public Agent.Creature owner;
			public List<Agent.ResourceRequirement> resourcesRequired;
			
			public MapEntity(){
				this.passable = true;
				this.transluscent = true;
				this.HP = 100;
				this.family = "Null_family";
				this.owner = new Agent.Creature();
				this.resourcesRequired = new List<ResourceRequirement>();
			}
			
			public MapEntity(MapEntity entity){
				this.family=entity.family;
				this.HP=entity.HP;
				this.name=entity.name;
				this.passable=entity.passable;
				this.transluscent=entity.transluscent;
				this.type=entity.type=type;
				this.owner = entity.owner;
				this.resourcesRequired = entity.resourcesRequired;
			}
				
		}
	
		
		
		
	}
}