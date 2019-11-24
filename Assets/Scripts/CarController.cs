using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 3.0f;
    public float currentSpeed = 0.0f;
    private Vector3 change;
    private bool isJump = false;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        currentSpeed = currentSpeed + Mathf.Max((Input.GetAxisRaw("Vertical")), maxSpeed);
        change.z = currentSpeed;
        isJump = Input.GetButton("Jump");
        rigidBody.MovePosition(transform.position + change * Time.deltaTime);
    }
}