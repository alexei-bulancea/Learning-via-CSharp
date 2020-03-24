using System;
/// <summary>
/// 2. Add Two Numbers
/// 
/// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit.
/// Add the two numbers and return it as a linked list.
/// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
/// </summary>
namespace Learning.LeetCode_Medium
{
    public class Node
    {
        public int value;
        public Node next;
        public Node()
        {

        }
        public Node(int nodeValue)
        {
            value = nodeValue;
        }
    }

    public class Add_Two_Numbers
    {
        public Add_Two_Numbers()
        {
            var firstList = new Node(2);
            firstList.next = new Node(4);
            firstList.next.next = new Node(3); // 342
            var secondList = new Node(5);
            secondList.next = new Node(6);
            secondList.next.next = new Node(4); // 465

            var result = AddTwoLists(firstList, secondList);
            ShowList(result);

            Console.ReadKey();
        }

        public void ShowList(Node l1)
        {
            do
            {
                Console.Write(l1.value + " -> ");
                l1 = l1.next;
            } while (l1 != null);
        }

        public Node AddTwoLists(Node l1, Node l2)
        {
            int transmitValue = 0;
            var tempFirst = l1;
            var tempSecond = l2;

            var currentValue = tempFirst.value + tempSecond.value;
            transmitValue = currentValue / 10;

            Node resultList = new Node(currentValue % 10);
            var tempResult = resultList;

            do
            {
                tempFirst = tempFirst.next;
                tempSecond = tempSecond.next;

                currentValue = tempFirst.value + tempSecond.value + transmitValue;
                transmitValue = currentValue / 10;
                tempResult.next = new Node(currentValue % 10);
                tempResult = tempResult.next;

            } while (tempFirst.next != null || tempSecond.next != null);

            return resultList;
        }
    }
}
