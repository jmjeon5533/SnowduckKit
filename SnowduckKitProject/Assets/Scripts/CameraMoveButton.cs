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
        Transform CameraTr = Camera.main.transform;
        if (Target.CompareTag("Duck"))
        {
            if (CameraTr.parent != null)
            {
                CameraTr.parent.parent.GetComponent<DuckObject>().isSelected = false;
                CameraTr.parent = null;
            }
            Target.transform.GetComponent<DuckObject>().isSelected = true;
            CameraTr.position = Target.transform.GetChild(0).position;
            CameraTr.rotation = Target.transform.GetChild(0).rotation;
            CameraTr.parent = Target.transform.GetChild(0);
            CameraTr.GetComponent<CameraMove>().Mode = 1;
        }
    }
        //Target.transform.position;

    
}
