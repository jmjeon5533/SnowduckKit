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

    public GameObject credits;
    bool f = false;
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
        if (f == true)
        {
            f = false;
            credits.SetActive(false);
        }
        else
        {
            f = true;
            credits.SetActive(true);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
