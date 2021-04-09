using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Reader : MonoBehaviour
{
    [SerializeField] private string path;
    [SerializeField] private string jsonString;
    [SerializeField] private Text text;
    [SerializeField] private string[] texted;
    [ContextMenu("Read")]

    private void Start()
    {
        jsonString = File.ReadAllText(path);
        texted = jsonString.Split(new string[] { "\r\n", "\n", " ", "\t" }, System.StringSplitOptions.None);
        text.text = jsonString;

        for (int i = 0; i < texted.Length; i++)
        {
            print(texted[i]);
        }
    }
}

