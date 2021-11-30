namespace TO_Lab_5.Iterator
{
    public interface IIterator<out T>
    {
        bool hasNext();
        T getNext();
    }
}