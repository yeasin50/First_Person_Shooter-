using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyControler : MonoBehaviour
{

    public float lookRadius = 4f;

    Transform traget;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        traget = playerManager1.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(traget.position, transform.position);
        
        if(distance<=lookRadius){
            agent.SetDestination(traget.position);
            Debug.Log("In Range");
        }
    }

      // debug
    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
