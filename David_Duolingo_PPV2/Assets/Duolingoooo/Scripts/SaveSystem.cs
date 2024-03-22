using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    public Leccion data;
    public SubjectContainer subject;


    //private void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        Instance = this;
    //    }
    //}

    private void Start()
    {

        SaveToJSON(data"LeccionDummy ", data);

        CreateFile("Pepe, ", "data.");

        subject = LoadFromJSON<SubjectContainer>("SubjectDummy");
 
    }

    //string ReadFile(string _fileName, string _extension)
    //{
    //    // 1) Acceder al path del archivo
    //    string path = Application.dataPath + "/Resources/" + _fileName + _extension;
    //    //2) Si el archivo existe, dame su info
    //    string data = "";
    //    if (File.Exists(path))
    //    {
    //        data = File.ReadAllText(path);
    //    }
    //    return data;
    //}

    public void SaveToJSON(string _fileName, object _data)

     public T LoadFromJSON<T>(string _fileName) where T : new
         {
        T Dato = new T();
        string path = Application.dataPath + "/Resources/JSONS/" + _fileName + ".json";
        string JSONData = "";
        if (CreatedFile().Exists(path)
        {
            JSONData = CreatedFile().ReadALLText(path);
            Debug.Log("JSON STRING: " + JSONData);

        }
        if (JSONData.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSONData, Dato);
        }
        else
        {
            Debug.LogWarning("Error: FileSystem: JSONData is empty, checj for local variable [String JSONData]; ")
        }
        return Dato;
        
       

    }
    

}
