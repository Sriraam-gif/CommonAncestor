using System;
using Xunit;
using BinaryTrees;

public class testclass
{
    [Theory]
    [MemberData(nameof(Data1))]
    public void findingCommonAncestor_normalBinaryTrees_returnValidAncestor(Node a, Node b, Node expectedResult)
    {
      Node actualResult=Program.findLCA(a,b);   
      Assert.Equal(expectedResult, actualResult);  
    }

    public static IEnumerable<object[]> Data1()
    {

      //Tree 1 Balanced
      Node AForCase1 =new Node(null, "A");
      Node BForCase1=new Node(AForCase1,"B");
      Node CForCase1=new Node(AForCase1,"C");
      Node DForCase1=new Node(BForCase1, "D");
      Node EForCase1=new Node(BForCase1, "E");
      Node FForCase1=new Node(CForCase1, "F");
      Node GForCase1=new Node(CForCase1, "G");

      yield return new object[]{GForCase1, DForCase1, AForCase1};

      //Tree 2 Unbalanced -

      Node AForCase2 =new Node(null, "A"); //root
      Node BForCase2=new Node(AForCase2,"B");//children of A
      Node CForCase2=new Node(AForCase2,"C");
      Node DForCase2=new Node(BForCase2, "D");//children of B
      Node EForCase2=new Node(BForCase2, "E");
      Node FForCase2=new Node(DForCase2, "F");//child of D
      Node GForCase2=new Node(CForCase2, "G");//child of C

      yield return new object[]{CForCase2, FForCase2, AForCase2};

      

    }
}


