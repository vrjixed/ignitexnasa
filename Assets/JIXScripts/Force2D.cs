using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force2D : MonoBehaviour
{
    public Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = force;
    }

}
