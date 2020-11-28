using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArea : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    // public Camera fpsCam;
    public ParticleSystem muzzleFlesh;
    public GameObject impactEffects;

    private float nextTimeToFire = 0f;
     private bool enemyInside = false;
    
    void Update()
    {
          if(enemyInside && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        // if(enemyInside)Shoot();
    }
    
    void OnUpdate(){
        if(enemyInside)Shoot();
    }

   void OnTriggerEnter(Collider other) {
        
        if(other.tag== "Player") enemyInside = true;
        print(other.name);
        
    }

   private void OnTriggerExit(Collider other) {
        if(other.tag== "Player")  enemyInside = false;
}

    void Shoot(){

        muzzleFlesh.Play();

        // RaycastHit hit ;
        //hit something or not
        // if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range )){
        //     Debug.Log(hit.transform.name);

        //     Target_ target = hit.transform.GetComponent<Target_>();
        //     if(target!=null){
        //         target.TakeDamage(damage);
        //     }

        //    GameObject impactE =  Instantiate(impactEffects,hit.point, Quaternion.LookRotation(hit.normal));
        //     Destroy(impactE,2f);
        // }
    }
}
