using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleOptionUiController : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] GameObject StartArrow;
    [SerializeField] GameObject OptionArrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartArrow.SetActive(false);
        OptionArrow.SetActive(true);
    }

}
