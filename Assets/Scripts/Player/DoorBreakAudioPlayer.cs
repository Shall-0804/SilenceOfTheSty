using UnityEngine;

public class DoorBreakAudioPlayer : MonoBehaviour
{
    //オーディオ
    [SerializeField] AudioSource DoorBreakAudio;
    [SerializeField] DoorOpener doorOpner;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorOpner.OnAudioPlayed += PlayAudio ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayAudio()
    {
        DoorBreakAudio.Play();
    }
}
