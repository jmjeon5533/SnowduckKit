using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyDatabase : MonoBehaviour
{
    public GameObject ButtonOrigin;
    public GameObject Vf;
    public ToyDatabase This;

    private Dictionary<GameObject, GameObject> Buttons = new Dictionary<GameObject, GameObject>(); 

    private void Awake()
    {
        This = this;
    }

    public void AddToy (GameObject _Target)
    {
        if (DataStore.AddObject(_Target))
        {
            Buttons.Add(_Target, Instantiate(ButtonOrigin, Vf.transform));
            Buttons[_Target].GetComponent<CameraMoveButton>().Target = _Target;
        }
    }

    public void RemoveToy (GameObject _Target)
    {
        DataStore.RemoveObject(_Target);
        Destroy(Buttons[_Target]);
        Buttons.Remove(_Target);
        Destroy(_Target);
    }
}
