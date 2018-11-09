using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour {
    
    float maxVelocity;
    public float velocityAdd;
    public float jumpForceAdd;
    public float velocity;
    public float _XAxis;
    public float _ZAxis;
    private bool jump;
    // Use this for initialization
    public Rigidbody sphere;
    
    //private GameObject sphere;
	void Start () {
        sphere = GetComponent<Rigidbody>();
        velocityAdd = 1.0f;
        maxVelocity = 5.0f;
        jumpForceAdd = 10.0f;

    }
    private void setMaxSpeed()
    {
        Vector3 XYSpeed = Vector3.ProjectOnPlane(sphere.velocity, Vector3.up);
        if(XYSpeed.magnitude>maxVelocity)
        {
            XYSpeed = XYSpeed.normalized * maxVelocity;
            sphere.velocity = XYSpeed + new Vector3(0, sphere.velocity.y, 0);
        }
    }
    public void move(float _XMove,float _ZMove)
    {
        Vector3 moveDirection = new Vector3(_XMove, 0, _ZMove);
        moveDirection *= velocityAdd;
        sphere.AddForce(moveDirection, ForceMode.Force);
        setMaxSpeed();
    }
    public void Jump()
    {
        Vector3 moveDirection = new Vector3(0,1.0f,0);
        moveDirection *= jumpForceAdd;
        sphere.AddForce(moveDirection, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update () {
        
        _XAxis = Input.GetAxis("Horizontal");
        _ZAxis = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");
        move(_XAxis, _ZAxis);
        
        if(jump)
        {
            Jump();
        }
    }
}
