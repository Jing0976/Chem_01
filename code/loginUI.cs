using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class loginUI : MonoBehaviour
{
    private Text ID, name;
    string ID_str, name_str;

    
    void Start()
    {
        ID = this.transform.Find("Canvas/frame/ID/InputField/Text").GetComponent<Text>();
        name = this.transform.Find("Canvas/frame/name/InputField/Text").GetComponent<Text>();
        personal_data.Instance.MyUIState = personal_data.UI_state.LoginUI;

        Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            string devicename = devices[0].name;

        }
        else
        {
            //Application.Quit();
        }
    }
    void Update()
    {
        
    }



    public void LoginEvent() {

        ID_str = ID.text;

        name_str = name.text;

        if (ID_str == string.Empty)
        {

            message.Instance.message_1(message_str.login_id_null, message_str.confirm_btn, this.gameObject);
            return;
        }

        if (name_str == string.Empty)
        {
            message.Instance.message_1(message_str.login_name_null, message_str.confirm_btn, this.gameObject);
            return;
        }

        personal_data.Instance.studentID = ID_str;
        personal_data.Instance.name = name_str;
        call_server_clone.Instance.LoginSend(ID_str, name_str);
    }

    public void CloseUI()
    {

        Destroy(this.gameObject);
    }
}
