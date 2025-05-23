using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
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



    }

    public void OnClick()
    {

        chengeTime = 3.0f;

    }





}
