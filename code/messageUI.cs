using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class messageUI : MonoBehaviour
{
    GameObject obj;
    GameObject _Myobj;

    Text messsage_text;

    Button confirm_btn, cancel_btn, ok_btn;

    Text confirm_text, cancel_text, ok_text;

    void Start()
    {
        obj = this.transform.Find("obj").gameObject;
        messsage_text = this.transform.Find("obj/Canvas/bg/frame/Scroll View/Viewport/Content/Text").GetComponent<Text>();

        confirm_btn = this.transform.Find("obj/Canvas/bg/frame/btn_list/confirm_btn").GetComponent<Button>();
        cancel_btn = this.transform.Find("obj/Canvas/bg/frame/btn_list/cancel_btn").GetComponent<Button>();
        ok_btn = this.transform.Find("obj/Canvas/bg/frame/btn_list/ok_btn").GetComponent<Button>();

        confirm_text = this.transform.Find("obj/Canvas/bg/frame/btn_list/confirm_btn/Text").GetComponent<Text>();
        cancel_text = this.transform.Find("obj/Canvas/bg/frame/btn_list/cancel_btn/Text").GetComponent<Text>();
        ok_text = this.transform.Find("obj/Canvas/bg/frame/btn_list/ok_btn/Text").GetComponent<Text>();

        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MessageEvent_1(string meg,string btn_msg ,GameObject _obj)
    {
        obj.SetActive(true);
        confirm_btn.gameObject.SetActive(false);
        cancel_btn.gameObject.SetActive(false);
        ok_btn.gameObject.SetActive(true);
        _Myobj = _obj;
        _Myobj.SetActive(false);

        messsage_text.text = meg;
        ok_text.text = btn_msg;

    }


    public void CloseEvent1()
    {
        _Myobj.SetActive(true);
        obj.SetActive(false);
        if (personal_data.Instance.MyUIState == personal_data.UI_state.FightUI)
        {
            Fight.Instance.send_question();
        }
    }


    public void MessageEvent_2(string meg, string confirm_msg,string cancel_msg ,GameObject _obj)
    {
        obj.SetActive(true);
        confirm_btn.gameObject.SetActive(true);
        cancel_btn.gameObject.SetActive(true);
        ok_btn.gameObject.SetActive(false);
        _Myobj = _obj;
        _Myobj.SetActive(false);

        messsage_text.text = meg;
        //ok_text.text = btn_msg;


        confirm_text.text = confirm_msg;
        cancel_text.text = cancel_msg;
    }


    public void confirm_event()
    {
        _Myobj.SetActive(true);
        obj.SetActive(false);


        
    }

    public void cancel_event()
    {
        _Myobj.SetActive(true);
        obj.SetActive(false);

    }

    public void MessageEvent_3(string meg)
    {
        obj.SetActive(true);
        confirm_btn.gameObject.SetActive(false);
        cancel_btn.gameObject.SetActive(false);
        ok_btn.gameObject.SetActive(false);
        messsage_text.text = meg;
    }

    
}

