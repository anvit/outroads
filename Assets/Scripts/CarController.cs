using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public bool hasStarted = false;
    private Vector3 change;
    private bool isGrounded = true;
    public float jumpSpeed = 150f;
    public float rotationSpeed = 50f;
    public float maxRotation = 0.3f;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            hasStarted = true;
        }

        // acc
        if (hasStarted) rigidBody.AddRelativeForce(0, 0, 10);

        change = Vector3.zero;
        rigidBody.AddRelativeForce(0, 0, 20 * Input.GetAxisRaw("Vertical"));
        rigidBody.MovePosition(transform.position + change * Time.deltaTime);

        // jump
        if (Input.GetButton("Jump") && isGrounded)
        {
            rigidBody.AddRelativeForce(0, jumpSpeed, 0);
        }

        // rotation
        if (Input.GetAxisRaw("Horizontal") > 0 && rigidBody.rotation.y < maxRotation)
        {
            transform.Rotate(Vector3.down * -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && rigidBody.rotation.y > -maxRotation)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}