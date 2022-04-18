using CarCheck;
public class Queue
{
    public readonly int carId;
    public readonly DateTime date;
    public int id { get; }

    public Queue(int carId, DateTime date)
    {
        this.carId = carId;
        this.date = date;
        if (Program.DataStoreS.queues.Count == 0)
        {
            id = 0;
        }
        else
        {
            id = Program.DataStoreS.queues.Max(c => c.id) + 1;
        }
    }


}
