using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueEndSceneManager : MonoBehaviour
{
    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Camera2;
    [SerializeField] Animator TrueCreatureAnim1;
    [SerializeField] Animator TrueCreatureAnim2;
    [SerializeField] AudioSource TrueCreaTureAudio;

    float time = 0f;
    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            if (time < 0f)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            time = 7f;
            TrueCreaTureAudio.Play();
            TrueCreatureAnim1.SetBool("EndAnim", true);
            TrueCreatureAnim2.SetBool("EndAnim", true);
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
