using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    public float forceOnFire = 300;

    private bool _canFire = true;

    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && _canFire)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(transform.forward * forceOnFire);
            _canFire = false;
        }
    }
}
