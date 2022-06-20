using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_list_clone
{
    private static obj_list_clone _Instance;
    public static obj_list_clone Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new obj_list_clone();
            return _Instance;
        }
    }

    public void OpenMainUI()
    {
        obj_list _obj = GameObject.Find("sence2").GetComponent<obj_list>();
        _obj.MainUI_Event();

    }

    public void OpenMapUI()
    {
        obj_list _obj = GameObject.Find("sence2").GetComponent<obj_list>();
        _obj.MapUI_Event();
    }

    public void OpenFightUI()
    {
        obj_list _obj = GameObject.Find("sence2").GetComponent<obj_list>();
        _obj.FightUI();


        List<monster_table> datalist = monster_data.Instance.data_list;
        string studentID = personal_data.Instance.studentID;
        int step = PlayerPrefs.GetInt(studentID);
        monster_table data = datalist[step-1];
        Fight.Instance.GetMonsterData(data);
    }


    public void OpenResultUI()
    {
        obj_list _obj = GameObject.Find("sence2").GetComponent<obj_list>();
        _obj.ResultUI();
    }

    public void OpenSkillInfoUI()
    {
        obj_list _obj = GameObject.Find("sence2").GetComponent<obj_list>();
        _obj.skillUI();
    }


    public void create_monster(int i, GameObject obj)
    {
        obj_list _obj = GameObject.Find("sence2").GetComponent<obj_list>();
        _obj.step_monster(i,obj);
    }
}
