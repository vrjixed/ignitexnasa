using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot : MonoBehaviour
{
    public string hotspotName;

    public Renderer rend1;
    public Renderer rend2;

    void OnEnable()
    {
        Highlight(false);
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void OnMouseDown()
    {
        var hotspots = FindObjectsOfType<Hotspot>();
        foreach(Hotspot hotspot in hotspots)
        {
            hotspot.Highlight(false);
        }

        HotspotViewer.instance.ShowText(hotspotName);
        Highlight(true);
    }

    public void Highlight(bool b)
    {
        if (b)
        {
            rend1.material.color = new Color(1f, 0.5f, 0f);
            rend2.material.color = new Color(1f, 0.5f, 0f);
        }
        else
        {
            rend1.material.color = Color.white;
            rend2.material.color = Color.white;
        }
    }
}
