using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private void Awake()
    {   
        //Load();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save()
    {
        try
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/Slats.dat");

            CharacterStats charStats = new CharacterStats();
            charStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();

            binaryFormatter.Serialize(file, charStats);
            file.Close();
        }
        catch 
        {
            throw new System.Exception("error saving...");
        }
    }

    public void Load()
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + "/Slats.dat"))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/Slats.dat", FileMode.Open);
                CharacterStats charStats = (CharacterStats)binaryFormatter.Deserialize(file);
                file.Close();

                var _charStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
               
                //to be filled with loaded variables
            }
        }
        catch 
        {
            throw new System.Exception("error loading...");
        }
    }
}
