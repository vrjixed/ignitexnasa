using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probe : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.collider.gameObject);
        Instantiate(particle, collision.collider.transform.position, Quaternion.identity);
    }
}
