using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovementBehaviour : MonoBehaviour
{
    private CharacterController _controller = null;
    private Animator _animator = null;

    public float speed;
    public float pushPower = 2.0f;
    public float jumpForce = 10.0f;
    public float gravity = 10.0f;
    private Vector3 _verticalVelocity = Vector3.zero;
    [SerializeField]
    private bool _isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if(body == null || body.isKinematic)
        {
            return;
        }
        if(hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }
    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //Vector3 velocity = transform.forward * vertical * speed;
        Vector3 velocity = new Vector3(-vertical, 0, horizontal);
        _isGrounded = _controller.SimpleMove(velocity *speed);
        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _verticalVelocity.y = jumpForce;
            _animator.SetBool("Jump", true);
        }
        else
        {
            _animator.SetBool("Jump", false);
        }
        
        _verticalVelocity.y -= gravity * Time.deltaTime;
        _controller.Move(_verticalVelocity * Time.deltaTime);
        if (velocity.magnitude > 0)
            transform.forward = velocity.normalized;
        _animator.SetFloat("Speed", velocity.magnitude);
    }
}
