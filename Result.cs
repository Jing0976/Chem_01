using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result
{
    private static Result _Instance;
    public static Result Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new Result();
            return _Instance;
        }
    }

    public void Show_Win()
    {
        ResultUI _obj = GameObject.Find("ResultUI").GetComponent<ResultUI>();
        _obj.Show_Win();
    }

    public void Show_Lose()
    {
        ResultUI _obj = GameObject.Find("ResultUI").GetComponent<ResultUI>();
        _obj.Show_Lose();
    }

}
