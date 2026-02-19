using UnityEngine;

public class MainSceneOptionDisplayer : MonoBehaviour
{
    [SerializeField] GameObject OptionPanel;

    //エスケープを押した回数記録
    //0ならオプションを開いて1なら閉じる
    int count;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (!Input.GetKeyDown(KeyCode.Escape)) { return; }

        switch (count) 
        {
            case 0:
                OptionBookManager.isOpenBook = true;
                OptionPanel.SetActive(true);
                count++;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;

            case 1:
                OptionBookManager.isOpenBook = false;
                OptionPanel.SetActive(false);
                count--;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;

        }

        


    }
}
