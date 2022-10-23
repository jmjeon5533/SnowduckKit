using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    GameObject OptionPanel;

    [SerializeField]
    Sprite[] background = new Sprite[2];
    [SerializeField]
    Image BackG;
    void Start()
    {
        BackG.sprite = background[0];
        OptionPanel.SetActive(false);
        OptionTab.OpTab.isOption = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OptionTab.OpTab.isOption)
        {
            OptionPanel.SetActive(true);
        }
        else
        {
            OptionPanel.SetActive(false);
        }
    }
    public void OptionButton()
    {
        
    }
    public void IngameSceneMove()
    {
        SceneManager.LoadScene("ingame");
    }
    public void Setting()
    {
        var op = OptionTab.OpTab;
        op.isOption = !op.isOption;
        SFXManager.SFXins.Click();
    }
    public void Credit()
    {

    }
    public void Exit()
    {

    }
}
