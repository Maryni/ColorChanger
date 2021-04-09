using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private List<string> listNames;
    [SerializeField] private List<Transform> listTransf;  
    private RaycastHit hit;
    private int i;
    [SerializeField] private GameObject gameObjectTemp;
    [SerializeField] private HoldData data;
    [SerializeField] private string path;
    [SerializeField] private string jsonString;
    [SerializeField] private string[] texted;
    private void Start()
    {
        jsonString = File.ReadAllText(path);
        texted = jsonString.Split(new string[] { "\r\n", "\n", " ", "\t" }, System.StringSplitOptions.None);

        for (int i = 0; i < texted.Length; i++)
        {
            listNames[i] = texted[i];
        }
        GetTransformForName();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100, layerMask))
            {
                if (hit.collider.gameObject.layer==10) // if click on objects
                {
                    gameObjectTemp = hit.collider.gameObject;
                    data = gameObjectTemp.GetComponent<HoldData>();
                    data.AddClick();
                    if (data.CheckMinMoreThenMaxClicks()) 
                        data.SetDefaultColor();
                }
                else 
                //if(hit.collider.gameObject.layer==9) // if click on terrain
                {
                    hit.point = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    GetRandom();
                    Instantiate(listTransf[i], hit.point, Quaternion.identity);
                }
            }
        }
    }

    private void GetTransformForName()
    {
        for(int i=0;i<listNames.Count;i++)
        {
            Transform a = listTransf[i];
            ClickColorData b = listTransf[i].GetComponent<HoldData>().GetData();
            if (listNames[i] == b.ObjectType()) 
                a.name = b.ObjectType(); //get name from json GO with this ObjectType
        }
        
    }
    private void GetRandom()
    {
        i = Random.Range(0, 3);
    }
}
