using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public List<GameObject> SaveObjects = new List<GameObject>();
    public int Point;
    public List<string> Achievement = new List<string>();

}

public class DataStore : MonoBehaviour
{
    private static SaveData _Save = new SaveData();

    
    public static bool SetAchievement(string _Achievement)// 도감 저장. 아이템 획득할 때마다 실행해주세요.
    {
        if (!_Save.Achievement.Contains(_Achievement))
        {
            _Save.Achievement.Add(_Achievement);
            return true;
        }
        return false;
    }

    public static List<string> SetAchievement()
    {
        return _Save.Achievement;
    }

    
    public static void AddObject (GameObject _NewObject)// 오브젝트 생성 시 동작시켜 주세요.
    {
        _Save.SaveObjects.Add(_NewObject);
    }

    
    public static void RemoveObject(GameObject _NewObject)// 오브젝트 제거 시 동작시켜 주세요.
    {
        _Save.SaveObjects.Remove(_NewObject);
    }

    
    public static void AddPoint(int _Point)// 포인트 획득 시 실행.
    {
        _Save.Point += _Point;
    }
    
    public static void SetPoint (int _Point)// 포인트 강제로 변경 시 실행.
    {
        _Save.Point = _Point;
    }
    
    public static int GetPoint ()// 현제 포인트 정보를 알기 위해서 실행.
    {
        return _Save.Point;
    }


    private void Start()
    {
        Load();
    }

    private void Load()
    {
        string _SaveData = PlayerPrefs.GetString("Save");
        if (_SaveData != null)
        {
            _Save = JsonUtility.FromJson<SaveData>(_SaveData);
        }
        else
        {
            _Save = new SaveData();
        }
    }


    private void OnDestroy()
    {
        Save();
    }

    private void Save()
    {
        string _SaveData = JsonUtility.ToJson(_Save);
        PlayerPrefs.SetString("Save", _SaveData);
    }

}
