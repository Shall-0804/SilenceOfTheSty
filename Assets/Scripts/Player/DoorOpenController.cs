using UnityEngine;

public class DoorOpenController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("‚«‚Ä‚é");
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("‚«‚Ä‚é");
            //collision.gameObject.transform.Rotate(0,-1f,0);
            Destroy(collision.gameObject);
        }
    }
}
