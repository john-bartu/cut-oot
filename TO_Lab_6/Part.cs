namespace TO_Lab_6;

public class Part
{
    public Part(Flyweight<string> part, Part next)
    {
        this.part = part;
        this.next = next;
    }

    private Flyweight<string> part;
    private Part next;

    public Part GetNext()
    {
        return next;
    }

    public override string ToString()
    {
        return part + " " + GetNext();
    }
}