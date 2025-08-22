using TMPro;
using UnityEngine;

public class ElectoroHeartManager : MonoBehaviour
{
    [SerializeField] TMP_Text HeartText;
    [SerializeField] Animator HeartAnimator;
    
    float heatTime = 1.0f;
    int heart;
    public static bool distanceCreature = false;

    // Update is called once per frame
    void Update()
    {
        //オプションブックを読んだら止める
        if (OptionBookManager.isOpenBook) { return; }



        if (!distanceCreature)
        {
            HeartAnimator.speed = 1;
            heatTime -= Time.deltaTime;
            if (heatTime < 0)
            {
                heart = Random.Range(81, 88);
                heatTime = 1.0f;
                HeartText.text = heart.ToString();  

            }
        }
        else
        {
            HeartAnimator.speed = 2;
            heatTime -= Time.deltaTime;
            if (heatTime < 0)
            {
                heart = Random.Range(112, 117);
                heatTime = 1.0f;
                HeartText.text = heart.ToString();

            }
        }




    }
}
