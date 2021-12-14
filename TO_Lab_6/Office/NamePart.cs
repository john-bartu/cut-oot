namespace TO_Lab_6;

public class NamePart
{
    public Flyweight<string> Text { get; set; }
    public NamePart? Next { get; set; }

    public NamePart(Flyweight<string> text)
    {
        Text = text;
        Next = null;
    }


    public Flyweight<string> GetPart()
    {
        return Text;
    }

    public NamePart? GetNext()
    {
        return Next;
    }

    public void SetNext(NamePart? nextPart)
    {
        Next = nextPart;
    }

    public override string ToString()
    {
        if (Next != null)
            return Text.GetState() + " " + GetNext();
        else
            return Text.GetState();
    }

    public string ToStringId()
    {
        if (Next != null)
            return $"{Text.GetHashCode():X8} {GetNext()!.ToStringId()}";
        else
            return $"{Text.GetHashCode():X8}";
    }

    public bool HasNext()
    {
        if (Next != null)
            return true;
        else
            return false;
    }
}