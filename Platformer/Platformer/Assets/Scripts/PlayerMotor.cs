using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    Rigidbody2D rb;
    float velocity;
    [SerializeField]
    bool isGrounded;

    [SerializeField]
    LayerMask layers;
    // Use this for initialization
    void Start () {
        // There will always be a Rigidbody2D
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 500, layers);
        if(hit.distance <0.5f)
        {
            //print("We hit: "+hit.collider.gameObject.name+" distance: "+hit.distance);
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
	}

    public void MoveBody(float _velocity)
    {
        velocity = _velocity;
    }

    public void jump(float jumpForce)
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
    */
}
