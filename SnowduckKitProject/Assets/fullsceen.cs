using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fullsceen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(qwer);
    }

    // Update is called once per frame
    public void qwer()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
