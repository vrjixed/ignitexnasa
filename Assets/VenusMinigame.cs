using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenusMinigame : MonoBehaviour
{

    public Animator animator;

    public Image[] venus;

    public Sprite[] venusSprites;

    public GameObject[] venusObjects;


    // Start is called before the first frame update
    void OnEnable()
    {
        for(int i=0;i< venus.Length; i++)
        {
            VenusOn(i, false);
        }
        

    }

    // Update is called once per frame
    public void Accelerate(bool b)
    {
        if (b)
        {
            animator.speed = 10f;
        }
        else
        {
            animator.speed = 1f;
        }
    }

    void VenusOn(int i, bool b)
    {
        venusObjects[i].SetActive(b);
        //if (b)
        //{
            
        //    venus[i].sprite = venusSprites[1];
        //}
        //else
        //{
        //    venus[i].sprite = venusSprites[0];
        //}
    }

    private void Update()
    {
        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] myAnimatorClip = animator.GetCurrentAnimatorClipInfo(0);
        float myTime = myAnimatorClip[0].clip.length * animationState.normalizedTime;
        

        Debug.LogError(myTime);
        if (myTime > 27.39f)
        {
            VenusOn(0,true);
        }

        if (myTime > 57.39f)
        {
            VenusOn(1, true);
        }

        if (myTime > 87.39f)
        {
            VenusOn(2, true);
        }

        if (myTime > 117.39f)
        {
            VenusOn(3, true);
        }

        if (myTime > 147.39f)
        {
            VenusOn(4, true);
        }

        if (myTime > 177.39f)
        {
            VenusOn(5, true);
        }

        if (myTime > 207.39f)
        {
            VenusOn(6, true);
        }
    }
}
