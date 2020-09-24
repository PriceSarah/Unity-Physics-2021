using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTargetBehavior : MonoBehaviour
{
    //public Material UnhitMaterial = null;
    public Material HitMaterial = null;

    private Rigidbody _rigidbody = null;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Target()
    {
        if (_rigidbody.IsSleeping() && HitMaterial != null)
        {
            GetComponent<MeshRenderer>().material = HitMaterial;
        }
    }

}
