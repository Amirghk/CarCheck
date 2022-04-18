using CarCheck;
using System.Globalization;
public class Reciept
{
    public int id { get; }
    public int FacilityID { get; }
    public int CarID { get; }
    public int CustomerID { get; }
    public int ClerkID { get; }
    public DateTime Date { get; }

    public Reciept(int facilityId, int carId, int customerId, int clerkId, DateTime date)
    {
        FacilityID = facilityId;
        CarID = carId;
        CustomerID = customerId;
        ClerkID = clerkId;
        Date = date;
        if (Program.DataStoreS.reciepts.Count == 0)
        {
            id = 0;
        }
        else
        {
            id = Program.DataStoreS.reciepts.Max(c => c.id) + 1;
        }
    }

    public override string ToString()
    {
        return $"Car : {Program.DataStoreS.cars.FirstOrDefault(c => c.id == CarID).brand}\n" +
            $"Facility : {Program.DataStoreS.facilities.FirstOrDefault(f => f.id == FacilityID).name}\n" +
            $"Customer : {Program.DataStoreS.customers.FirstOrDefault(c => c.id == CustomerID).name}\n" +
            $"Clerk : {Program.DataStoreS.clerks.FirstOrDefault(c => c.id == ClerkID).name}\n" +
            $"Date : {Date.ToString("d", new CultureInfo("fa-IR", false))}\n";
    }
}