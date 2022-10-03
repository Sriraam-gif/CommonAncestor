using System;


public class Node
{

    private Node? parent { get; }
    public Node? left { get; set; }
    public Node? right { get; set; }

    private string name { get; }

    public Node(Node? parent, String name)
    {
        this.parent = parent;
        this.name = name;
    }

    public String getName()
    {
        return name;
    }
    public Node? getParent()
    {
        return parent;
    }
    public String toString()
    {
        return name;
    }
}

namespace BinaryTrees
{
    class Program
    {
        static void Main(String[] args)
        {
            //Initialization of the nodes in the tree
            Node one = new Node(null, "1");
            Node two = new Node(one, "2");
            Node three = new Node(one, "3");
            Node four = new Node(two, "4");
            Node five = new Node(two, "5");
            Node six = new Node(three, "6");
            Node seven = new Node(three, "7");
            Node eight = new Node(four, "8");
            Node nine = new Node(four, "9");

            var watch=System.Diagnostics.Stopwatch.StartNew();
            watch.Start();
            Node LCA=findLCA(five, seven);
            watch.Stop();
            
            Console.WriteLine(LCA.getName());
            Console.Write(watch.ElapsedMilliseconds+" milliseconds");


        }

    //Pre-condition: A valid binary tree
    //Post-condition: The function aims to find the least common node for any two nodes in a binary tree
    public static Node findLCA(Node a, Node b)
    {
      if(a.getParent()==null) //checking if one of the nodes is the root node
      {
        return a;
      }
      if(b.getParent()==null)
      {
        return b;
      }

      List<Node> pathTakenForA=pathTaken(a); //Creates an array of the path of the node
      pathTakenForA.Reverse();
      List<Node> pathTakenForB=pathTaken(b);
      pathTakenForB.Reverse();
      
      for(int i=0; i<pathTakenForA.Count; i++) 
      {
        if(pathTakenForA[i].Equals(pathTakenForB[i])) //checking whether two nodes at poition i are same in the two lists
        {
            if(pathTakenForA[i].Equals(a) || pathTakenForA[i].Equals(b))//checking whether one of the nodes is directly related to the other node.
            {
                return pathTakenForA[i];
            }
        }
        if(pathTakenForA[i].Equals(pathTakenForB[i])==false)
        {
            return pathTakenForA[i-1];
        }
      }
        return null!;
    }    
    //This method just aims to create a List and pass it down for the next function.
    public static List<Node> pathTaken(Node node)
    {
       List<Node> listOfNodesInThePath=new List<Node>();
       return _pathTaken(node, listOfNodesInThePath);
    }

    //Pre-condition:None
    //Post-condition:Creates an array of the path of the given node in the parameter
    public static List<Node> _pathTaken(Node node, List<Node> listOfNodesInThePath)
    {
       listOfNodesInThePath.Add(node);
       if(node.getParent()!=null)
       {
        return _pathTaken(node.getParent()!, listOfNodesInThePath);
       }    

       return listOfNodesInThePath;  

    }


    }

}
