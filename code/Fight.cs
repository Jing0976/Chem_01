using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight 
{
    private static Fight _Instance;
    public static Fight Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new Fight();
            return _Instance;
        }
    }

    public void GetMonsterData(monster_table _data)
    {
        FightUI _obj = GameObject.Find("FightUI").GetComponent<FightUI>();
        _obj.GetMonsterData(_data);

    }

    public void show_read_pic_fail()
    {
        GameObject _obj = GameObject.Find("FightUI").gameObject;

        message.Instance.message_1(message_str.read_pic_fail, message_str.confirm_btn, _obj);

    }

    public void show_read_pic_message()
    {
        GameObject _obj = GameObject.Find("FightUI").gameObject;

        message.Instance.message_1(description, message_str.call_question, _obj);


    }

    private topic1_data_table _skill_data;
    public topic1_data_table skill_data
    {
        get
        {
            return _skill_data;
        }
        set
        {
            _skill_data = value;
        }
    }

    private string _description;
    public string description
    {
        get
        {
            _description = string.Format("{0} {1}\n{2}{3}", skill_data.topic,skill_data.Chemical_formula,skill_data.Commentary,skill_data.Source);
            return _description;
        }
    }

    public void read_pic_loging()
    {
        GameObject _obj = GameObject.Find("FightUI").gameObject;
        message.Instance.message_1(message_str.read_pic, message_str.confirm_btn, _obj);

       
    }


    public void send_question()
    {
        call_server_clone.Instance.send_question();
        //FightEvent_GetQuestion();
    }

    public void FightEvent_GetQuestion()
    {

        FightUI _obj = GameObject.Find("FightUI").GetComponent<FightUI>();
        _obj.FightEvent_GetQuestion();

    }

    private topic1_data_table1 _topic1_data_table1;
    public topic1_data_table1 topic1_data_table1
    {
        get
        {
            return _topic1_data_table1;
        }
        set
        {
            _topic1_data_table1 = value;
        }
    }

    public void changePlayerHP()
    {
        FightUI _obj = GameObject.Find("FightUI").GetComponent<FightUI>();
        _obj.changePlayerHP();
    }

    public void changeCubeHP()
    {
        FightUI _obj = GameObject.Find("FightUI").GetComponent<FightUI>();
        _obj.changeCubeHP();
    }
}
