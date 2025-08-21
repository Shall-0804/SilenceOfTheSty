using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    [SerializeField] GameObject StartArrow;
    [SerializeField] GameObject OptionArrow;

    float chengeTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chengeTime >0f)
        {
            chengeTime -= Time.deltaTime;
        }

        if (chengeTime < 0f)
        {
            if (OptionArrow.activeSelf == false)
            {
                SceneManager.LoadScene("MainScene");
            }
            else if (OptionArrow.activeSelf == true)
            {
                SceneManager.LoadScene("OptionScene");
            }
        }


        if(Input.GetKeyDown(KeyCode.Return))
        {
            chengeTime = 2.0f;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(StartArrow.activeSelf == false)
            {
                StartArrow.SetActive(true);
                OptionArrow.SetActive(false);
            }
            else
            {
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (OptionArrow.activeSelf == false)
            {
                StartArrow.SetActive(false);
                OptionArrow.SetActive(true);
            }
            else
            {
                return;
            }
        }


    }
    

    public void OnClick()
    {

        chengeTime = 2.0f;

    }





}
