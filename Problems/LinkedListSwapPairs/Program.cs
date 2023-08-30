using Collection;
using Collection.Models;

namespace LinkedListSwapPairs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListNode head = LinkedList.CreateLinkedListFromArray(new int[] { 1, 2, 3, 4 });
            LinkedList.DisplayLinkedList(head);
            LinkedList.DisplayLinkedList(SwapPairs(head));
        }

        public static ListNode SwapPairs(ListNode head)
        {
            int count = 0;
            ListNode prev = null;
            ListNode curr = head;

            while (curr != null)
            {
                count++;
                var next = curr.next;

                // Even position node
                if (count % 2 == 0)
                {
                    if (count == 2)
                    {
                        head = curr;
                    }

                    curr.next = prev;
                }
                // Odd position node
                else
                {
                    // Three values ahead are present
                    if (curr.next != null && curr.next.next != null && curr.next.next.next != null)
                    {
                        curr.next = curr.next.next.next;
                    }
                    // Two values ahead are present
                    else if (curr.next != null && curr.next.next != null)
                    {
                        curr.next = curr.next.next;
                    }
                    // Value ahead is present
                    else if (curr.next != null)
                    {
                        curr.next = null;
                    }
                }

                prev = curr;
                curr = next;
            }

            return head;
        }
    }
}