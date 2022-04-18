using Newtonsoft.Json;

public class ReadWriteFile : IReadWrite
{
    public DataStore Read(string path)
    {
        var file = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<DataStore>(file);
    }

    public void Write(string path, DataStore data)
    {
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, json);
    }
}