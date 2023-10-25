using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public static class Save

{
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/saves/";
    public static readonly string File_EXT = ".json";

    public static void saveSystem(string fileName, string dataToSave)
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }

        File.WriteAllText(SAVE_FOLDER + fileName + File_EXT, dataToSave);
    }


    public static string Load(string fileName)
    {
        string fileLoc = SAVE_FOLDER + fileName + File_EXT;
        if (File.Exists(fileLoc))
        {
            string loadedData = File.ReadAllText(fileLoc);

            return loadedData;
        }
        else
        {
            return null;
        }

       
    }



    }

