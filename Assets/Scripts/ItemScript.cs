using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] GameObject Light;
   
    [SerializeField] GameObject TakekeyE;
    [SerializeField] GameObject TakeBoxE;
    [SerializeField] Animator BoxAnimation;

    [SerializeField] GameObject Itemkey01;
    [SerializeField] GameObject ImageItem01;
    [SerializeField] AudioSource FlashAudio;
    //手に持っているアイテム01
    [SerializeField] GameObject takenItem01;
    [SerializeField] GameObject takenFlashlight;

    [SerializeField] GameObject ItemNotkeyText;
    [SerializeField] GameObject GetkeyText;

    //ライト切り替え
    bool LightChange = true;
    //アイテム01が取れる状態かどうか
    bool TakeItem01 = false;
    //ボックスを開けられる位置にいるか
    bool OpenBox = false;
    //アイテム０１を手に入れたかどうか
    bool Item01 = false;
    //ボックスが開いたかどうか
    bool IsBoxOpen = false;
    //手に持っているアイテムの判定
    bool handsFlashLighat = true;
    bool handsItem01 = false;
    //テキストを表示しておく時間
    float textTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && handsFlashLighat)
        {

            if (LightChange)
            {
                Light.SetActive(false);
                LightChange = false;
                FlashAudio.Play();
            }
            else if (!LightChange)
            {
                Light.SetActive(true);
                LightChange = true;
                FlashAudio.Play();
            }

        

        }

        if (Input.GetKeyDown(KeyCode.E) && TakeItem01)
        {
            Item01 = true;
            textTime = 2.0f;

            Itemkey01.SetActive(false);
            GetkeyText.SetActive(true);
            ImageItem01.SetActive(true);

        }

        

        if(Input.GetKeyDown (KeyCode.Alpha1))
        {
            takenFlashlight.SetActive(true);
            takenItem01.SetActive(false); 
            handsFlashLighat = true;
            handsItem01 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && Item01)
        {
            takenFlashlight.SetActive(false);
            takenItem01.SetActive(true);
            handsFlashLighat = false;  
            handsItem01 =true;
        }


        if(Input.GetKeyDown(KeyCode.E) && handsItem01 && OpenBox)
        {
            BoxAnimation.SetBool("OpenBox", true);
            IsBoxOpen = true;
            takenItem01.SetActive(false);
            ImageItem01.SetActive(false);
            Item01 = false;
        }
        else if(Input.GetKeyDown(KeyCode.E) && OpenBox && !Item01)
        {
            ItemNotkeyText.SetActive(true);
            textTime = 2.0f;


        }

        textTime -= Time.deltaTime;
        if (textTime <= 0)
        {
            ItemNotkeyText.SetActive(false);
            GetkeyText.SetActive(false );
        }




    }

   


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Item")
        {　
            TakekeyE.SetActive(true);
            TakeItem01 = true;

        }

        if (other.gameObject.name == "Box")
        {
            TakeBoxE.SetActive(true);
            OpenBox = true;
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Item")
        {
            TakekeyE.SetActive(false);
            TakeItem01 = false;
        }


        if (other.gameObject.name == "Box")
        {
            TakeBoxE.SetActive(false);
            OpenBox = false;
        }







    }








}
