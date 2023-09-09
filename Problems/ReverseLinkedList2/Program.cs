using Collection;
using Collection.Models;

namespace ReverseLinkedList2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode head = LinkedList.CreateLinkedListFromArray(new int[] { 1, 2, 3, 4, 5 });
            LinkedList.DisplayLinkedList(head);
            LinkedList.DisplayLinkedList(ReverseBetween(head, 1, 3));
        }

        public static ListNode ReverseBetween(ListNode head, int left, int right)
        {
            // Return from un-neccessary computation
            if (left == right)
            {
                return head;
            }

            // Iterate until left
            ListNode curr = head;
            ListNode prev = null;
            for (int i = 1; i < left; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            // Iterate from left to right and reverse
            ListNode lHead = curr;
            for (int i = left; i <= right; i++)
            {
                ListNode temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }

            // Check if head itself has to be modified or not
            if (lHead.next != null)
            {
                ListNode tHead = lHead.next;
                tHead.next = prev;
                lHead.next = curr;
            }
            else
            {
                head = prev;
                lHead.next = curr;
            }

            return head;
        }
    }
}