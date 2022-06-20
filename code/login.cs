using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class login
{
    private static login _Instance;
    public static login Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new login();
            return _Instance;
        }
    }


    public void CloseUI()
    {
        obj_list_clone.Instance.OpenMainUI();
        loginUI obj = GameObject.Find("LoginUI").GetComponent<loginUI>();
        obj.CloseUI();
        personal_data.Instance.MyUIState = personal_data.UI_state.MainUI;

    }


}
