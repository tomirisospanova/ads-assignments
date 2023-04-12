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

}