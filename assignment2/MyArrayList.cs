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



    
}