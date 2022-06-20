using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personal_data
{
    private static personal_data _Instance;
    public static personal_data Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new personal_data();
            return _Instance;
        }
    }

    private string _studentID;
    public string studentID
    {
        get
        {
            return _studentID;
        }
        set
        {
            _studentID = value;
        }

    }


    private string _name;
    public string name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    private string token = string.Empty;
    public string Token {
        get {
            return token;
        }
        set {
            token = value;
        }

    }


    public enum UI_state
    {
        none = 0,
        LoginUI =1,
        MainUI = 2,
        MapUI =3,
        FightUI = 4,
        ResultUI =5,
        SkillInfoUI=6


    }


    public UI_state MyUIState;

    private int _step = 1;
    public int step
    {
        get {
            return _step;
        }
        set
        {
            _step = value;
        }
    }



}
