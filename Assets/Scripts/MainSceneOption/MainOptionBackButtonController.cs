using UnityEngine;
using UnityEngine.SceneManagement;

public class MainOptionBackButtonController : MonoBehaviour
{
    public void OnClick()
    {
        OptionBookManager.isOpenBook = false;
        SceneManager.LoadScene("Title");
    }

}
