using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call_server_clone 
{
    private static call_server_clone _Instance;
    public static call_server_clone Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new call_server_clone();
            return _Instance;
        }
    }

    public void LoginSend(string studentID, string name)
    {
        call_server _obj = GameObject.Find("Call_Server").GetComponent<call_server>();
        _obj.GetToken(studentID, name);
    }

    public void EndToken()
    {
        call_server _obj = GameObject.Find("Call_Server").GetComponent<call_server>();
        _obj.send_token_end(personal_data.Instance.Token);
    }


    public void UpdateSkill(WebCamTexture backCam)
    {
        call_server _obj = GameObject.Find("Call_Server").GetComponent<call_server>();
        _obj.update_skill(backCam);
    }

    public void send_question()
    {
        call_server _obj = GameObject.Find("Call_Server").GetComponent<call_server>();

        if (Fight.Instance.skill_data == null)
        {

            return;
        }
        else
        {
            _obj.send_question(Fight.Instance.skill_data.ID);
            return;
        }
    }

    public void answer_the_question(string Answer)
    {
        call_server _obj = GameObject.Find("Call_Server").GetComponent<call_server>();
        _obj.answer_the_question(personal_data.Instance.Token,Fight.Instance.topic1_data_table1.ID,Answer);

    }

    public void get_skill_data()
    {
        call_server _obj = GameObject.Find("Call_Server").GetComponent<call_server>();
        _obj.get_skill_data(personal_data.Instance.Token);
    }

    public void send_skill_answer(string answer)
    {
        call_server _obj = GameObject.Find("Call_Server").GetComponent<call_server>();
        _obj.upload_skill_answer(answer);
    }
}
