using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    Sprite[] background = new Sprite[2];
    [SerializeField]
    Image BackG;
    void Start()
    {
        BackG.sprite = background[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IngameSceneMove()
    {
        SceneManager.LoadScene("ingame");
    }
    public void Setting()
    {

    }
    public void Credit()
    {

    }
    public void Exit()
    {

    }
}
