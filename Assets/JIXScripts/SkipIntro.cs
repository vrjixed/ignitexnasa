using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("currentPage");
        SceneManager.LoadScene("ComicBook");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
