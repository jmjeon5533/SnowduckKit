using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManger : MonoBehaviour
{
    public static BGMManger BGMins = new BGMManger();
    private void Awake()
    {
        BGMins = this;
        DontDestroyOnLoad(gameObject);
    }
    public AudioSource[] BGM = new AudioSource[3];
    void Start()
    {
        StartCoroutine(BGMStart());
    }
    IEnumerator BGMStart()
    {
        BGM[0].Play();
        yield return new WaitForSeconds(180);
        BGM[1].Play();
        yield return new WaitForSeconds(238);
        BGM[2].Play();
        yield return new WaitForSeconds(206);
        StartCoroutine(BGMStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
