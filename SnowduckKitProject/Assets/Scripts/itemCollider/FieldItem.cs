using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Toy toy;
    public SpriteRenderer image;

    public void SetToy(Toy _toy)
    {
        toy.ToyName = _toy.ToyName;
        toy.ToyImage = _toy.ToyImage;
        toy.ToyType = _toy.ToyType;

        image.sprite = toy.ToyImage;
    }
    public Toy GetToy()
    {
        return toy;
    }
    public void DestroyToy()
    {
        Destroy(gameObject);
    }
}
