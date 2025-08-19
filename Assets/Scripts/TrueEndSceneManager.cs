using UnityEngine;

public class TrueEndSceneManager : MonoBehaviour
{
    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Camera2;
    [SerializeField] Animator TrueCreatureAnim1;
    [SerializeField] Animator TrueCreatureAnim2;
    [SerializeField] AudioSource TrueCreaTureAudio;

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            TrueCreaTureAudio.Play();
            TrueCreatureAnim1.SetBool("EndAnim", true);
            TrueCreatureAnim2.SetBool("EndAnim", true);
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
