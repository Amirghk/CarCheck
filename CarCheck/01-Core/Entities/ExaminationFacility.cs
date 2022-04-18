using CarCheck;

public class ExaminationFacility
{
    public readonly Dictionary<DateTime, List<Queue>> SignUps = new Dictionary<DateTime, List<Queue>>();
    public readonly string name;
    public readonly int id;

    public ExaminationFacility(string name)
    {
        this.name = name;
        if (Program.DataStoreS.facilities.Count == 0)
        {
            id = 0;
        }
        else
        {
            id = Program.DataStoreS.facilities.Max(c => c.id) + 1;
        }
    }

    // adds a Queue item to the SignUps dict
    public int SignUpQuery(Queue q)
    {
        if (!SignUps.ContainsKey(q.date))
        {
            SignUps.Add(q.date, new List<Queue>(20));
            SignUps[q.date].Add(q);
            return 1;
            
        }
        else
        {
            if (SignUps[q.date].Count >= 20)
            {
                Console.WriteLine($"Capacity is full on {q.date}.");
                return 0;
            }
            else
            {
                SignUps[q.date].Add(q);
                return 1;
            }   
        }
    }
}