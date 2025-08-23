using UnityEngine;

public class OptionBookPageAudioController : MonoBehaviour
{
    [SerializeField]OptionBookManager optionBookManager;
    [SerializeField]OptionBookPageNextButtomController nextButtomController;
    [SerializeField] AudioSource OptionBookAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optionBookManager.OpenBook += AudioStart;
        nextButtomController.PageNextOpen += AudioStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void AudioStart()
    {
        OptionBookAudio.Play();
    }

}
