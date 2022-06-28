using System;
namespace DataStructures
{
    public class BinaryTree
    {
        protected int counter = 0;
        protected BinaryTreeNode root = null;
        public int TreeSize
        {
            get
            {
                return counter;
            }
        }

        public BinaryTree()
        {

        }
        public BinaryTree(IComparable value, int index)
        {
            BinaryTreeNode node = new BinaryTreeNode(value, index);
            root = node;
            counter = 1;
        }
        public BinaryTree(IComparable value)
        {
            BinaryTreeNode node = new BinaryTreeNode(value);
            root = node;
            counter = 1;
        }


        public void AddNode(IComparable value, int index)
        {
            BinaryTreeNode node = new BinaryTreeNode(value, index);
            ++counter;
            if(root == null)
            {
                root = node;
            } else
            {
                root.AddNode(node);
            }
        }
        public int AddNode(IComparable value)
        {
            BinaryTreeNode node = new BinaryTreeNode(value);
            ++counter;
            if(root == null)
            {
                root = node;
            } else
            {
                root.AddNode(node);
            }
            return counter - 1;
        }
        public BinaryTreeNode SearchDepthFirst(IComparable value)
        {
            return root.DepthFirstSearch(value);
        }
        public void Print()
        {
            root.PrintDepthFirst();
        }
        public BinaryTreeNode GetRoot()
        {
            return root;
        }
    }
}
