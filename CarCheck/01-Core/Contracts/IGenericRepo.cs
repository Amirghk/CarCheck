public interface IGenericRepo<T>
{
    public List<T> GetAll();
    public int Add(T obj);
    public int Update(T obj);
    public int Delete(T obj);
    public T Get(int id);

}