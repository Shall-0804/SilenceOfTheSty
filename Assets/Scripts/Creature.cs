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
    float beastModeTime = 50.0f;
    bool Isbeast = false;
    [SerializeField] Slider BeastTimeSlider;
    [SerializeField] Image BeastImage;

    [SerializeField] AudioSource HeartAudio;


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

        BeastTimeSlider.value = beastModeTime * 10;

        if (!Isbeast)
        {
            
            //ビーストモードになるまでのカウント
            beastModeTime -= Time.deltaTime;
            
            if (beastModeTime <= 0)
            {
                BeastModeAudio.Play();
                CreatureAnimator.speed = 2;
                BeastTimeSlider.maxValue = 150.0f;
                Isbeast = true;
                BeastImage.color = Color.red;
            }



            if (!chasing)
            {
                agent.speed = 3.0f;


                if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
                {
                    CreatureAudio.Play();
                    CreatureAnimator.speed = 2;
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
            

            agent.speed = 8.0f;
            

            beastModeTime += Time.deltaTime;
            if (beastModeTime >= 15.0f)
            {
                BeastTimeSlider.maxValue = 900.0f;
                beastModeTime = 90.0f;
                Isbeast = false;
                CreatureAnimator.speed = 1;
                BeastImage.color = Color.white;
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


        if (Vector3.Distance(transform.position, targetPoint) < 40)
        {
            ElectoroHeart.distanceCreature = true;
            HeartAudio.volume = 0.4f;
            HeartAudio.pitch = 1.5f;
        }
        else if (Vector3.Distance(transform.position, targetPoint) >= 40)
        {
            ElectoroHeart.distanceCreature = false;
            HeartAudio.volume = 0.1f;
            HeartAudio.pitch = 0.7f;
        }


    }
    void nextGoal()
    {

        destNum = Random.Range(0, goalsNum);
        agent.destination = goals[destNum].position;

    }

    






}
  



    

