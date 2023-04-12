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

    private MyNode _head;
    private MyNode _tail;
    private int _length;

    public void Add(T item)
    {
        MyNode newNode = new MyNode(item);
        
        if (_length == 0)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.prev = _tail;
            _tail.next = newNode;
            _tail = newNode;
        }

        _length++;
        
    }
    
    public T Get(int index) 
    {
        if (index >= _length) 
            throw new IndexOutOfRangeException();
        
        MyNode temp = _head;
        for (int i = 0; i < index; i++) {
            temp = temp.next;
        }
        
        return temp.data;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= _length)
            throw new IndexOutOfRangeException();

        MyNode temp = _head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.next;
        }

        if (temp.next != null)
        {
            temp.next.prev = temp.prev;
        }

        if (temp.prev == null)
        {
            _head = temp.next;
        }
        else
        {
            temp.prev.next = temp.next;
        }

        _length--;
    }
    
}
