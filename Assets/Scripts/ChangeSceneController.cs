using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{


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
            SceneManager.LoadScene("MainScene");
        }


        if(Input.GetKeyDown(KeyCode.Return))
        {
            chengeTime = 2.0f;
        }




    }

    public void OnClick()
    {

        chengeTime = 2.0f;

    }





}
