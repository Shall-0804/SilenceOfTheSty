using System;
using UnityEngine;

public class BookController : MonoBehaviour
{
    [SerializeField] GameObject BookReadText;

    public event Action ReadBook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Book")
        {
            BookReadText.SetActive(true);
            ReadBook?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Book")
        {
            BookReadText.SetActive(false);
            OptionBookManager.isOpenBook = false;
        }
    }




}
