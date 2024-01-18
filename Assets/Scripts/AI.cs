using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public float EnemySpeed, Startdelay;
    private float delayTime;
    private NavMeshAgent _agent;
    private Vector3 randomDestination, movePos;
    public float radius = 1, radiusForAI = 3;
    private int layerMask, layerMask2;
    private Animator _anim;
    public float dist;
    private float distFromEdge;
    public float overlapSphereRadius;
    //public float SphereCastRadius, maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 7; //ObjectsInScene
        layerMask2 = 1 << 8; //AI
        delayTime = Startdelay;
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        GetNewPath();
        NavMesh.avoidancePredictionTime = 0.5f;
        Physics.IgnoreLayerCollision(8, 8); //Ignore Layer Collision of AI
    }


    // Update is called once per frame
    void Update()
    {
        Animations();
        /*ListOfCollidersAtMovementPoint = Physics.OverlapSphere(randomDestination, radius, layerMask);
        while(ListOfCollidersAtMovementPoint.Length != 0)
        {
            randomDestination = new Vector3(Random.Range(-28, 28), 0, Random.Range(-27, 27));
            print("Stuck In Loop");
        }*/
        _agent.SetDestination(movePos);
        //print(_agent.velocity.magnitude);
        if (!_agent.hasPath)//(_agent.velocity.magnitude < 0.1)//
        {
            if(delayTime <= 0)
            {
                //randomDestination = new Vector3(Random.Range(-28, 28), 0, Random.Range(-27, 27));
                GetNewPath();
                delayTime = Startdelay;
            }
            else
            {
              delayTime -= Time.deltaTime;
            }
        }
        if(_agent.velocity.magnitude < 0.2f && _agent.hasPath)
        {
            GetNewPath();
        }
       /* Collider[] hitColliders = Physics.OverlapSphere(transform.position, overlapSphereRadius);
        foreach (Collider go in hitColliders)
        {
            if(gameObject == go.gameObject)//if it collides with itself ignore
            {
               return;
            }
            else if(go.gameObject.CompareTag("Enemy"))
            {
               // transform.position += -transform.forward * Time.deltaTime;
               // StartCoroutine(nameof(MoveBack), 2f);
                //print("Not Itself");
               GetNewPath();
            }
        }*/
        /*var forward = transform.TransformDirection(Vector3.forward);
        if (Physics.SphereCast(transform.position, SphereCastRadius, forward, out RaycastHit hit))
        {
            while(hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("EnemyCollider") || hit.collider.CompareTag("EnemyCollision"))
            {
               _agent.ResetPath();
               transform.position += -transform.forward * Time.deltaTime; //-transform.forward
               // StartCoroutine(nameof(MoveBack), 2f);
            }
        }*/

        //Make AI Stay Away From Edge Of Map/Level to avoid them getting stuck
        /* if (NavMesh.FindClosestEdge(transform.position, out NavMeshHit hit, NavMesh.AllAreas))
         {
             distFromEdge = hit.distance;
         }
         if (distFromEdge < 2)
         {
             print("Change Dir");
             GetNewPath();
         }*/
    }
    private void FixedUpdate()
    {
        //Avoid picking a destination where the Walls are located
        while (Physics.CheckSphere(movePos, radius, layerMask))
        {
            //randomDestination = new Vector3(Random.Range(-28, 28), 0, Random.Range(-27, 27));
            GetNewPath();
        }
        // Colliders[] 
        // while(Physics.OverlapSphere())

        //Avoid picking a destination that is close to another AIs destination
        Collider[] AIs = Physics.OverlapSphere(movePos, radiusForAI, layerMask2);
        foreach (Collider go in AIs)
        {
          /*  if(gameObject == go.gameObject)
            {
                print("Found Itself");
                return;
            }*/
            if(go.gameObject != gameObject)
            {
                GetNewPath();
            }
        }
           /* while (Physics.CheckSphere(randomDestination, radiusForAI, layerMask2))
        {
            randomDestination = new Vector3(Random.Range(-28, 28), 0, Random.Range(-27, 27));
            print("Dont move to same place as others");
        }*/
    }
    public void Animations()
    {
        //float SpeedOfAi = _agent.velocity.magnitude;
        //print(SpeedOfAi);
        if(_agent.velocity.magnitude > float.Epsilon)
        {
            _anim.SetFloat("Blend", 0.5f);
        }
        else
        {
            _anim.SetFloat("Blend", 0);
        }
    }
    void GetNewPath()
    {
        randomDestination = Random.insideUnitSphere * dist;
        randomDestination += transform.position;
        NavMesh.SamplePosition(randomDestination, out NavMeshHit hit, dist, 1);
        movePos = hit.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(movePos, radiusForAI);
    }

    IEnumerator MoveBack(float delay)
    {
       // print("Move Away");
        yield return new WaitForSeconds(delay);
        GetNewPath();
    }
}
