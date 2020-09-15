using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RagdollBehaviour : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    private CharacterController _controller;
    public bool ragdollOn
    {
        get
        {
            return !_animator.enabled;
        }
        set
        {
            _animator.enabled = !value;
            _controller.enabled = !value;
            foreach(Rigidbody r in rigidbodies)
            {
                r.isKinematic = !value;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        foreach(Rigidbody r in rigidbodies)
        {
            r.isKinematic = true;
        }
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
