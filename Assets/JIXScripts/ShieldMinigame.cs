using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMinigame : MonoBehaviour
{
    public GameObject particlePrefab;

    public GameObject shield;

    public Transform particlesTransform;

    // Start is called before the first frame update
    void OnEnable()
    {
        CleanParticles();
        CancelInvoke("CreateParticle");

        CreateParticle();
    }


    void CreateParticle()
    {


        Instantiate(particlePrefab, new Vector2(Random.Range(7f, 8f), Random.Range(-3f, 3f)), Quaternion.identity, particlesTransform);
        Instantiate(particlePrefab, new Vector2(Random.Range(7f, 8f), Random.Range(-3f, 3f)), Quaternion.identity, particlesTransform);
        Instantiate(particlePrefab, new Vector2(Random.Range(7f, 8f), Random.Range(-3f, 3f)), Quaternion.identity, particlesTransform);
        Instantiate(particlePrefab, new Vector2(Random.Range(7f, 8f), Random.Range(-3f, 3f)), Quaternion.identity, particlesTransform);
        Instantiate(particlePrefab, new Vector2(Random.Range(7f, 8f), Random.Range(-3f, 3f)), Quaternion.identity, particlesTransform);

        Invoke("CreateParticle", Random.Range(0.01f, 0.1f));
    }

    public void ShowShield(bool b)
    {
        shield.SetActive(b);
    }

    public void CleanParticles()
    {
        foreach(Transform child in particlesTransform)
        {
            Destroy(child.gameObject);
        }
    }
}
