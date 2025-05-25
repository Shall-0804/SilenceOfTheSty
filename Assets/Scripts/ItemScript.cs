using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] GameObject Light;
    [SerializeField] GameObject TakeEkey;
    [SerializeField] GameObject Itemkey01;
    [SerializeField] GameObject ImageItem01;

    bool LightChange = true;
    bool TakeItem01 = false;
    bool Item01 = false; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            if (LightChange)
            {
                Light.SetActive(false);
                LightChange = false;
            }
            else if (!LightChange)
            {
                Light.SetActive(true);
                LightChange = true;
            }

        

        }

        if (Input.GetKeyDown(KeyCode.E) && TakeItem01)
        {
            Item01 = true;

            Itemkey01.SetActive(false);


        }

        if (Item01)
        {
            ImageItem01.SetActive(true);
        }










    }

   


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Item")
        {Å@
            TakeEkey.SetActive(true);
            TakeItem01 = true;

        }





    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Item")
        {
            TakeEkey.SetActive(false);
            TakeItem01 = false;
        }
    }








}
