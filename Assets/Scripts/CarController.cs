using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public bool hasStarted = false;
    private Vector3 change;
    private bool isGrounded = true;
    public float turnSpeed = 2.0f;
    public float jumpSpeed = 150f;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            hasStarted = true;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        if (hasStarted) rigidBody.AddForce(0, 0, 10);
        rigidBody.AddForce(0, 0, 20 * Input.GetAxisRaw("Vertical"));
        rigidBody.MovePosition(transform.position + change * turnSpeed * Time.deltaTime);
        if (Input.GetButton("Jump") && isGrounded)
        {
            rigidBody.AddForce(0, jumpSpeed, 0);
        }
        rigidBody.freezeRotation = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter");
        if (collision.transform.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            Debug.Log("Exiting");
            isGrounded = false;
        }
    }
}