using CarCheck;

public class RecieptRepo : IGenericRepo<Reciept>
{
    public int Add(Reciept obj)
    {
        if (Program.DataStoreS.reciepts is null)
        {
            Program.DataStoreS.reciepts = new List<Reciept> { obj };
        }
        else
            Program.DataStoreS.reciepts.Add(obj);
        return obj.id;
    }

    public int Delete(Reciept obj)
    {
        Program.DataStoreS.reciepts.Remove(obj);
        return obj.id;
    }

    public Reciept? Get(int id)
    {
        Reciept? receipt = Program.DataStoreS.reciepts.FirstOrDefault(receipt => receipt.id == id);
        if (receipt == null)
        {
            return null;
        }
        else return receipt;

    }

    public int Update(Reciept obj)
    {
        Reciept? receipt = Program.DataStoreS.reciepts.FirstOrDefault(receipt => receipt.id == obj.id);
        if (receipt != null)
        {
            Program.DataStoreS.reciepts.Remove(receipt);
            Program.DataStoreS.reciepts.Add(obj);
            return obj.id;
        }
        else
            return 0;
    }

    public List<Reciept> GetAll()
    {
        return Program.DataStoreS.reciepts;
    }
}