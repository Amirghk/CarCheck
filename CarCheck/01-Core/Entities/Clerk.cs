using CarCheck;

public class Clerk
{
    public readonly string name;
    public readonly int id;

    public Clerk(string name)
    {
        this.name = name;
        if (Program.DataStoreS.clerks.Count == 0)
        {
            id = 0;
        }
        else
        {
            id = Program.DataStoreS.clerks.Max(c => c.id) + 1;
        }
    }
}