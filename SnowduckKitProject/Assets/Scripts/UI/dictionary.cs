using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dictionary : MonoBehaviour
{
    [SerializeField]
    Image ToyPicture;
    public Sprite[] ToyImage;
    public string[] ToyName;
    public int Number;

    void Start()
    {
        
        Number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftButton()
    {
        Number--;
        Mathf.Clamp(Number, 0, ToyImage.Length);
        DictionarySet();
    }
    public void RightButton()
    {
        Number++;
        Mathf.Clamp(Number, 0, ToyImage.Length);
        DictionarySet();
    }
    void DictionarySet()
    {
        ToyPicture.sprite = ToyImage[Number];
    }
}
