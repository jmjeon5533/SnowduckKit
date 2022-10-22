using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMoveButton : MonoBehaviour
{
    public GameObject Target;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CameraMove);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/" + Target.name.Substring(0, Target.name.Length - 7));
    }

    public void CameraMove()
    {
        //Target.transform.position;
    }
}
