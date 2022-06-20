using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill_button_table
{
    public int ID;
    public GameObject obj;
    public Button btn;
    public Text btn_text;
    public Image btn_img;
    public bool HasValue;
    public skill_table data;
    
    

    public void OnClick()
    {
        GameObject obj = GameObject.Find("Canvas/frame/Scroll View/Viewport/Content/Text").gameObject;
        Text text = obj.GetComponent<Text>();
        
        if (HasValue)
        {
            string value1 = string.Format("{0} {1} \n{2}{3}", data.topic, data.Chemical_formula, data.Description, data.source);
            text.text = value1;
        }
        else
        {
            text.text = message_str.skill_msg;
        }
    }
}
