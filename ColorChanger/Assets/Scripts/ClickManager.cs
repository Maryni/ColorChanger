using System.Collections;
using System.Collections.Generic;
using System.IO;
using UniRx;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    [SerializeField] private MessageBroker messageBroker;
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
            print(texted[i]);
        }
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100, layerMask))
            {
                if (hit.collider.gameObject.layer==10)
                {
                    gameObjectTemp = hit.collider.gameObject;
                    data = gameObjectTemp.GetComponent<HoldData>();
                    data.AddClick();
                    if (data.CheckMinMoreThenMaxClicks()) data.SetDefaultColor();
                }
                else if(hit.collider.gameObject.layer==9)
                {
                    hit.point = new Vector3(hit.point.x, 2f, hit.point.z);
                    GetRandom();
                    Instantiate(listTransf[i], hit.point, Quaternion.identity);
                }
            }
        }
    }
    private void GetRandom()
    {
        i = Random.Range(0, 3);
    }
}
