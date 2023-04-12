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

    public void AddAll(IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Add(item);
        }
    }

    public void AddFirst(T item)
    {
        Add(item, 0);
    }

    public void Clear()
    {
        _length = 0;
        _head = null;
        _tail = null;
    }

    public void Add(T item, int index)
    {
        if (index < 0 || index > _length)
        {
            throw new IndexOutOfRangeException();
        }

        MyNode newNode = new MyNode(item);
        
        if (index == 0)
        {
            newNode.next = _head;
            _head.prev = newNode;
            _head = newNode;
        }
        else if (index == _length)
        {
            newNode.prev = _tail;
            _tail.next = newNode;
            _tail = newNode;
        }
        else
        {
            MyNode temp = _head;
            for (int i = 0; i < _length; i++)
            {
                temp = temp.next;
            }

            newNode.next = temp.next;
            newNode.prev = temp;
            temp.next.prev = newNode;
            temp.next = newNode;
        }

        _length++;
    }

    public void Replace(T item, int index)
    {
        if (index < 0 || index >= _length)
            throw new IndexOutOfRangeException();

        MyNode newNode = new MyNode(item);
        MyNode temp = _head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.next;
        }

        if (temp.prev == null)
        {
            newNode.next = temp.next;
            temp.next.prev = newNode;
            _head = newNode;
        }
        else if (temp.next == null)
        {
            newNode.prev = temp.prev;
            temp.prev.next = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.prev = temp.prev;
            newNode.next = temp.next;
            newNode.prev.next = newNode;
            newNode.next.prev = newNode;
        }
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

    public T GetFirst()
    {
        return _head.data;
    }

    public T GetLast()
    {
        return _tail.data;
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

    public int Size()
    {
        return _length;
    }
    
}
