using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main
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

    
}
