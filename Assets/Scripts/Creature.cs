using UnityEngine;
using UnityEngine.AI;

public class Creature : MonoBehaviour
{
    bool chasing;
    float distanceToChase = 8f, distanceToLose = 15f, distanceToStop = 2f;
    [SerializeField] GameObject Player;
 
    Vector3 targetPoint, startPoint;

    NavMeshAgent agent;
    [SerializeField] Transform[] goals;
    int destNum = 0;

    float keepChasingTime = 20f;
    float chaseCounter;

    [SerializeField] Animator CreatureAnimator;
    [SerializeField] AudioSource CreatureAudio;

    float moveWaitTime = 0;

    private void Start()
    {
        startPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goals[destNum].position;
    }
    private void Update()
    {
        targetPoint = Player.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                CreatureAnimator.SetBool("Find",true);
                CreatureAudio.Play();
                chasing = true;
            }
            if (chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;
                if (chaseCounter <= 0)
                {
                    nextGoal();
                }
            }

            if (agent.remainingDistance < 0.5f)
            {
                CreatureAnimator.SetBool("Find", false);
                CreatureAudio.Stop();
                moveWaitTime -= Time.deltaTime;
               if(moveWaitTime <= 0)
               {
                    nextGoal();
                    moveWaitTime = 5.0f;
               }   
               
                
            }
        }
        else
        {

            if (Vector3.Distance(transform.position, targetPoint) > distanceToStop)
            {
                CreatureAnimator.SetBool("Find", true);
                agent.destination = targetPoint;
            }
            else
            {
                CreatureAnimator.SetBool("Find", true);
                agent.destination = transform.position;
            }

            if (Vector3.Distance(transform.position, targetPoint) > distanceToLose)
            {
                chasing = false;
                chaseCounter = keepChasingTime;
            }
        }

    }
    void nextGoal()
    {

        destNum = Random.Range(0, 13);
        agent.destination = goals[destNum].position;

    }

}
  



    

