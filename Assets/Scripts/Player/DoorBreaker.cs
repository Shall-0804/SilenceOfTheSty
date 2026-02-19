using System;
using UnityEngine;

public class DoorBreaker : MonoBehaviour
{
    //ドアを壊すためのテキスト表示
    [SerializeField] GameObject BreakKeyText;

    //テキストの自動非表示のための変数
    float time;
    //音を流すため
    public event Action OnAudioPlayed;

    private void Update()
    {
        if(time <= 0)
        {
            BreakKeyText.SetActive(false);
        }
        else if(time > 0)
        {
            time -= Time.deltaTime;
        }
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            //Debug.Log("aa");
            time = 3f;
            //テキスト表示
            BreakKeyText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.V))
            {
                //AudioPlay
                OnAudioPlayed?.Invoke();

                //ドアを破壊
                other.gameObject.SetActive(false);
                BreakKeyText.SetActive(false);
            }

        }
    }


    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{


    //   if (hit.gameObject.tag == "Door")
    //   {
    //        Debug.Log("aa");
    //        time = 3f;
    //        BreakKeyText.SetActive(true);

    //        if(Input.GetKeyDown(KeyCode.V))
    //        {
    //            //ドアを破壊
    //            hit.gameObject.SetActive(false);
    //            BreakKeyText.SetActive(false);
    //        }

    //   }
    //}
}
