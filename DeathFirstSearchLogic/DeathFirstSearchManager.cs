using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeathFirstSearchLogic
{
    public class DeathFirstSearchManager
    {

        public static List<string> Execute(string[] listOfLinks, int[] gateWays, int N, int[] positionsAgent)
        {
            MapEngine map = new MapEngine(listOfLinks, gateWays, N);
            List<string> result = GameLoop(map, positionsAgent);
            return result;
        }

        private static List<string> GameLoop(MapEngine map, int[] positionsAgent)
        {
            int i = 0;
            List<string> list = new List<string>();
            while (map.RemainingGateWayConections() && i < positionsAgent.Length)
            {
                string linkCut = map.ExecuteRound(positionsAgent[i]);
                list.Add(linkCut);
                i++;

            }
            return list;
        }

        public class MapEngine
        {
            private static List<Node> NodeList = new List<Node>();
            private static List<Node> NodeGatewayList = new List<Node>();
            public MapEngine(string[] listOfLinks, int[] gateWays, int N)
            {
                LoadMap(listOfLinks, gateWays, N);
            }

            public bool RemainingGateWayConections()
            {
                return NodeGatewayList.Any(x => x.Conexions.Any());
            }

            public void RemoveConexion(Node node1, Node node2)
            {
                node1.DeleteConexion(node2);
                node2.DeleteConexion(node1);
            }

            public string ExecuteRound(int position)
            {

                if (AgentNearGateWay(position))
                {
                    Node agent = GetNode(position);
                    Node gateWayNode = GetNodeGateWay(position);
                    RemoveConexion(agent, gateWayNode);
                    return agent.Num + " " + gateWayNode.Num;
                }

                Node gatewayNode = NodeGatewayList.Where(x => x.Conexions.Any()).ToList().FirstOrDefault();

                int brother = gatewayNode.Conexions[0].Num;
                Node brotherNode = GetNode(brother);
                
                RemoveConexion(gatewayNode, brotherNode);
                return gatewayNode.Num + " " + brotherNode.Num;

            }
            public void LoadMap(string[] listOfLinks, int[] gateWays, int N)
            {
                CreateNodes(N);
                CreateConections(listOfLinks);
                SetGateWays(gateWays);
            }
            private void CreateNodes(int N)
            {
                for (int i = 0; i < N; i++)
                {
                    NodeList.Add(new Node(i));
                }
            }

            private void CreateConections(string[] listOfLinks)
            {
                foreach (string r in listOfLinks)
                {
                    string[] links = r.Split(' ');
                    int firstNodeint = int.Parse(links[0]);
                    int secondNodeint = int.Parse(links[1]);

                    Node firstNode = NodeList.FirstOrDefault(n => n.Num == firstNodeint);
                    Node secondNode = NodeList.FirstOrDefault(n => n.Num == secondNodeint);

                    firstNode.AddConexion(secondNode);
                    secondNode.AddConexion(firstNode);
                }
            }

            private void SetGateWays(int[] gateWays)
            {
                foreach (int gateWay in gateWays)
                {
                    Node node = NodeList.Where(x => x.Num == gateWay).FirstOrDefault();
                    node.SetGateWay();
                    NodeGatewayList.Add(node);
                }
            }

            private Node GetNode(int num)
            {
                return NodeList.Where(x => x.Num == num).FirstOrDefault();
            }

            private bool AgentNearGateWay(int agentPosition)
            {
                if (RemainingGateWayConections())
                {
                    foreach (Node nodo in NodeGatewayList)
                    {
                        int[] conections = nodo.GetConexions();
                        if (conections.Any(x => x == agentPosition))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            private Node GetNodeGateWay(int agentPosition)
            {
                foreach (Node nodo in NodeGatewayList)
                {
                    int[] conections = nodo.GetConexions();
                    if (conections.Any(x => x == agentPosition))
                    {
                        return nodo;
                    }
                }
                return null;
            }
        }

        public class Node
        {
            public List<Node> Conexions = new List<Node>();
            public int Num;
            public bool IsGateway = false;

            public Node(int nodeNum)
            {
                Num = nodeNum;
            }

            public void AddConexion(Node conexion)
            {
                Conexions.Add(conexion);
            }

            public void DeleteConexion(Node node)
            {
                Conexions.Remove(node);
            }

            public int[] GetConexions()
            {
                return Conexions.Select(x => x.Num).ToArray();
            }
            public void SetGateWay()
            {
                IsGateway = true;
            }
        }
    }
}
