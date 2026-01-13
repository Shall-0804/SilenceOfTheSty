using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    //ドアを壊すためのテキスト表示
    [SerializeField] GameObject BreakKeyText;

    //テキストの自動非表示のための変数
    float time;
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
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if (hit.gameObject.tag == "Door")
       {
            time = 3f;
            BreakKeyText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.V))
            {
                //ドアを破壊
                hit.gameObject.SetActive(false);
                BreakKeyText.SetActive(false);
            }
            
       }
    }
        
}
