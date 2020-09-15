using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTriggerBehaviour : MonoBehaviour
{

    public float explosiveForce;
    public float explosionRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        RagdollBehaviour ragdoll = other.GetComponentInParent<RagdollBehaviour>();
        if(ragdoll)
        {
            ragdoll.ragdollOn = true;
        }
        Collider[] collisions = Physics.OverlapSphere(transform.position, 20);
        foreach(Collider collider in collisions)
        {
            collider.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, transform.position, explosionRadius);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
