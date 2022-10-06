using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ComicManager : MonoBehaviour
{
    public GameObject comicCanvas;
    public GameObject comicPanel;
    public GameObject welcomePanel;

    public Slider slider;
    public ScrollRect scrollRect;

    public Transform[] pages;

    public Dot[] dots;

    public Balloon[] ballons;

    public float sliderOffset;

    public Transform center;

    public int closestId = 0;

    Vector3 initialMousePos;
    float initialTime;
    int initialId;

    public Viewer3D viewer3D;

    bool canInteract = false;

    public GameObject shieldGame;
    public GameObject shieldGameUI;

    public GameObject venusGame;
    public GameObject venusGameUI;

    void Start()
    {
        welcomePanel.SetActive(true);
        comicPanel.SetActive(false);
        if (PlayerPrefs.HasKey("currentPage"))
        {
            closestId = PlayerPrefs.GetInt("currentPage");
            initialId = PlayerPrefs.GetInt("currentPage");

            scrollRect.content.anchoredPosition = new Vector2(PlayerPrefs.GetInt("currentPage") * -800f, 0f);
            PlayerPrefs.DeleteKey("currentPage");

            welcomePanel.SetActive(false);
            comicPanel.SetActive(true);

            Show3DViewer(true);
            
        }

        canInteract = true;
    }

    public void JumpToPage(int id)
    {
        scrollRect.content.DOAnchorPosX((id) * -800f, 0.2f);
    }

    public void ViewInAR()
    {
        PlayerPrefs.SetInt("currentPage", closestId);

        SceneManager.LoadScene("PlaceAR");
    }

    public void Show3DViewer(bool b)
    {
        comicCanvas.SetActive(!b);
        viewer3D.gameObject.SetActive(b);
    }

    void Update()
    {
        if (!canInteract) return;

        if (!comicCanvas.activeSelf || !comicPanel.activeSelf) return;

        slider.value = scrollRect.horizontalNormalizedPosition;

        int currentDot = Mathf.CeilToInt(sliderOffset + slider.value * (dots.Length - 1));

        for (int i = 0; i < dots.Length; i++)
        {
            if(i < currentDot)
            {
                dots[i].Fill(true);
            }
            else
            {
                dots[i].Fill(false);
            }
            
        }

        if(slider.value == 1f) dots[dots.Length - 1].Fill(true);
        else dots[dots.Length - 1].Fill(false);

        float closestDist = 1000f;
        

        for (int i = 0; i < pages.Length; i++)
        {
            float dist = Vector3.Distance(center.transform.position, pages[i].transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestId = i;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            initialMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            initialTime = Time.time;
            initialId = closestId;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(Time.time - initialTime < 0.3f)
            {
                var diff = initialMousePos - Camera.main.ScreenToViewportPoint(Input.mousePosition);
                if (diff.x < 0f)
                {
                    if(initialId - 1 >= 0)
                    {
                        scrollRect.content.DOAnchorPosX((initialId - 1) * -800f, 0.2f);
                    }
                    
                }
                else if (diff.x > 0f)
                {
                    scrollRect.content.DOAnchorPosX((initialId + 1) * -800f, 0.2f);
                }
            }
            else
            {
                scrollRect.content.DOAnchorPosX(closestId * -800f, 0.2f);
            }
            
        }
    }

    public void ShowShieldGame(bool b)
    {
        comicPanel.SetActive(!b);
        shieldGameUI.SetActive(b);
        shieldGame.SetActive(b);
    }

    public void ShowVenusGame(bool b)
    {
        comicPanel.SetActive(!b);
        venusGameUI.SetActive(b);
        venusGame.SetActive(b);
    }
}
