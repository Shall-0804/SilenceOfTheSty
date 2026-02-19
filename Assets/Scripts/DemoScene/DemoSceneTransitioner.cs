using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoSceneTransitioner : MonoBehaviour
{
    //30•bŒã‚É‚Å‚àƒV[ƒ“‚ÉˆÚ“®‚·‚é‚½‚ß‚ÌŠÔ
    float time;
    const float TIME = 30;
   void Start()
   {
        time = TIME;
   }

    void Update()
    {
        if(time <= 0) { LoadScene();  return; }

        time -= Time.deltaTime;
    }

    void LoadScene()
    {
        SceneManager.LoadScene("DemoScene");
    }




}
