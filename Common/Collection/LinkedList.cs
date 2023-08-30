using System;
using Collection.Models;

namespace Collection
{
    /// <summary>
    /// The Leet Code Linked List data structure helper
    /// </summary>
    public static class LinkedList
    {
        public static ListNode CreateLinkedListFromArray(int[] array)
        {
            ListNode head = null;
            ListNode curr = null;

            foreach(var item in array)
            {
                var node = new ListNode(item);
                
                if (head == null)
                {
                    head = node;
                    curr = head;
                }
                else
                {
                    curr.next = node;
                    curr = curr.next;
                }
            }

            return head;
        }

        public static void DisplayLinkedList(ListNode head)
        {
            for (var curr = head; curr != null; curr = curr.next)
            {
                Console.Write($"{curr.val} -> ");
            }

            Console.WriteLine("null");
        }
    }
}
