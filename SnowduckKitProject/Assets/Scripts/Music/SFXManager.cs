using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager SFXins = new SFXManager();
    public AudioSource[] SFX = new AudioSource[5];
    private void Awake()
    {
        SFXins = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        SFX[0].Play();
    }
    public void disappear()
    {
        SFX[1].Play();
    }
    public void appear()
    {
        SFX[2].Play();
    }
    public void Move()
    {
        SFX[3].Play();
    }
    public void Eat()
    {
        SFX[4].Play();
    }
}
