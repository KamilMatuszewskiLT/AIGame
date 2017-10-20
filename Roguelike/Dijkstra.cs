/*
 * Created by SharpDevelop.
 * User: Liam
 * Date: 2017-06-16
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;


namespace mapa
{
	/// <summary>
	/// Description of Dijkstra.
	/// </summary>
	public class Dijkstra
	{
		
		public Node[,] map;
		//public List<Node> unvisitednodes;
		public Size mapsize;
		public Point startPos;
		public Point endPos;
		public Node current;
		//public List<Node> unvisitedNodes;
		public List<Point> path;
		public int unvisitedNodesCount;
		
		public class Node
		{
			public double distance { get; set; }
			public Node previous { get; set; }
			public bool passable { get; set; }
			public Point location {get;set;}
			public bool visited {get;set;}
			//public double length {get;set;}
			
			
			public Node()
			{
				distance = double.MaxValue;
				previous = null;
				passable = false;
				location = new Point();
				visited = false ;
				//length = 0;
			}
			
		}
		
		
		
		public Dijkstra()
		{
			mapsize = Size.Empty;
			map = new Node[mapsize.Width, mapsize.Height];
			//unvisitedNodes = new List<Node>();
			startPos = new Point();
			endPos = new Point();
			current = new Node();
			path = new List<Point>();
			unvisitedNodesCount = mapsize.Width*mapsize.Height;
		}

		
		
		private void SetPassableMap(bool[,] passablemap)
		{
			for (int j = 0; j < map.GetLength(1); j++) {
				for (int i = 0; i < map.GetLength(0); i++) {
					map[i, j].passable = passablemap[i, j];
					//Console.Write("{0}", passablemap[i,j]);
					if (!(passablemap[i,j])) {
						unvisitedNodesCount--;
						//Console.Write("Unvisited: {0}\t",unvisitedNodesCount);

					} 					
				} 
				Console.WriteLine();
			}
		}
		
		
		public void InitializeMap(int mapHeight, int mapWidth, Point startPos, Point endPos, bool[,] passableMap)
		{
			mapsize.Height = mapHeight;
			mapsize.Width = mapWidth;
			unvisitedNodesCount = mapsize.Width*mapsize.Height;
			this.startPos = startPos;
			this.endPos = endPos;
			map = new Node[mapsize.Width,mapsize.Height];
			for (int j = 0; j < map.GetLength(0); j++) {
				for (int i = 0; i < map.GetLength(1); i++) {
					map[i, j] = new Node();
					map[i,j].visited = false;
					map[i,j].distance = Math.Sqrt(Math.Pow((endPos.X-i),2)+Math.Pow((endPos.Y-j),2));
					map[i,j].location = new Point(i,j);
					//unvisitedNodes.Add(map[i,j]);
				}
			}
			
			
			current.visited = true ;
			unvisitedNodesCount--;
			current.location = startPos;
			current.distance = 1000;
			current.previous = null;
			map[startPos.X,startPos.Y] = current ; 
			SetPassableMap(passableMap);
			//if (!(passableMap[endPos.X,endPos.Y])) 
			map[endPos.X,endPos.Y].passable = true;
			
			
			
		}
		
		
		private bool NodeValid(Point p){
			bool isvalid;
			isvalid = false;
			 if (p.X < 0 || p.X >= mapsize.Width || p.Y < 0 || p.Y >= mapsize.Height)
			 {
			 	//Console.Write(" Invalid \n");
			 	return isvalid;
			 }
			//Console.Write("Checking Node pos X{0},Y{1}",p.X,p.Y);
			
			if (!map[p.X,p.Y].passable || map[p.X,p.Y].visited){
				return isvalid;
				//Console.Write(" Valid \n");
			} //else Console.Write(" Invalid \n");
			isvalid = true;
			return isvalid;
			
		}
		
		private List<Node> GetNeighbours(Node node){
			var neighbours = new List<Point>();
			Point x = new Point();
			var validneighbours = new List<Node>();
			

			x = new Point (node.location.X-1,node.location.Y-1);
			neighbours.Add(x);

			x = new Point (node.location.X,node.location.Y-1);
			neighbours.Add(x);

			x = new Point (node.location.X+1,node.location.Y-1);
			neighbours.Add(x);

			x = new Point (node.location.X-1,node.location.Y);
			neighbours.Add(x);

			x = new Point (node.location.X+1,node.location.Y);
			neighbours.Add(x);

			x = new Point (node.location.X-1,node.location.Y+1);
			neighbours.Add(x);

			x = new Point (node.location.X,node.location.Y+1);
			neighbours.Add(x);

			x = new Point (node.location.X+1,node.location.Y+1);
			neighbours.Add(x);
			
			foreach(Point p in neighbours){
				if(NodeValid(p)){
					validneighbours.Add(map[p.X,p.Y]);
				}
			}
			
			return validneighbours;
		}
	
		
		public List<Point> FindPath(){
			var pathPoint = new Point();
			var neighbours = new List<Node>();
			
			var nextNode = new Node();
			//Console.WriteLine("Current distance in findpath is: {0}", current.distance);
			
			
			
			while (current.location!=endPos){
				if (unvisitedNodesCount==0) {
					Console.WriteLine("Path not found");
					break;
				}
				neighbours = GetNeighbours(current);
				nextNode = current;
				foreach(Node n in neighbours){
					//Console.WriteLine("Neighbour X{0},Y{1}. Distance A{2} B{3}",n.location.X,n.location.Y,current.distance,n.distance);
					//Console.WriteLine("Current distance in findpath loop is: {0}", current.distance);
					if (n.distance < nextNode.distance) nextNode = n;
				} //Console.WriteLine("Next node is: X{0}, Y{1}.",nextNode.location.X,nextNode.location.Y);
				Console.WriteLine();
				nextNode.previous = current;
				unvisitedNodesCount--;
				current = nextNode;
				
			}
			
			while (current.previous != null){
				pathPoint = current.location;
				path.Add(pathPoint);
				current = current.previous;
			}
			// pozycja gracza jest invalid wiec trzeba ja usunac z listy bo jest nonpassable
			//path.RemoveAt(path.Count-1);
			
			path.Reverse();
			return path;
				 
		}
	}
}
