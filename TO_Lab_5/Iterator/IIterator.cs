namespace TO_Lab_5.Iterator
{
    interface IIterator<out T>
    {
        bool hasNext();
        T getnext();
    }
}