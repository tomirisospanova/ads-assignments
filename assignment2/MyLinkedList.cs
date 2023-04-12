namespace assignment2;

public class MyLinkedList<T>
{

    private class MyNode
    {
        public readonly T data;
        public MyNode prev;
        public MyNode next;

        public MyNode(T data)
        {
            this.data = data;
        }
    }

    private MyNode head;
    private int length;

    public void Add(T item)
    {
        MyNode newNode = new MyNode(item);
        length++;
        if (head == null)
        {
            head = newNode;
            return;
        }

        MyNode temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
        temp.next.prev = temp;
    }

    
}

