using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class GraphicsData : MonoBehaviour
{
    private int graphicsIndex;
    public MenuScript qualityM;
    public int graphicsSettings
    {
        get=> graphicsIndex;
        set=>graphicsIndex=value;
    }

    void save()
    {
        JSONObject qualityIndex = new JSONObject();
        qualityIndex.Add("qualityIndex:",graphicsSettings);
        //SAVE JSON FILE
        string path = Application.persistentDataPath + "/qualitySettings.json";
        File.WriteAllText(path,qualityIndex.ToString());

    }
    void load()
    {
        string path = Application.persistentDataPath + "/qualitySettings.json";
        string jsonString = File.ReadAllText(path);
        JSONObject qualityIndex = (JSONObject)JSON.Parse(jsonString);
        //SET VALUES

    }     
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
