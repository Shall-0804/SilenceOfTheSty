using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtomcontroller : MonoBehaviour
{
   public void OnClick()
    {
        SceneManager.LoadScene("Title");
    }
}
