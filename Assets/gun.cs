
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit ;
        //hit something or not
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range )){
            Debug.Log(hit.transform.name);

            Target_ target = hit.transform.GetComponent<Target_>();
            if(target!=null){
                target.TakeDamage(damage);
            }
        }
    }
}
