using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dictionary : MonoBehaviour
{
    [SerializeField]
    Image ToyPicture;
    public Sprite[] ToyImage;
    public int dictionaryNumber = 0;

    void Start()
    {
        ToyPicture.sprite = ToyImage[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftButton()
    {

    }
    public void RightButton()
    {

    }
}
