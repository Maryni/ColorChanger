using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Info", menuName = "Data Object")]
public class ClickColorData : ScriptableObject
{
    [SerializeField] private string objectType;
    [SerializeField] private int minClicksCount;
    [SerializeField] private int maxClicksCount;
    [SerializeField] private Color color;

    public string ObjectType() { return objectType; }
    public int MinClicksCount() { return minClicksCount; }
    public int MaxClicksCount() { return maxClicksCount; }
    public Color Color() { return color; }
}
