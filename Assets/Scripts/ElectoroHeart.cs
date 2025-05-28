using TMPro;
using UnityEngine;

public class ElectoroHeart : MonoBehaviour
{
    [SerializeField] TMP_Text HeartText;

    float heatTime = 1.0f;
    int heart;
    public static bool distanceCreature = false;

    // Update is called once per frame
    void Update()
    {
        if (!distanceCreature)
        {
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
