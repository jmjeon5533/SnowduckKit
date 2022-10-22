using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionTab : MonoBehaviour
{
    public float BGMVolume, SFXVolume;

    public bool isOption;
    [SerializeField]
    GameObject OptionPanel;
    [SerializeField]
    Slider BGMSl, SFXSl;
    [SerializeField]
    Image BGMS, SFXS;
    [SerializeField]
    Sprite[] Sounds = new Sprite[4];

    public AudioMixer audioMixer;
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
        }
        else
        {
            OptionPanel.SetActive(false);
        }
    }
    public void OptionButton()
    {
        isOption = !isOption;
        SFXManager.SFXins.Click();
    }
    public void SetBgmVolume()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMSl.value) * 20);
    }
    public void SetSFXVolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXSl.value) * 20);
    }
}
