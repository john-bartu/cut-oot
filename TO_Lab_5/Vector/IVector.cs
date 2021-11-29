namespace TO_Lab_5.Vector
{
    public interface IVector
    {
        double abs();
        double cdot(IVector param);
        double[] getComponents();
    }
}