namespace assignment2;

public class MyLinkedList<T>
{

    private class MyNode
    {
        private readonly T data;
        private MyNode next;

        public MyNode(T data)
        {
            this.data = data;
        }
    }


}