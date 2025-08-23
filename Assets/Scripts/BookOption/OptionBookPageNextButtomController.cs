using System;
using UnityEngine;

public class OptionBookPageNextButtomController : MonoBehaviour
{
    [SerializeField] GameObject NowPage;
    [SerializeField] GameObject NextPage;

    public event Action PageNextOpen;

    public void OnClick()
    {
        PageNextOpen?.Invoke();
        NextPage.SetActive(true);
        NowPage.SetActive(false);
    }
}
