using CarCheck;

public class CustomerRepo : IGenericRepo<Customer>
{
    public int Add(Customer obj)
    {
        if (Program.DataStoreS.customers is null)
        {
            Program.DataStoreS.customers = new List<Customer> { obj };
        }
        else
            Program.DataStoreS.customers.Add(obj);
        return obj.id;
    }

    public int Delete(Customer obj)
    {
        Program.DataStoreS.customers.Remove(obj);
        return obj.id;
    }

    public Customer? Get(int id)
    {
        Customer? customer = Program.DataStoreS.customers.FirstOrDefault(customer => customer.id == id);
        if (customer == null)
        {
            return null;
        }
        else return customer;

    }

    public int Update(Customer obj)
    {
        Customer? customer = Program.DataStoreS.customers.FirstOrDefault(customer => customer.id == obj.id);
        if (customer != null)
        {
            Program.DataStoreS.customers.Remove(customer);
            Program.DataStoreS.customers.Add(obj);
            return obj.id;
        }
        else
            return 0;
    }

    public List<Customer> GetAll()
    {
        return Program.DataStoreS.customers;
    }
}