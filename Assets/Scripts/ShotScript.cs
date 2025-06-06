using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] Animator ShotAnim;
    [SerializeField] GameObject Muzzleflash;
    //ToDo
    //[SerializeField] GameObject Muzzle;
    //[SerializeField] GameObject Bullet;

    public static int bulletsRemain = 6;
    float muzzleFlashTime;
    float animTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (animTime > 0)
            {
                animTime -= Time.deltaTime;
                muzzleFlashTime -= Time.deltaTime;
            }
            else if (animTime <= 0)
            {
                ShotAnim.SetBool("Shot", false);


                if (Input.GetMouseButtonDown(0))
                {
                  //Žc’i”‚ªƒ[ƒ‚¶‚á‚È‚¯‚ê‚ÎŒ‚‚Ä‚é
                  if (bulletsRemain > 0)
                  {
                    
                    bulletsRemain--;
                    ShotAnim.SetBool("Shot", true);
                    Muzzleflash.SetActive(true);
                    muzzleFlashTime = 0.1f;
                    animTime = 0.6f;
                  }
                }

            }

            if (muzzleFlashTime < 0)
            {
                Muzzleflash.SetActive(false);
            }
    }
}
