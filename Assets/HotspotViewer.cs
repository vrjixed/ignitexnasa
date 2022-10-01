using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HotspotViewer : MonoBehaviour
{
    public static HotspotViewer instance;

    public TextMeshProUGUI txt;
    public GameObject box;

    void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        box.SetActive(false);
    }

    public void ShowText(string str)
    {
        box.SetActive(true);
        txt.text = str;
    }
}
