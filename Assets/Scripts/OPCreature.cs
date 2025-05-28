using UnityEngine;
using UnityEngine.AI;

public class OPCreature : MonoBehaviour
{
    bool chasing;
    float distanceToChase = 15f, distanceToLose = 15f, distanceToStop = 2f;
  
    Vector3 targetPoint, startPoint;

    NavMeshAgent agent;
    [SerializeField] Transform[] goals;
    int destNum = 0;
    [SerializeField] int goalsNum;

    float keepChasingTime = 20.0f;
    float chaseCounter;

    [SerializeField] Animator CreatureAnimator;
    [SerializeField] AudioSource CreatureAudio;
    AudioSource BeastModeAudio;


    float moveWaitTime = 0;

    private void Start()
    {
        startPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goals[destNum].position;
      
    }
    private void Update()
    {
       
        targetPoint.y = transform.position.y;



        




            if (!chasing)
            {
                agent.speed = 3.0f;


                if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
                {
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

                    CreatureAudio.Stop();

                    moveWaitTime -= Time.deltaTime;
                    if (moveWaitTime <= 0)
                    {
                        nextGoal();
                        moveWaitTime = 1.0f;
                    }


                }
            }
            else
            {

                agent.speed = 8.0f;


                if (Vector3.Distance(transform.position, targetPoint) > distanceToStop)
                {

                    agent.destination = targetPoint;
                }
                else
                {
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

        destNum = Random.Range(0, goalsNum);
        agent.destination = goals[destNum].position;

    }





}
