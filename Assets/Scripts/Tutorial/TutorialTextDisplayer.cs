using UnityEngine;

public class TutorialTextDisplayer : MonoBehaviour
{
    //表示するテキストを保持するため
    [SerializeField] GameObject TutorialText1;
    [SerializeField] GameObject TutorialText2;
    [SerializeField] GameObject TutorialText3;
    [SerializeField] GameObject TutorialText4;

    //テキストを表示している時間
    float tutorialTime;

    const float TIME = 2;

    //現在表示してあるテキストを識別するため
    int TextNum;

    //先にテキスト表示したいから
    void Awake()
    {
        TutorialText1.SetActive(true);
        TextNum = 1;
    }

   
    void Start()
    {
        tutorialTime = TIME;
    }


    void Update()
    {
        if(tutorialTime <= 0) { TextErase(); return; }

        tutorialTime -= Time.deltaTime;
    }
    
    //本を読んだ後のチュートリアルテキスト表示するため
    public void OnClick()
    {
        tutorialTime = TIME;
        TextNum = 3;
        TutorialText3.SetActive(true);

    }

    void TextErase()
    {
        switch (TextNum) 
        { 
            case 1
                : TutorialText1.SetActive(false); 
                //次のテキストを表示
                TutorialText2.SetActive(true);
                tutorialTime = TIME;
                TextNum = 2;
                break;

            case 2 
                : TutorialText2.SetActive(false);
               break;

            case 3
                : TutorialText3.SetActive(false);
               break;

            case 4 
                : TutorialText4.SetActive(false); 
               break;
        }

    }
}
