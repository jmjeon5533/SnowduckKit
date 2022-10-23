using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionTab : MonoBehaviour
{
    public static OptionTab OpTab = new OptionTab();
    private void Awake()
    {
        OpTab = this;
        DontDestroyOnLoad(gameObject);
    }
    public float BGMVolume, SFXVolume;

    public bool isOption,isDictionary;
    public GameObject OptionPanel,DictionaryPanel;
    public Slider BGMSl1,BGMSl2, SFXSl1, SFXSl2;
    public Sprite[] Sounds = new Sprite[4];

    public AudioMixer audioMixer;
    private void OnValidate()
    {
        isOption = false;
        OptionPanel.SetActive(false);

        isDictionary = false;
        DictionaryPanel.SetActive(false);
    }
    void Start()
    {
        isOption = false;
        OptionPanel.SetActive(false);

        isDictionary = false;
        DictionaryPanel.SetActive(false);
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
        if (isDictionary)
        {
            DictionaryPanel.SetActive(true);
        }
        else
        {
            DictionaryPanel.SetActive(false);
        }
    }
    public void OptionButton()
    {
        if (isDictionary)
            isDictionary = false;
            isOption = !isOption;
            SFXManager.SFXins.Click();
    }
    public void DictionaryButton()
    {
        if (isOption)
            isOption = false;
            isDictionary = !isDictionary;
            SFXManager.SFXins.Click();
    }
    public void SetBgmVolume()
    {
        if(SceneManager.GetActiveScene().name == "Ingame")
        {
            audioMixer.SetFloat("BGM", Mathf.Log10(BGMSl1.value) * 20);

        }
        else
        {
            audioMixer.SetFloat("BGM", Mathf.Log10(BGMSl2.value) * 20);
        }
    }
    public void SetSFXVolume()
    {
        if (SceneManager.GetActiveScene().name == "Ingame")
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(SFXSl1.value) * 20);

        }
        else
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(SFXSl2.value) * 20);
        }
        
    }
    public void ingameSceneLoad()
    {
        OptionPanel = GameObject.Find("OptionPanel").gameObject;
    }
}
