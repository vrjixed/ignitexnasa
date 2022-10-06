using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-50f, 0f);
        transform.localScale = Random.Range(0.1375296f, 0.3375296f) * Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
