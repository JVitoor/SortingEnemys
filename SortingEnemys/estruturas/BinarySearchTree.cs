using System;
using SortingEnemys.enemys;

namespace SortingEnemys.estruturas
{
    public class BinarySearchTree
    {
        private TreeNode root;

        public void Insert(Enemy data)
        {
            root = InsertRec(root, data);
        }

        private TreeNode InsertRec(TreeNode root, Enemy data)
        {
            if (root == null)
            {
                root = new TreeNode(data);
                return root;
            }

            if (data.GetName().CompareTo(root.Data.GetName()) < 0)
                root.Left = InsertRec(root.Left, data);
            else if (data.GetName().CompareTo(root.Data.GetName()) > 0)
                root.Right = InsertRec(root.Right, data);

            return root;
        }

        public Enemy Search(string name)
        {
            TreeNode result = SearchRec(root, name);
            return result?.Data;
        }

        private TreeNode SearchRec(TreeNode root, string name)
        {
            if (root == null || root.Data.GetName() == name)
                return root;

            if (name.CompareTo(root.Data.GetName()) < 0)
                return SearchRec(root.Left, name);

            return SearchRec(root.Right, name);
        }

        public void InOrderTraversal()
        {
            InOrderRec(root);
        }

        private void InOrderRec(TreeNode root)
        {
            if (root != null)
            {
                InOrderRec(root.Left);
                Console.WriteLine($"- {root.Data.GetName()}, Nível {root.Data.GetLevel()}");
                InOrderRec(root.Right);
            }
        }
    }

    public class TreeNode
    {
        public Enemy Data;
        public TreeNode Left, Right;

        public TreeNode(Enemy data)
        {
            Data = data;
            Left = Right = null;
        }
    }
}