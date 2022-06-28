using System;
namespace DataStructures
{
    public class BinaryTreeNode : IComparable
    {
        protected int nodeIndex = 0; // Allows the tree to be flattened
        protected IComparable nodeValue = null;
        protected BinaryTreeNode leftNode = null;
        protected BinaryTreeNode rightNode = null;
        public int NumOfChildren
        {
            get
            {
                return (CountChildren());
            }
        }
        public int Index
        {
            get
            {
                return nodeIndex;
            }
        }
        public BinaryTreeNode Left
        {
            get
            {
                return leftNode;
            }
        }
        public BinaryTreeNode Right
        {
            get
            {
                return rightNode;
            }
        }
        public IComparable GetValue
        {
            get
            {
                return nodeValue;
            }
        }

        public BinaryTreeNode() { }
        public BinaryTreeNode(IComparable value)
        {
            nodeValue = value;
        }
        // These 2 contructors allows the tree to be flattened.
        public BinaryTreeNode(int index)
        {
            nodeIndex = index;
        }
        public BinaryTreeNode(IComparable value, int index)
        {
            nodeValue = value;
            nodeIndex = index;
        }
        public int CountChildren()
        {
            int currCount = 0;
            if(leftNode != null)
            {
                ++currCount;
                currCount += leftNode.CountChildren();
            }
            if(rightNode != null)
            {
                ++currCount;
                currCount += rightNode.CountChildren();
            }
            return currCount;
        }
        public void AddNode(BinaryTreeNode node)
        {
            if(node.nodeValue.CompareTo(nodeValue) < 0)
            {
                if(leftNode == null)
                {
                    leftNode = node;
                } else
                {
                    leftNode.AddNode(node);
                }
            } else if(node.nodeValue.CompareTo(nodeValue) >= 0)
            {
                if(rightNode == null)
                {
                    rightNode = node;
                } else
                {
                    rightNode.AddNode(node);
                }
            }
        }
        public bool AddUniqueNode(BinaryTreeNode node)
        {
            bool isUnique = true;
            if(node.nodeValue.CompareTo(nodeValue) < 0)
            {
                if(leftNode == null)
                {
                    leftNode = node;
                } else
                {
                    leftNode.AddNode(node);
                }
            } else if(node.nodeValue.CompareTo(nodeValue) > 0)
            {
                if(rightNode == null)
                {
                    rightNode = node;
                } else
                {
                    rightNode.AddNode(node);
                }
            } else
            {
                isUnique = false;
                // throw an exception here
            }
            return isUnique;
        }
        public BinaryTreeNode DepthFirstSearch(IComparable targetObj)
        {
            BinaryTreeNode retObj = null;
            int comparisonResult = targetObj.CompareTo(nodeValue);
            if(comparisonResult == 0)
            {
                retObj = this;
            } else if(comparisonResult > 0)
            {
                if(rightNode != null)
                {
                    retObj = rightNode.DepthFirstSearch(targetObj);
                }
            } else if(comparisonResult < 0)
            {
                if(leftNode != null)
                {
                    retObj = leftNode.DepthFirstSearch(targetObj);
                }
            }
            return retObj;
        }
        public void PrintDepthFirst()
        {
            if(leftNode != null)
            {
                leftNode.PrintDepthFirst();
            }
            Console.WriteLine(this.nodeValue.ToString());
            try
            {
                Console.WriteLine($"\tContains Left: {leftNode.nodeValue.ToString()}");
            } catch
            {
                Console.WriteLine($"\tContains Left: {null}");
            }
            try
            {
                Console.WriteLine($"\tContains Right: {rightNode.nodeValue.ToString()}");
            } catch
            {
                Console.WriteLine($"\tContains Right: {null}");
            }
            if(rightNode != null)
            {
                rightNode.PrintDepthFirst();
            }
        }
        public void RemoveLeftNode ()
        {
            leftNode = null;
        }
        public void RemoveRightNode()
        {
            rightNode = null;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
