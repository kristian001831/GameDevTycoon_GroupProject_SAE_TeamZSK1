using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//from lucas class
public class SaveSystem
{
    const string SAVE_BASE_PATH = "APPDATALOCATION";

    public static bool Save(ISavable savable)
    {
        var save = savable.GenerateSaveData();
        
        BinaryFormatter bf = new BinaryFormatter();
        
        try
        { 
            Stream stream = new FileStream(SAVE_BASE_PATH + savable.GetDefaultFileName(), FileMode.OpenOrCreate); 
            bf.Serialize(stream, save); 
            return true;

        }catch(System.Security.SecurityException e) 
        { 
            //ErrorDisplay.ShowMessage("Failed Saving, would you like to try again?");
            return false;
        }
    }
    
    public static void Load(ISavable savable) 
    {
        BinaryFormatter bf = new BinaryFormatter();

        Stream stream = new FileStream(SAVE_BASE_PATH + savable.GetDefaultFileName(), FileMode.Open);
        SaveDataBase save = (SaveDataBase) bf.Deserialize(stream);

        savable.LoadSaveData(save);
    }
}

public interface ISavable
{
    string GetDefaultFileName();
    SaveDataBase GenerateSaveData();
    bool LoadSaveData(SaveDataBase data);
}

public class AestheticSystem : ISavable
{
    public int CurrentHatID { get; private set; }

    public SaveDataBase GenerateSaveData()
    {
        var save = new CharacterAestheticsSaveData(); 
        save.HatId = CurrentHatID;
        return save;
    }

    public string GetDefaultFileName()
    {
        return "CharLooks";
    }

    public bool LoadSaveData(SaveDataBase data)
    {
        CurrentHatID = ((CharacterAestheticsSaveData)data).HatId; 
        return true;
    }
}

public class Game : ISavable
{
    public SaveDataBase GenerateSaveData() 
    {
        throw new NotImplementedException();
    }

    public string GetDefaultFileName()
    {
        throw new NotImplementedException();
    }

    public bool LoadSaveData(SaveDataBase data)
    { 
        throw new NotImplementedException();
    }
}


[System.Serializable]
public class SaveDataBase
{ 
    public DateTime TimeStamp;

    public SaveDataBase() 
    {
        TimeStamp = DateTime.Now;
	}
}

[System.Serializable]
public class CharacterAestheticsSaveData : SaveDataBase
{ 
    public int HatId;
}

[System.Serializable]
public class ExampleSaveData :SaveDataBase
{ 
    public float Time;
    public float Money;
    public float[] Trends;
    public string[] Products;
}
