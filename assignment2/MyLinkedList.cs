using System.Collections;

namespace assignment2;

// MyLinkedList extends IEnumerable to be iterable
// MyLinkedList can take any objects (T)
public class MyLinkedList<T> : IEnumerable<T>
{
    
    // Private class inside Linked List that defines the node structure
    private class MyNode
    {
        
        public readonly T data; // Data stored inside the node
        public MyNode prev; // Reference to previous node
        public MyNode next; // Reference to next node

        public MyNode(T data)
        {
            this.data = data;
        }
        
    }

    private MyNode _head; // Reference to the first node
    private MyNode _tail; // Reference to the last node
    private int _length; // The number of nodes in Linked List

    // Add item to the end of Linked List
    public void Add(T item)
    {
        // Create new node with item inside (as data)
        MyNode newNode = new MyNode(item);
        
        // Check if Linked List is empty
        if (_length == 0)
        {
            // Put new node as first and last node of linked list if its empty
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // Set the previous node of the new node to the tail
            newNode.prev = _tail;
            
            // Reference to the next node in the current tail to the new node
            _tail.next = newNode;
            
            // Update the current tail to new node
            _tail = newNode;
        }

        // Increment the length of Linked List
        _length++;
    }

    // Add items from collection to the end of Linked List
    public void AddAll(IEnumerable<T> collection)
    {
        // Iterate over the items in collection
        foreach (T item in collection)
        {
            // Call Add method for every item in the collection
            Add(item);
        }
    }

    // Add new item to the start of Linked List
    public void AddFirst(T item)
    {
        // Call Add method at specific index
        Add(item, 0);
    }

    // Clear Linked List
    public void Clear()
    {
        _length = 0;
        _head = null;
        _tail = null;
    }

    // Add item at specific index
    public void Add(T item, int index)
    {
        // Check if index is out of range
        if (index < 0 || index > _length)
        {
            // Throw an exception
            throw new IndexOutOfRangeException();
        }

        // Create new node with given item as data
        MyNode newNode = new MyNode(item);
        
        // Check if given index is 0
        if (index == 0)
        {
            // Place current head as a reference to the next node of new node
            newNode.next = _head;
            
            // Place new node as a reference to the previous node of current head
            _head.prev = newNode;
            
            // Update current head node
            _head = newNode;
        }
        
        // Check if index is equal to the length of Linked List
        else if (index == _length)
        {
            // Place current tail as a reference to the previous node of new node
            newNode.prev = _tail;
            
            // Place new node as a reference to the next node of current tail
            _tail.next = newNode;
            
            // Update current tail node
            _tail = newNode;
        }
        else
        {
            // Find node at given index using iteration
            MyNode temp = _head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            
            // Place current node as a reference to the new node's next node
            newNode.next = temp;
            // Place current node's previous node as a reference to the new node's previous node
            newNode.prev = temp.prev;
            
            // Update current node's previous and next node
            temp.prev.next = newNode;
            temp.next.prev = newNode;
        }
    
        // Incrementing length of Linked List
        _length++;
    }

    // Replace item at specific index
    public void Replace(T item, int index)
    {
        // Check if index is out of range
        if (index < 0 || index >= _length)
            throw new IndexOutOfRangeException();

        // Create new node with given item as data
        MyNode newNode = new MyNode(item);
        // Find node at given index using iteration
        MyNode temp = _head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.next;
        }
        
        // Check if given index is linked list's head
        if (temp.prev == null)
        {
            // Change references to and for the next node 
            newNode.next = temp.next;
            temp.next.prev = newNode;
            // Update current head of Linked List
            _head = newNode;
        }
        
        // Check if given index is linked list's tail
        else if (temp.next == null)
        {
            // Replace references to and for the previous node
            newNode.prev = temp.prev;
            temp.prev.next = newNode;
            // Update current tail of Linked List
            _tail = newNode;
        }
        else
        {
            // Replacing the references for the previous and next nodes
            newNode.prev = temp.prev;
            newNode.next = temp.next;
            newNode.prev.next = newNode;
            newNode.next.prev = newNode;
        }
    }
    
    // Get the item at specific index
    public T Get(int index) 
    {
        // Check if index is out of range
        if (index >= _length)
            throw new IndexOutOfRangeException();
        
        // Find node at given index using iteration
        MyNode temp = _head;
        for (int i = 0; i < index; i++) {
            temp = temp.next;
        }
        
        // Return data inside found node
        return temp.data;
    }

    // Get head's data
    public T GetFirst()
    {
        return _head.data;
    }

    // Get tail's data
    public T GetLast()
    {
        return _tail.data;
    }

    // Remove item at specific index
    public void Remove(int index)
    {
        // Check if index is out of range
        if (index < 0 || index >= _length)
            throw new IndexOutOfRangeException();

        // Find node at given index using iteration 
        MyNode temp = _head;
        for (int i = 0; i < index; i++)
        {
            temp = temp.next;
        }

        // Check if there is reference to the next node in found node
        if (temp.next != null)
        {
            temp.next.prev = temp.prev;
        }
        // Check if found node is the head of Linked List
        if (temp.prev == null)
        {
            _head = temp.next;
        }
        else
        {
            temp.prev.next = temp.next;
        }
        
        // Decrement the length of Linked List
        _length--;
    }

    // Check if Linked List has specific item
    public bool Contains(T item)
    {
        // Iterate over nodes in Linked List
        MyNode temp = _head;
        for (int i = 0; i < _length; i++)
        {
            // Check if each node's data is equal to given data
            if (temp.data.Equals(item))
                // Return true if found
                return true;

            temp = temp.next;
        }
        // Return false after iteration if was not found
        return false;
    }

    // Get the length of Linked List
    public int Size()
    {
        return _length;
    }
    
    // IEnumerator to iterate through nodes' data in Linked List
    public IEnumerator<T> GetEnumerator()
    {
        var temp = _head;

        while (temp != null)
        {
            yield return temp.data;
            temp = temp.next;
        }
    }
    
    // Non-generic IEnumerator
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}