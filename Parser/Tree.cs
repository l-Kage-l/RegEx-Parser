using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parser
{
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Index { get; set; }
        public char[] Data { get; set; }
    }

    public class BinaryTree
    {
        public Node Root { get; set; }

        public bool Add(Node nod)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (nod.Index < after.Index) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (nod.Index > after.Index) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            if (this.Root == null)//Tree is empty
                this.Root = nod;
            else
            {
                if (nod.Index < before.Index)
                    before.LeftNode = nod;
                else
                    before.RightNode = nod;
            }

            return true;
        }

        public Node Find(int value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            Remove(this.Root, value);
        }

        public Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Index) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Index)
                parent.RightNode = Remove(parent.RightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Index = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Index);
            }

            return parent;
        }

        public int MinValue(Node node)
        {
            int minv = node.Index;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Index;
                node = node.LeftNode;
            }

            return minv;
        }

        public Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Index) return parent;
                if (value < parent.Index)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        public int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }

        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }
    }

}
