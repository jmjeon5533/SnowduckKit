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
    }

    public void CameraMove()
    {
        //Target.transform.position;
    }
}
