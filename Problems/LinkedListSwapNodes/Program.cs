using Collection;
using Collection.Models;

namespace LinkedListSwapNodes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListNode head = LinkedList.CreateLinkedListFromArray(new int[] { 1, 2, 3, 4, 5 });
            LinkedList.DisplayLinkedList(head);
            SwapNodes(head, 2);
            LinkedList.DisplayLinkedList(head);
        }

        public static ListNode SwapNodes(ListNode head, int k)
        {
            ListNode kNode = null;
            int count = 0;

            for (var curr = head; curr != null; curr = curr.next)
            {
                count++;

                if (count == k)
                {
                    kNode = curr;
                }
            }

            int lastK = (count + 1) - k;
            count = 0;

            for (var curr = head; curr != null; curr = curr.next)
            {
                count++;

                if (count == lastK)
                {
                    var temp = kNode.val;
                    kNode.val = curr.val;
                    curr.val = temp;
                }
            }

            return head;
        }
    }
}