using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{

	public static void SaveGameData(GameState gameState)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.fisi";
		FileStream stream = new FileStream(path, FileMode.Create);

		PlayerData data = new PlayerData(gameState);

		formatter.Serialize(stream, data);
		stream.Close();

    }

    public static PlayerData LoadGameData()
	{
        string path = Application.persistentDataPath + "/player.fisi";


        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //convert the data from a binary format to something usable
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            //return the data that comes out of the deserialized file
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}