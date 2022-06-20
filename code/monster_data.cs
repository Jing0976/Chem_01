using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_data
{
    

    private static monster_data _Instance;
    public static monster_data Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new monster_data();
            }
            return _Instance;
        }
    }

    private int Count = 10;
    private int HP = 5;
    private int Attack = 1;



    public void CreateData()
    {
        _data_list = new List<monster_table>();
        for (int i = 0; i < Count; i++)
        {
            monster_table data = new monster_table();
            data.ID = i;
//            Debug.Log(i);
            data.name = "monster_" + i.ToString();
            data.HP = HP * (i+1);
            data.Attack = Attack * (i+1);
            _data_list.Add(data);
        }
    }

    private List<monster_table> _data_list;

    public List<monster_table> data_list
    {
        get
        {
            return _data_list;
        }
    }

    public static implicit operator monster_data(monster_table v)
    {
        throw new NotImplementedException();
    }
}
