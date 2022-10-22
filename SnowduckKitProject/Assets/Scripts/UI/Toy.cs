using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToyType
    {
        Duck,
        Wood,
        Gold,
        Military,
        Jade,
        Patten,
        Iron,
        Cuteduck,
        Apple,
        Banana,
        Flower,
        Peach,
        WaterMelon
    }
[System.Serializable]
public class Toy
{
   
    public ToyType ToyType;
    public string ToyName;
    public Sprite ToyImage;
    public string ToyExplain;
    
    public bool Use()
    {
        return false;
    }
}
