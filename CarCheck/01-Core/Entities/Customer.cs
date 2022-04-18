using CarCheck;

public class Customer
{
    public readonly int id;
    public readonly string name;

    public Customer(string name)
    {
        this.name = name;
        if (Program.DataStoreS.customers.Count == 0)
        {
            id = 0;
        }
        else
        {
            id = Program.DataStoreS.customers.Max(c => c.id) + 1;
        }
    }
}