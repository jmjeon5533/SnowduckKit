using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    RectTransform ToyP; //���� �г�
    int RectPosition;
    [SerializeField]
    bool isToyPanel; //���� �г��� ����/����

    [SerializeField]
    Image[] ToyImage = new Image[7];

    List<Toy> ToyPanel = new List<Toy>();
    void Start()
    {
        ToyP.anchoredPosition = new Vector2(-1100, 30);
        isToyPanel = false;
        //���� �г� : ����
        //for (int i = 0; i < 7; i++)
        //{
        //    //ToyImage[i].enabled = false;
        //}
    }

    
    void Update()
    {
        ToyPanelM();
    }
    public void ToypanelB() //�����г� ��ư
    {
        isToyPanel = !isToyPanel;
    }
    void ToyPanelM() //�����г� ������
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
