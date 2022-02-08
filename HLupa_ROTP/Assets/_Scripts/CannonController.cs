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
        //only fire if 
        if (hasFired == false) {
            Vector3 mouseOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseOnScreen);

            Vector3 directionIn3D = mousePosition - transform.position;

            float dotProduct = Vector2.Dot(Vector2.right, new Vector2(directionIn3D.x, directionIn3D.y).normalized);
            float angleAroundZAxis = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            if (mousePosition.y - transform.position.y > 0 && angleAroundZAxis < 80 && angleAroundZAxis > 10)
            {
                transform.rotation = Quaternion.Euler(0, 0, angleAroundZAxis);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                piggyRB.transform.parent = null;
                piggyRB.gravityScale = 1;
                piggyRB.AddForce(directionIn3D * forceMultiplier);
                hasFired = true;
            }
        }
        
    }
}
