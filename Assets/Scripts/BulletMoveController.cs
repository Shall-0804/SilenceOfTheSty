using UnityEngine;

public class BulletMoveController : MonoBehaviour
{
    [SerializeField] Rigidbody BulletRb;

    float bulletSpeed = 10000f;
    
    void Update()
    {
      BulletRb.AddForce(transform.forward * Time.deltaTime * bulletSpeed);
    }
}
