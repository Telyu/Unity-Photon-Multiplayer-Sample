using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private bool isJumping;
    public float speed;
    public float jumpForce;
    private float x;
    private Rigidbody2D rgbdy;

    void Start()
    {
        rgbdy = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x= Input.GetAxis("Horizontal");
        transform.position += (Vector3) new Vector2(x*speed*Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rgbdy.AddForce(transform.up*jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Floor")){
            isJumping = false;
        }
    }
}
