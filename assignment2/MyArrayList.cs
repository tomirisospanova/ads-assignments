namespace assignment2;

public class MyArrayList<T> 
{
    
    private T[] _hiddenArr;
    private int _length;

    public MyArrayList() : this(5) {}

    public MyArrayList(int initCapacity) 
    {
        _hiddenArr = new T[initCapacity];
    }

    private void IncreaseArray() 
    {
        int newSize = (int)(_hiddenArr.Length * 1.5);
        T[] newArr = new T[newSize];

        for (int i = 0; i < _hiddenArr.Length; i++) 
        {
            newArr[i] = _hiddenArr[i];
        }

        _hiddenArr = newArr;
    }
    
    public void Add(T item)
    {
        if (_length == _hiddenArr.Length)
        {
            IncreaseArray();
        }

        _hiddenArr[_length++] = item;
    }

    public T Get(int index)
    {
        if (index >= _hiddenArr.Length) 
            throw new IndexOutOfRangeException();

        return _hiddenArr[index];
    }

    public int Size()
    {
        return _length;
    }
    
    

    public int IndexOf(T item)
    {
        for (int i = 0; i < _hiddenArr.Length; i++)
        {
            if (_hiddenArr[i].Equals(item))
                return i;
        }

        return -1;
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index == -1)
            return false;
        
        for (int i = index; i < _hiddenArr.Length - 1; i++)
        {
            _hiddenArr[i] = _hiddenArr[i + 1];
        }

        _length--;

        return true;
    }

    public void RemoveAll(IEnumerable<T> collection)
    {
        foreach(T item in collection)
        {
            Remove(item);
        }
    }

    public void Clear()
    {
        _hiddenArr = new T[5];
        _length = 0;
    }

    public T[] ToArray()
    {
        T[] outputArr = new T[_length];

        for (int i = 0; i < _length; i++)
        {
            outputArr[i] = _hiddenArr[i];
        }

        return outputArr;
    }


}