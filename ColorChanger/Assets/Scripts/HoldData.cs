using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class HoldData : MonoBehaviour
{
    [SerializeField] private ClickColorData data;
    [SerializeField] private Renderer renderer;
    [SerializeField] private int minClicks;
    [SerializeField] private int maxClicks;
    [SerializeField] private Color colorData;
    private Color color;

    private void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        minClicks = data.MinClicksCount();
        maxClicks = data.MaxClicksCount();

        Observable.Timer(System.TimeSpan.FromSeconds(5))
            .Repeat()
            .Subscribe(_ =>
            {
                if (minClicks < maxClicks)
                {
                    RandomColor();
                    renderer.material.color = color;
                } 
            }).AddTo(this);
    }
    private void RandomColor()
    {
        color.r = Random.Range(0f, 1f);
        color.g = Random.Range(0f, 1f);
        color.b = Random.Range(0f, 1f);
        color.a = 255;
    }
    public void AddClick() { minClicks++; }
    public void SetDefaultColor() { renderer.material.color = data.Color(); }
    public bool CheckMinMoreThenMaxClicks() { if (minClicks > maxClicks) return true; else { return false; } }
    public ClickColorData GetData() { return data; }
}
