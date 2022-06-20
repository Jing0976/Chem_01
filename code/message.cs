using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class message
{
    private static message _Instance;
    public static message Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new message();
            return _Instance;
        }
    }


    public void message_1(string msg, string btn_text,GameObject obj)
    {
        messageUI _obj = GameObject.Find("MessageUI").GetComponent<messageUI>();
        _obj.MessageEvent_1(msg, btn_text,obj);
    }



    public void message_2(string msg, string btn1_str,string btn2_str, GameObject obj)
    {
        messageUI _obj = GameObject.Find("MessageUI").GetComponent<messageUI>();
        _obj.MessageEvent_2(msg,btn1_str,btn2_str, obj);
    }


    public void message_3(string msg)
    {
        messageUI _obj = GameObject.Find("MessageUI").GetComponent<messageUI>();
        _obj.MessageEvent_3(msg);
    }

}
