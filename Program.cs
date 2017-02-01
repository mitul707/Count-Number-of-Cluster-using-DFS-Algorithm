using System;
using System.Collections;

namespace CountClusters
{
    /*
     * This program is to understand 'DFS Algorithm' by traversing the nodes with recursion.
     */

    /* This program finds the total number of components from the given graph. 
     * The graph is given in string array. Following are the few steps to understand the flow of the Program.
     * 
     * The string array represent the adjacency of the nodes.
     * '1' represnts the link between two nodes.
     * '0' represents 'No Link' between respective nodes. 
     * 
     * For Example :
     * 
     * "1100",
	   "1110",
	   "0110",
	   "0001"
     * 
     * In above example, node number starts with 0. Total number of rows or columns meaning the total number of Nodes starting from '0'.
     * 
     * Step 1: We define one Adjacency Matrix[2-D integer array] from the given string array.
     * Step 2: Since the number of ROWS and COLUMNS will be same as they represents number of nodes, the Adjacency Matrix will be square matrix.
     * Step 3: Then we fill 'Adjacency Array with values. The index of the Adjacency Array represent the node.
     *         For example, if 'Node 0' and 'Node 1' is adjacent to each other then They both will be in each others adjacency List.
     * Step 4: We call 'doDFS' function inside for loop.
     * Step 5: doDFS function basically traverse nodes by using DFS and when all the adjacency nodes is visited it looks for any other node
     *         that is not visited yet. If it finds then it increment the number of Cluster_Count and then again call doDFS by that node.
    */

    class MyGraph
    {
        ArrayList obj;
        int number_of_nodes;
        ArrayList objAdjacencyArray;

        // For counting the total number of clusters:
        int number_of_clusters;

        /* visited array to mark the Node has visited.
         * 0 -> Not Visited
         * 1 -> Visited
        */

        int[] visited;

        public MyGraph(int[,] adj_matrix)
        {
            number_of_nodes = adj_matrix.GetLength(0);
            objAdjacencyArray = new ArrayList();
            visited = new int[number_of_nodes];

            for (int i = 0; i < number_of_nodes; i++)
            {
                obj = new ArrayList();
                for (int j = 0; j < number_of_nodes; j++)
                {
                    if (adj_matrix[i, j] == 1)
                    {
                        obj.Add(j);
                    }
                }
                
                objAdjacencyArray.Add(obj);
            }
        }

        public void doDFS(int node, int[] visited)
        {
            // Mark current visited node as '1'
            visited[node] = 1;
            
            foreach (int next_node  in (ArrayList)objAdjacencyArray[node])
            {
                if (visited[next_node] == 0)
                {
                    // Call doDFS only if the 'next_node' is not visited.
                    doDFS(next_node, visited);
                }
            }
        }

        static void Main(string[] args)
        {
            // Given string array
            string[] strings = new string[]
            {
			    "11000",
			    "11100",
			    "01100",
			    "00010",
                "00001"
		    };

            int ROW = strings.Length;
            int COL = strings[0].Length;

            // Create a Matrix[2-D integer array] based on ROW and COL
            int[,] adjMatrix = new int[ROW, COL];

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    int item = int.Parse(strings[i][j].ToString());
                    adjMatrix[i, j] = item;
                }
            }

            // Creating instance of a class 'MyGraph'.
            MyGraph obj = new MyGraph(adjMatrix);
            
            for (int list_node = 0; list_node < obj.number_of_nodes; list_node++)
            {
                if (obj.visited[list_node] == 0)
                {
                    obj.number_of_clusters++;
                    obj.doDFS(list_node, obj.visited);
                }
            }

            Console.WriteLine();

            // Print Number of Components
            Console.WriteLine("Number of Connected Components: " + obj.number_of_clusters);

            Console.Read();
        }
    }
}