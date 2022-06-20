using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillUI : MonoBehaviour
{

    List<skill_table> DataList;
    public Sprite green_btn;
    public Sprite red_btn;
    List<skill_button_table> ButtonList;
    void Start()
    {
        
    }

    public void GetData(List<skill_table> datalist)
    {
        DataList = datalist;
        Create_Button();
    }

    public void Create_Button()
    {
        ButtonList = new List<skill_button_table>();
        GameObject btn_obj = this.transform.Find("Canvas/Scroll View/Viewport/Content/Button").gameObject;
        for (int i = 0; i < DataList.Count; i++)
        {
            skill_button_table data = new skill_button_table();
            data.ID = i;
            data.data = DataList[i];
            
            data.obj = Instantiate(btn_obj).gameObject;
            data.obj.name = string.Format("btn_{0}", i);
            data.obj.transform.parent = btn_obj.transform.parent;
            data.obj.transform.localPosition = Vector3.zero;
            data.obj.transform.localScale = Vector3.one;
            data.btn = data.obj.GetComponent<Button>();
            data.btn_text = data.obj.transform.Find("Text").GetComponent<Text>();
            data.btn_text.text = string.Format("{0} {1}", data.data.topic, data.data.Chemical_formula);
            data.btn_img = data.obj.GetComponent<Image>();



            if (data.data.HasValue == "1")
            {
                data.HasValue = true;
                data.btn_img.sprite = green_btn;
            }
            else
            {
                data.HasValue = false;
                data.btn_img.sprite = red_btn;
            }

            data.btn.onClick.AddListener(delegate {

                data.OnClick();
	        });
            ButtonList.Add(data);
        }

        btn_obj.SetActive(false);

        ButtonList[0].OnClick();



    }


    public void BackToMainUI()
    {
        obj_list_clone.Instance.OpenMainUI();
        Destroy(this.gameObject);
    }

    
}
