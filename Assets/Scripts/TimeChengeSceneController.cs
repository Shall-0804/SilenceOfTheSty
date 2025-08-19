using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeChengeSceneController : MonoBehaviour
{
    [SerializeField] GameObject CAMERA;

    float sceneTime = 5.0f;
    float cameraTime = 4.5f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraTime -= Time.deltaTime;
        sceneTime -= Time.deltaTime;
        if (cameraTime < 0)
        {
            CAMERA.SetActive(true);
        }
        if (sceneTime < 0 )
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("Title");
        }






    }
}
