using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    public float forceOnFire = 300;

    private bool _fire = false;
    private bool _canFire = true;

    private Rigidbody rigidbody = null;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(transform.forward * forceOnFire,ForceMode.Impulse);
            _canFire = false;
        }
    }
}
