
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlesh;
    public GameObject impactEffects;


    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot(){

        muzzleFlesh.Play();

        RaycastHit hit ;
        //hit something or not
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range )){
            Debug.Log(hit.transform.name);

            Target_ target = hit.transform.GetComponent<Target_>();
            if(target!=null){
                target.TakeDamage(damage);
            }

           GameObject impactE =  Instantiate(impactEffects,hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactE,2f);
        }
    }
}
