namespace TO_Lab_6;

public class Tools
{
    public static string RandomArrow()
    {
        string output = "";
        for (int i = 0; i <= Random.Shared.Next(2); i++)
        {
            output += "-";
        }

        output += ">";

        return output;
    }
}