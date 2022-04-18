public interface IReadWrite
{
    public DataStore Read(string path);
    public void Write(string path, DataStore data);
}