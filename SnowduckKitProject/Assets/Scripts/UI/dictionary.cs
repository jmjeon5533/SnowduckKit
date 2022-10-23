using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dictionary : MonoBehaviour
{
    [SerializeField]
    Image ToyPicture;
    [SerializeField]
    Text ToyNameText, ToyExplainText;
    public Sprite[] ToyImage;
    public string[] ToyName;
    public string[] ToyExplain;
    public int Number;

    void Start()
    {
        DictionarySet();
        Number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftButton()
    {
        if (Number <= 0)
            return;
        Number--;
        DictionarySet();
        SFXManager.SFXins.Click();
    }
    public void RightButton()
    {
        if (Number >= (ToyImage.Length-1))
            return;
        Number++;
        DictionarySet();
        SFXManager.SFXins.Click();
    }
    public void DictionarySet()
    {
        ToyPicture.sprite = ToyImage[Number];
        ToyNameText.text = ToyName[Number];
        ToyExplainText.text = ToyExplain[Number];
    }
}
