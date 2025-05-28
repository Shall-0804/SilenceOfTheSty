using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Creature : MonoBehaviour
{
    bool chasing;
    float distanceToChase = 15f, distanceToLose = 15f, distanceToStop = 2f;
    [SerializeField] GameObject Player;
 
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

    //時間で追いかけるようにするため
    float beastModeTime = 30.0f;
    bool Isbeast = false;
    [SerializeField] Slider BeastTimeSlider;

    float moveWaitTime = 0;

    private void Start()
    {
        startPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goals[destNum].position;
        BeastModeAudio =  Player.GetComponent<AudioSource>();
    }
    private void Update()
    {
        targetPoint = Player.transform.position;
        targetPoint.y = transform.position.y;

    

        if (!Isbeast)
        {
            
            //ビーストモードになるまでのカウント
            beastModeTime -= Time.deltaTime;
            BeastTimeSlider.value = beastModeTime * 10;
            if (beastModeTime <= 0)
            {
                Isbeast = true;
            }



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
        else if (Isbeast)
        {
            BeastModeAudio.Play();
            agent.speed = 6.0f;

            beastModeTime += Time.deltaTime;
            if (beastModeTime >= 30.0f)
            {
                beastModeTime = 30.0f;
                Isbeast = false;  
            }


            if (Vector3.Distance(transform.position, targetPoint) > distanceToStop)
            {

                agent.destination = targetPoint;
            }
            else
            {
                agent.destination = transform.position;
            }

            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                CreatureAudio.Play();
            }




        }




    }
    void nextGoal()
    {

        destNum = Random.Range(0, goalsNum);
        agent.destination = goals[destNum].position;

    }

    






}
  



    

