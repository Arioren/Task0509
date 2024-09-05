using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task0509
{
    public class TreeNode
    {
        public float val { get { return (float)(MinSeverity + MaxSeverity) / 2; } }
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }

        public List<string> Defenses { get; set; }

        public TreeNode left { get; set; }
        public TreeNode right { get; set; }

        public void print()
        {
            string result = "[" + MinSeverity + " - " + MaxSeverity + "] " + "Defenses: " + string.Join(", ", Defenses);
            Console.WriteLine(result);
        }
    }


    public class DefenceStrategiesBST
    {
        public TreeNode root { get; set; }

        public void insert(TreeNode node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                recutsiveInsert(root, node);
            }
        }

        private void recutsiveInsert(TreeNode root, TreeNode node)
        {
            if (node.val < root.val)
            {
                if (root.left == null)
                {
                    root.left = node;
                }
                else
                {
                    recutsiveInsert(root.left, node);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = node;
                }
                else
                {
                    recutsiveInsert(root.right, node);
                }
            }
        }

        public void PreOrderPrint()
        {
            recutsivePrint("Root: ", root, 0);
            Console.WriteLine();
        }

        private void recutsivePrint(string result, TreeNode root, int depth)
        {
            if (root != null)
            {
                string makaf = "";
                for (int i = 0; i < depth; i++)
                {
                    makaf += "-";
                }
                Console.Write(makaf + result);
                root.print();
                recutsivePrint("Left: ", root.left, depth + 1);
                recutsivePrint("Right: ", root.right, depth + 1);
            }
        }

        internal TreeNode FindSeverityPreOrder(int severity)
        {
             return recutsiveFindSeverityPreOrder(severity, root);
        }

        private TreeNode recutsiveFindSeverityPreOrder(int severity, TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            if (severity < root.MinSeverity )
            {
                return recutsiveFindSeverityPreOrder(severity, root.left);
            }
            else if (severity > root.MaxSeverity)
            {
                return recutsiveFindSeverityPreOrder(severity, root.right);
            }
            else
            {
                return root;
            }
        }

        internal TreeNode balanced()
        {
            // Store nodes of given BST in sorted order 
            List<TreeNode> nodes = new List<TreeNode>();
            storeBSTNodes(root, nodes);

            // Constructs BST from nodes[] 
            int n = nodes.Count;
            return buildTreeUtil(nodes, 0, n - 1);
        }

        private TreeNode buildTreeUtil(List<TreeNode> nodes, int start, int end)
        {
            // base case 
            if (start > end)
            {
                return null;
            }

            /* Get the middle element and make it root */
            int mid = (start + end) / 2;
            TreeNode node = nodes[mid];

            /* Using index in Inorder traversal, construct 
               left and right subtress */
            node.left = buildTreeUtil(nodes, start, mid - 1);
            node.right = buildTreeUtil(nodes, mid + 1, end);

            return node;
        }

        private void storeBSTNodes(TreeNode root, List<TreeNode> nodes)
        {
            // Base case 
            if (root == null)
            {
                return;
            }

            // Store nodes in Inorder (which is sorted 
            // order for BST) 
            storeBSTNodes(root.left, nodes);
            nodes.Add(root);
            storeBSTNodes(root.right, nodes);
        }

        internal void InOrderPrint()
        {
            recutsiveInOrderPrint(root);
        }

        private void recutsiveInOrderPrint(TreeNode root)
        {
            if (root != null)
            {
                recutsiveInOrderPrint(root.left);
                root.print();
                recutsiveInOrderPrint(root.right);
            }
        }
    }

}
