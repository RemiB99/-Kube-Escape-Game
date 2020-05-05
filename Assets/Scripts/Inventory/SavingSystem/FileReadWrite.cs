using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileReadWrite
{
    public static void writeToBinaryFile<T>(string file, T objectToWrite)
    {
        using(Stream stream = File.Open(file, FileMode.Create))
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, objectToWrite);
        }
    }

    public static T readFromBinaryFile<T>(string file)
    {
        using (Stream stream = File.Open(file, FileMode.Open))
        {
            var binaryFormatter = new BinaryFormatter();
            return (T)binaryFormatter.Deserialize(stream);
        }
    }
}
