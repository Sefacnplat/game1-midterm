using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject MainLevel;
    public GameObject secondlevel;
        private bool onGround;
    
        private Rigidbody2D body;
        
        private float boxSpeed=10;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput* boxSpeed, body.velocity.y);

        if(horizontalInput > 0.01f) {
            transform.localScale = Vector3.one;}

        else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }    

        if(Input.GetKey(KeyCode.Space) && onGround) {
            Jump();
        }
    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, boxSpeed);
        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "MainFloor")
            onGround = true;
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("secondlevel");
        }  
    }

}