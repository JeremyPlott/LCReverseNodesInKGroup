These node lists make my head hurt.Lots of stepping through in the IDE.
```
'public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k)
{

    //the first thing we need to do is create the variables we are going to use to track our nodes
    ListNode currentNode = head;
    ListNode previousNode = null;
    ListNode nextNode = null;
    ListNode remainingNodes = head;

    //this is just an iterating variable for our loops
    var amountReversed = 0;

    //this is important for reaching the end of the node list. It will return the modified head
    //after running through to the end of the list
    for (int node = 0; node < k; node++)
    {
        if (remainingNodes == null) return head;

        remainingNodes = remainingNodes.next;
    }

    //here is where all the shuffling happens. We need several variables to track the nodes
    //without overwriting or going too far.
    while (amountReversed < k)
    {
        //this is used to hold our place moving forward while we switch nodes around.
        //iterates nextNode as currentNode moves forward.
        //ex: current node holds 1, next node gets set to 2.
        nextNode = currentNode.next;

        //everything after the current node becomes whatever is in previousNode.
        //previousNode is where we are building our reversed list.
        //ex: current node holds 2-3-4-5, previous node holds 1.
        //after this line, current node will hold 2-1
        currentNode.next = previousNode;

        //now that we have reversed some nodes, we need to store that somewhere
        //ex: previous node holds 1, we overwrite it with 2-1 since we need to continue through the list
        previousNode = currentNode;

        //now we iterate current node and continue the shuffle loop.
        //ex: we set nextNode at the top to hold 3-4-5
        //current node is 2-1 at the moment. 1 and 2 have been swapped. we need 3 next.
        //current node becomes 3-4-5 and previous node is holding our 2-1.
        currentNode = nextNode;

        amountReversed++;
    }

    //once we are at our top level of recursion, head is still set to node 1.
    //node 1 is currently shuffled to the end of the reversed list, so next will add after node 1.
    //if we hit the return at the top of the method that means we have hit the end of the list
    //and just need to add that to the very last reversed node which is node 1.
    head.next = ReverseKGroup(currentNode, k);

    return previousNode;
}
}
```