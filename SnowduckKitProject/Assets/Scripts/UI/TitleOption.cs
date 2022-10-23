using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class TitleOption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isOption)
        //{
        //    OptionPanel.SetActive(true);
        //}
        //else
        //{
        //    OptionPanel.SetActive(false);
        //}
    }
    public void OptionButton()
    {
        var op = OptionTab.OpTab;
        if (op.isDictionary)
            op.isDictionary = false;
        op.isOption = !op.isOption;
        SFXManager.SFXins.Click();
    }
}
