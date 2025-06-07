using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ShotScript : MonoBehaviour
{
    [SerializeField] Animator ShotAnim;
    [SerializeField] GameObject Muzzleflash;
    [SerializeField] TMP_Text bulletsRemainText;
    [SerializeField] GameObject Muzzle;
    [SerializeField] GameObject Bullet;
    Vector3 muzzlePos;

    public static int bulletsRemain = 6;
    float muzzleFlashTime;
    float animTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     bulletsRemainText.text = bulletsRemain.ToString();
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

                //ŽËŒ‚
                if (Input.GetMouseButtonDown(0))
                {
                  //Žc’i”‚ªƒ[ƒ‚¶‚á‚È‚¯‚ê‚ÎŒ‚‚Ä‚é
                  if (bulletsRemain > 0)
                  {
                    muzzlePos = Muzzle.transform.position;
                    Quaternion muzzleRot = Camera.main.transform.rotation;
                    bulletsRemain--;

                    GameObject Obj = Instantiate(Bullet,muzzlePos,muzzleRot);
                    Destroy(Obj, 1.0f);
                    bulletsRemainText.text = bulletsRemain.ToString();
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
