using CarCheck;

public class Car
{
    public readonly int id;
    public readonly string brand;
    public readonly int year;

    public Car(string brand, int year)
    {
        this.brand = brand;
        this.year = year;
        // bug here ( it adds a new id to a list with 1 car in it when its trying to override it)
        if (Program.DataStoreS.cars.Count == 0)
        {
            id = 0;
        }
        else
        {
            id = Program.DataStoreS.cars.Max(c => c.id) + 1;
        }
            
    }


}