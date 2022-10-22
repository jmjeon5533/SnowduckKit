using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    RectTransform ToyP; //토이 패널
    int RectPosition;
    [SerializeField]
    bool isToyPanel; //토이 패널이 열림/닫힘

    [SerializeField]
    Image[] ToyImage = new Image[7];

    List<Toy> ToyPanel = new List<Toy>();
    void Start()
    {
        ToyP.anchoredPosition = new Vector2(-1100, 30);
        isToyPanel = false;
        //토이 패널 : 닫힘
        //for (int i = 0; i < 7; i++)
        //{
        //    //ToyImage[i].enabled = false;
        //}
    }

    
    void Update()
    {
        ToyPanelM();
    }
    public void ToypanelB() //토이패널 버튼
    {
        isToyPanel = !isToyPanel;
    }
    void ToyPanelM() //토이패널 움직임
    {
        if (isToyPanel)
            RectPosition = 0;
        else
            RectPosition = -1100;   
        
        ToyP.anchoredPosition
            = new Vector2(Mathf.Lerp(ToyP.anchoredPosition.x, RectPosition, 0.05f), 30);
    }
    /*public void ToyPanelReset()
    {
        int i = 0;
        for(; i < ToyPanel.Count && i < )
    }
    */
}
