using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Rigidbody2D piggyRB;
    public float forceMultiplier = 100;
    public bool hasFired = false;
    // Start is called before the first frame update
    void Start()
    {
        hasFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        //only fire if the cannon has not already been fired, preventing infinite piggy bounces
        if (hasFired == false) {
            
            //translating 3D mouse position to 2D targeting system
            Vector3 mouseOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseOnScreen);

            Vector3 directionIn3D = mousePosition - transform.position;

            float dotProduct = Vector2.Dot(Vector2.right, new Vector2(directionIn3D.x, directionIn3D.y).normalized);
            float angleAroundZAxis = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            //tracking the mouse y position and the angle of the cannon to give it a limited rotation
            if (mousePosition.y - transform.position.y > 0 && angleAroundZAxis < 80 && angleAroundZAxis > 10)
            {
                transform.rotation = Quaternion.Euler(0, 0, angleAroundZAxis);
            }

            //firing the piggy when the player presses left mouse
            if (Input.GetButtonDown("Fire1"))
            {
                //launching the piggy by adding force to its rigidbody
                piggyRB.transform.parent = null;
                piggyRB.gravityScale = 1;
                piggyRB.AddForce(directionIn3D * forceMultiplier);
                hasFired = true;
            }
        }
        
    }
}
