using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill 
{
    private static skill _Instance;
    public static skill Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new skill();
            return _Instance;
        }
    }

    public void GetData(List<skill_table> datalist)
    {
        skillUI _obj = GameObject.Find("SkillInfoUI").GetComponent<skillUI>();
        
        _obj.GetData(datalist);
    }
}
