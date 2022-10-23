using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Screenshot : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Shot);
    }

    public void Shot ()
    {
        ScreenCapture.CaptureScreenshot(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Screenshot"+ DateTime.Now.ToString("yyyyMMddhhmmss")+".png");
    }
}
