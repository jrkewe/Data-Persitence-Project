using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager Instance;

    public string NameID;
    public int BestScore;

    private void Awake()
    {
        if (Instance !=null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData 
    {
        public int Score;
    }

    public void SaveScore() 
    {
        SaveData data = new SaveData();
        data.Score = BestScore;
    
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.jason",json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.jason";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScore = data.Score;
        }
    }
}
