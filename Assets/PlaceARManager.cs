using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceARManager : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("ComicBook");
    }
}
