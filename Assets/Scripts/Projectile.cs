using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided= false;
    // destroy projectile 
    void OnCollisionEnter(Collision coll){

        Debug.Log(coll.gameObject.tag);
        if(coll.gameObject.tag!="Player" && coll.gameObject.tag !="Bullet" && !collided){
            collided = true;
            Destroy(gameObject);
          
        }
        // if(coll.gameObject.tag=="Enemy" && !collided){
        //     collided = true;
        //     Destroy(gameObject);
        // }
    }
}
