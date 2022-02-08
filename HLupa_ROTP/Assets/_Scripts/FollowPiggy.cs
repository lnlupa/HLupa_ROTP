using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPiggy : MonoBehaviour
{
    public Transform piggy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < 9.5f) 
        {
            Vector3 newPosCamera = new Vector3(piggy.position.x, transform.position.y, transform.position.z);
            transform.position = newPosCamera; //Vector3.Lerp(transform.position, newPosCamera, Time.deltaTime*3);
        }
        
    }
}
