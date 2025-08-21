using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class BoxGenarator : MonoBehaviour
{
    [SerializeField] Vector3[] BoxPos;
    [SerializeField] Vector3[] BoxRot;
    int BoxPosNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxPosNum = Random.Range(0, BoxPos.Length);
        transform.position = BoxPos[BoxPosNum];
        transform.eulerAngles = BoxRot[BoxPosNum];
    }

    
}
