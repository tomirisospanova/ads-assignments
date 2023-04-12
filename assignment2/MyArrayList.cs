namespace assignment2;

public class MyArrayList<T> 
{

    
    private object[] _hiddenArr;
    private int _length;

    public MyArrayList() : this(5) {}

    public MyArrayList(int initCapacity) 
    {
        _hiddenArr = new object[initCapacity];
    }

    private void IncreaseArray() 
    {
        int newSize = (int)(_hiddenArr.Length * 1.5);
        object[] newArr = new object[newSize];

        for (int i = 0; i < _hiddenArr.Length; i++) 
        {
            newArr[i] = _hiddenArr[i];
        }

        _hiddenArr = newArr;
    }


    
}