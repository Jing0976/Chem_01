using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
//using TMPro;


public class obj_list : MonoBehaviour
{
    public GameObject[] ObjList;
    public GameObject[] monster;



    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(ObjList[0]).gameObject;
        obj.name = "LoginUI";
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;

        GameObject obj_1 = Instantiate(ObjList[7]).gameObject;
        obj_1.name = "Call_Server";
        obj_1.transform.localPosition = Vector3.zero;
        obj_1.transform.localScale = Vector3.one;

        GameObject obj_3 = Instantiate(ObjList[6]).gameObject;
        obj_3.name = "MessageUI";
        obj_3.transform.localPosition = Vector3.zero;
        obj_3.transform.localScale = Vector3.one;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    #region Event
    public void MainUI_Event()
    {
        if (personal_data.Instance.MyUIState == personal_data.UI_state.MainUI)
            return;
        GameObject obj_2 = Instantiate(ObjList[1]).gameObject;
        obj_2.name = "MainUI";
        obj_2.transform.localPosition = Vector3.zero;
        obj_2.transform.localScale = Vector3.one;

        personal_data.Instance.MyUIState = personal_data.UI_state.MainUI;

    }


    public void MapUI_Event()
    {
        if (personal_data.Instance.MyUIState == personal_data.UI_state.MapUI)
            return;
        GameObject obj_4 = Instantiate(ObjList[2]).gameObject;
        obj_4.name = "MapUI";
        obj_4.transform.localPosition = Vector3.zero;
        obj_4.transform.localScale = Vector3.one;
        personal_data.Instance.MyUIState = personal_data.UI_state.MapUI;
    }


    public void FightUI()
    {
        if (personal_data.Instance.MyUIState == personal_data.UI_state.FightUI)
            return;
        GameObject obj_5 = Instantiate(ObjList[4]).gameObject;
        obj_5.name = "FightUI";
        obj_5.transform.localPosition = Vector3.zero;
        obj_5.transform.localScale = Vector3.one;
        personal_data.Instance.MyUIState = personal_data.UI_state.FightUI;
    }


    public void ResultUI()
    {
        if (personal_data.Instance.MyUIState == personal_data.UI_state.ResultUI)
            return;
        GameObject obj_6 = Instantiate(ObjList[5]).gameObject;
        obj_6.name = "ResultUI";
        obj_6.transform.localPosition = Vector3.zero;
        obj_6.transform.localScale = Vector3.one;
        personal_data.Instance.MyUIState = personal_data.UI_state.ResultUI;
    }

    public void skillUI()
    {
        if (personal_data.Instance.MyUIState == personal_data.UI_state.SkillInfoUI)
            return;
        GameObject obj_8 = Instantiate(ObjList[3]).gameObject;
        obj_8.name = "SkillInfoUI";
        obj_8.transform.localPosition = Vector3.zero;
        obj_8.transform.localScale = Vector3.one;
        personal_data.Instance.MyUIState = personal_data.UI_state.SkillInfoUI;

        
    }

    #endregion


    public void step_monster(int i,GameObject obj)
    {
        GameObject obj_7 = Instantiate(monster[i]).gameObject;
        obj_7.name = "monster";
        obj_7.transform.parent = obj.transform;
        obj_7.transform.localPosition = Vector3.zero;
        obj_7.transform.localScale = Vector3.one;
    }
}
