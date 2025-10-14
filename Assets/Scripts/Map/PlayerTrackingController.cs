using UnityEngine;

public class PlayerTrackingController : MonoBehaviour
{
    [SerializeField] GameObject TargetPlayer;

    float PosX, PosZ;

    void Start()
    {
    }
    void Update()
    {
        PosX = TargetPlayer.transform.position.x;
        PosZ = TargetPlayer.transform.position.z;
        transform.position = new Vector3( PosX, 120, PosZ ); 
    }
}
