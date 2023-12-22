namespace ValidBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Valid Tree : {new Program().ValidateBinaryTreeNodes(2, new int[] { 1, 0 }, new int[] { -1, -1 })}");
        }

        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            var root = ConstructTree(n, leftChild, rightChild);
            var visisted = new HashSet<int>();
            var dfs = this.DFS(root, visisted);
            return dfs && visisted.Count == n;
        }

        public Node ConstructTree(int n, int[] leftChild, int[] rightChild)
        {
            // The root node
            Node root = null;

            // A Map to store the node object to reference later
            var map = new Dictionary<int, Node>();

            for (int i = 0; i < n; i++)
            {
                Node curr;
                if (map.ContainsKey(i))
                {
                    curr = map[i];
                }
                else
                {
                    curr = new Node(i);
                    map.Add(i, curr);
                }
                
                int left = leftChild[i];
                int right = rightChild[i];

                if (left != -1)
                {
                    if (map.ContainsKey(left))
                    {
                        curr.Left = map[left];
                    }
                    else
                    {
                        curr.Left = new Node(left);
                        map.Add(left, curr.Left);
                    }
                }

                if (right != -1)
                {
                    if (map.ContainsKey(right))
                    {
                        curr.Right = map[right];
                    }
                    else
                    {
                        curr.Right = new Node(right);
                        map.Add(right, curr.Right);
                    }
                }

                // Update root node if it does not exist, or if the current node is the root node
                if (root == null || root.Value == left || root.Value == right)
                {
                    root = curr;
                }
            }

            return root;
        }

        public bool DFS(Node node, HashSet<int> visisted)
        {
            if (node == null)
                return true;

            bool isTree = visisted.Add(node.Value);
            if (!isTree)
            {
                return false;
            }

            bool isTreeLeft = this.DFS(node.Left, visisted);
            bool isTreeRight = this.DFS(node.Right, visisted);

            return isTreeLeft && isTreeRight;
        }

        public class Node
        {
            public int Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public Node(int value, Node left = null, Node right = null)
            {
                this.Value = value;
                this.Left = left;
                this.Right = right;
            }
        }
    }
}