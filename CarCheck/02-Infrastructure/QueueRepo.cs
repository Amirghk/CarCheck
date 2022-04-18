using CarCheck;

public class QueueRepo : IGenericRepo<Queue>
{
    public int Add(Queue obj)
    {
        if (Program.DataStoreS.queues is null)
        {
            Program.DataStoreS.queues = new List<Queue> { obj };
        }
        else
            Program.DataStoreS.queues.Add(obj);
        return obj.id;
    }

    public int Delete(Queue obj)
    {
        Program.DataStoreS.queues.Remove(obj);
        return obj.id;
    }

    public Queue? Get(int id)
    {
        Queue? queue = Program.DataStoreS.queues.FirstOrDefault(queue => queue.id == id);
        if (queue == null)
        {
            return null;
        }
        else return queue;

    }

    public int Update(Queue obj)
    {
        Queue? queue = Program.DataStoreS.queues.FirstOrDefault(queue => queue.id == obj.id);
        if (queue != null)
        {
            Program.DataStoreS.queues.Remove(queue);
            Program.DataStoreS.queues.Add(obj);
            return obj.id;
        }
        else
            return 0;
    }

    public List<Queue> GetAll()
    {
        return Program.DataStoreS.queues;
    }
}