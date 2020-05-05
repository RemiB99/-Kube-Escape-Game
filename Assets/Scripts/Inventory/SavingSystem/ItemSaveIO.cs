using UnityEngine;

public static class ItemSaveIO
{
    private static readonly string baseSavePath;

    static ItemSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }

    public static void saveItems(ItemContainerSaveData items, string file)
    {
        FileReadWrite.writeToBinaryFile(baseSavePath + "/" + file + ".dat", items);
    }

    public static ItemContainerSaveData LoadItems(string file)
    {
        string filePath = baseSavePath + "/" + file + ".dat";

        if (System.IO.File.Exists(filePath))
        {
            return FileReadWrite.readFromBinaryFile<ItemContainerSaveData>(filePath);
        }
        return null;
    }
}