using UnityEngine;

public class Creature : MonoBehaviour
{

    [SerializeField] Animator CreatureAnimator;
    [SerializeField] GameObject creature;

    float moveSpeed = 3.0f;

    float WolkTime = 3.0f;
    bool moveDestination = false;

    float destinationX = 463;
    float destinationZ = 616;
    float randomPosX;
    float randomPosZ;

    Vector3 Rot = Vector3.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CreatureAnimator.GetBool("Move") && !moveDestination)
        {
            if (transform.position.x <= 500)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += transform.right * moveSpeed * Time.deltaTime;
            }





        }
        else
        {
            

            WolkTime -= Time.deltaTime;
            if (WolkTime < 0)
            {
                CreatureAnimator.SetBool("Move", false);
                WolkTime = 3.0f;
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveDestination = false;
            }

        }



        if(transform.position.x >= 500)
        {
            CreatureAnimator.SetBool("Move", true);
            moveDestination = true;
        }

        if (transform.position.z >= 700)
        {
            CreatureAnimator.SetBool("Move", true);
            moveDestination = true;
        }














    }
}
