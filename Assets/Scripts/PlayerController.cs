using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public int speed = 0;
    public Vector3 velocity;
    float moveSpeed = 10;

    Animator anim;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    private void Start()
    {
        anim = GetComponent<Animator>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(-2) * timeToJumpApex;
        
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        //var y = velocity.y;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, velocity.y, z);


        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        

        float targetVelocityX = x * moveSpeed;
        //test
        float targetVelocityZ = z * moveSpeed;

        anim.SetFloat("Velocity", Mathf.Abs(targetVelocityZ));



        if (Input.GetButtonDown("Jump"))
        {
            
                velocity.y = maxJumpVelocity;             



        }
        if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;

            }
        }
    }
}
