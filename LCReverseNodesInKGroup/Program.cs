using System;
using System.Collections.Generic;

namespace LCSwapNodesInPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            var reverseAmount = 3;

            ListNode alteredList = ReverseKGroup(head, reverseAmount);

            while (alteredList != null)
            {
                Console.WriteLine(alteredList.val);
                alteredList = alteredList.next;
            }

            ListNode ReverseKGroup(ListNode head, int k)
            {
                ListNode currentNode = head;
                ListNode previousNode = null;
                ListNode nextNode = null;
                ListNode remainingNodes = head;

                var amountReversed = 0;

                //this is important for the recursive calls or reaching the end of a node list
                //returns the rest of the list after k
                for (int node = 0; node < k; node++)
                {
                    if (remainingNodes == null) return head;

                    remainingNodes = remainingNodes.next;
                }

                while (amountReversed < k)
                {
                    //iterates nextNode
                    //current still starts 1 before next
                    //this is used to hold our place moving forward while we switch nodes around
                    nextNode = currentNode.next;

                    //2-3-4-5 : 1
                    //2-1
                    //everything after the first node becomes whatever is in previousNode
                    currentNode.next = previousNode;

                    //1 : 2-1
                    //previous set to 2-1
                    previousNode = currentNode;

                    //2-1 becomes 3-4-5 
                    currentNode = nextNode;

                    amountReversed++;
                }

                //head is still set to whatever the remainingNodes for-loop took it to at the start
                head.next = ReverseKGroup(currentNode, k);

                //this is set to the reversed segment 3-2-1
                return previousNode;
            }
        }
    }

    //0 node
    //current node which will be added after recursive call
    //k
    //iterator

    //account for remainder of list

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}