using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided= false;
    // destroy projectile 
    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag!="Player" && coll.gameObject.tag !="Bullet" && !collided){
            collided = true;
            // Destroy(gameObject);
            Debug.Log(gameObject.tag);
        }
    }
}
