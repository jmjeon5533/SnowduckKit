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
    public GameObject[] AllPrefebs;

    public static bool SetAchievement(string _Achievement)// 도감 저장. 아이템 획득할 때마다 실행해주세요.
    {
        if (!_Save.Achievement.Contains(_Achievement))
        {
            _Save.Achievement.Add(_Achievement);
            return true;
        }
        return false;
    }

    public static List<string> GetAchievement()
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
        InvokeRepeating("Save", 60f, 60f);
    }

    private void Load()
    {
        string _SaveData = PlayerPrefs.GetString("Save");
        Debug.Log(_SaveData);
        SaveDataFormat nSDF = new SaveDataFormat();
        if (_SaveData != null)
        {
            nSDF = JsonUtility.FromJson<SaveDataFormat>(_SaveData);
            _Save.Point = nSDF.Point;
            _Save.Achievement = nSDF.Achievement;

            for (int i = 0; i < nSDF.Name.Count ; i++)
            {
                foreach(GameObject nOb in AllPrefebs)
                {
                    if(nOb.name == nSDF.Name[i])
                    {
                        GameObject nGO = Instantiate((GameObject)nOb, nSDF.Pos[i], Quaternion.Euler(nSDF.Rot[i]));
                        _Save.SaveObjects.Add(nGO);
                        break;
                    }
                }
            }
        }
        else
        {
            _Save = new SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    //private void OnDestroy()
    //{
    //    Save();
    //}

    private void Save()
    {
        SaveDataFormat nSDF = new SaveDataFormat();
        nSDF.Point = GetPoint();
        foreach(GameObject nGO in _Save.SaveObjects)
        {
            nSDF.Name.Add(nGO.name.Substring(0, nGO.name.Length - 7));
            nSDF.Pos.Add(nGO.transform.position);
            nSDF.Rot.Add(nGO.transform.rotation.eulerAngles);
        }
        nSDF.Achievement = _Save.Achievement;

        string _SaveData = JsonUtility.ToJson(nSDF);
        PlayerPrefs.SetString("Save", _SaveData);
        Debug.Log(_SaveData);
    }

}

[SerializeField]
public class SaveDataFormat
{
    public int Point;
    public List<string> Name = new List<string>();
    public List<Vector3> Pos = new List<Vector3>();
    public List<Vector3> Rot = new List<Vector3>();
    public List<string> Achievement = new List<string>();
}