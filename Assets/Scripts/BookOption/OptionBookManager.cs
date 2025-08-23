using System;
using UnityEngine;

public class OptionBookManager : MonoBehaviour
{
    [SerializeField] BookController bookController;
    [SerializeField] GameObject BookPanel;

    public static bool isOpenBook = false;
    bool canReadBook = false;

    public event Action OpenBook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bookController.ReadBook += ReadOptionBook;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenBook) { return; }

        if (canReadBook)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                isOpenBook = true;
                OpenBook?.Invoke();
                BookPanel.SetActive(true);
            }
        }

    }
    void ReadOptionBook()
    {
        canReadBook = true;
    }

    public void OnClick()
    {
        // マウスカーソルを非表示にし、位置を固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isOpenBook = false;
        BookPanel.SetActive(false);
    }

}
