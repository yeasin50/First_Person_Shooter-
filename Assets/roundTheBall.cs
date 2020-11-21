using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundTheBall : MonoBehaviour
{
     float smooth= .5f;
    public float speed = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         // float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        // float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        float tiltAroundX = smooth;
        float tiltAroundZ = smooth*.75f;
        smooth += speed;
        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        
    }
}
