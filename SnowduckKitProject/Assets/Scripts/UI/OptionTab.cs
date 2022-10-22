using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionTab : MonoBehaviour
{
    public bool isOption;
    [SerializeField]
    GameObject OptionPanel;
    [SerializeField]
    Slider BGM, SFX;
    [SerializeField]
    Image BGMS, SFXS;
    [SerializeField]
    Sprite[] Sounds = new Sprite[4];
    private void OnValidate()
    {
        isOption = false;
        OptionPanel.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOption)
        {
            OptionPanel.SetActive(true);
            SliderSoundImage();
        }
        else
        {
            OptionPanel.SetActive(false);
        }
    }
    public void OptionButton()
    {
        isOption = !isOption;
    }
    void SliderSoundImage()
    {
        if (BGM.value >= 75)
        {
            BGMS.sprite = Sounds[0];
        }
        else if (BGM.value >= 40)
        {
            BGMS.sprite = Sounds[1];
        }
        else if (BGM.value >= 1)
        {
            BGMS.sprite = Sounds[2];
        }
        else if (BGM.value == 0)
        {
            BGMS.sprite = Sounds[3];
        }

        if (SFX.value >= 75)
        {
            SFXS.sprite = Sounds[0];
        }
        else if (SFX.value >= 40)
        {
            SFXS.sprite = Sounds[1];
        }
        else if (SFX.value >= 1)
        {
            SFXS.sprite = Sounds[2];
        }
        else if (SFX.value == 0)
        {
            SFXS.sprite = Sounds[3];
        }
    }
}
