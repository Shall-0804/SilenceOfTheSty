using UnityEngine;
using UnityEngine.EventSystems;

public class TitleStartUiController : MonoBehaviour, IPointerEnterHandler
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
        StartArrow.SetActive(true);
        OptionArrow.SetActive(false);
    }
}
