
using CarCheck;

public class ClerkRepo : IGenericRepo<Clerk>
{
    public int Add(Clerk obj)
    {
        if (Program.DataStoreS.clerks is null)
        {
            Program.DataStoreS.clerks = new List<Clerk> { obj };
        }
        else
           Program.DataStoreS.clerks.Add(obj);
        return obj.id;
    }

    public int Delete(Clerk obj)
    {
       Program.DataStoreS.clerks.Remove(obj);
        return obj.id;
    }

    public Clerk? Get(int id)
    {
        Clerk? clerk =Program.DataStoreS.clerks.FirstOrDefault(reciever => reciever.id == id);
        if (clerk == null)
        {
            return null;
        }
        else return clerk;

    }

    public int Update(Clerk obj)
    {
        Clerk? clerk =Program.DataStoreS.clerks.FirstOrDefault(reciever => reciever.id == obj.id);
        if (clerk != null)
        {
           Program.DataStoreS.clerks.Remove(clerk);
           Program.DataStoreS.clerks.Add(obj);
            return obj.id;
        }
        else
            return 0;
    }

    public List<Clerk> GetAll()
    {
        return Program.DataStoreS.clerks;
    }
}