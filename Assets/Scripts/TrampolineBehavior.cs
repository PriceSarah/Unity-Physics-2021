using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBehavior : MonoBehaviour
{

    private Rigidbody rigidbody = null;

    void OnCollisionEnter(Collision collision)
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(collision.relativeVelocity.x, collision.relativeVelocity.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
