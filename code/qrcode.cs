using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using UnityEngine.UI;
using System;

public class qrcode : MonoBehaviour
{
    public RawImage cameraTexture;
    public Text btn_text;
    public GameObject Btn;
    public Text txtQRcode;
    public Text MyText;
    public GameObject my_text_list_obj;
    //public Text MyMsg;


    //public Text txtQRcode; 
    //public GameObject Btn;
    private WebCamTexture webCameraTexture;
    private BarcodeReader barcodeReader;

    string msg = "";
    int valueID = 0;

    List<GameObject> text_list = new List<GameObject>();

    void Start()
    {
        MyText.gameObject.SetActive(false);
        my_text_list_obj.SetActive(false);
        Scan_Event();
        
    }

    private void Update()
    {
        
    }

    public void Scan_Event()
    {
        StopAllCoroutines();
        StartCoroutine(Scan());
        msg = "";
    }


    public void Send_msg()
    {
        msg_send();
        StopAllCoroutines();
        call_server_clone.Instance.send_skill_answer(msg);
        msg = "";
        OnDestroyAllObj();


    }

    private IEnumerator Scan()
    {
        Btn.SetActive(false);
        barcodeReader = new BarcodeReader();
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        try
        {
            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                
                WebCamDevice[] devices = WebCamTexture.devices;
                
                string devicename = devices[0].name;
                
                webCameraTexture = new WebCamTexture(devicename, 800, 600);
                
                cameraTexture.texture = webCameraTexture;
                
                webCameraTexture.Play();
                
                InvokeRepeating("DecodeQR", 0, 0.3f); // 0.5 秒掃描一次
                
            }
            else
            {
                
                Application.Quit();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    private void DecodeQR()
    {
        var br = barcodeReader.Decode(webCameraTexture.GetPixels32(), webCameraTexture.width, webCameraTexture.height);
        if (br != null)
        {
            Btn.SetActive(true);
            btn_text.text = br.Text;
            //webCameraTexture.Stop();
        }
        else
        {
            Btn.SetActive(false);
        }
    }

    public void onClickInputEvent(Text text)
    {

        string value = text.text;
        if (value.Length > 2)
        {
            MyText.gameObject.SetActive(true);
            my_text_list_obj.SetActive(false);
            //txtQRcode.gameObject.SetActive(true);
            MyText.text = text.text;
            msg = text.text;
            //txtQRcode.gameObject.SetActive(false);
            
            return;
        }
        else
        {

            MyText.gameObject.SetActive(false);
            my_text_list_obj.SetActive(true);
            txtQRcode.gameObject.SetActive(true);
            GameObject obj = Instantiate(txtQRcode).gameObject;
            obj.transform.parent = txtQRcode.transform.parent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            obj.name = "text_" + valueID;
            obj.GetComponent<Text>().text = text.text;
            text_list.Add(obj);
            valueID++;

            //msg = msg + btn_text.text;

            //MyMsg.text = msg;
            //txtQRcode.text = msg;
            msg = msg + text.text;
            txtQRcode.gameObject.SetActive(false);
            
            return;
        }
        
    }

    public void OnDestroyObj(GameObject obj)
    {

        //OnDestroyAllObj();
        msg_show(obj);
        Destroy(obj);
    }

    public void OnClearObj(GameObject obj)
    {
        MyText.text = "";
        msg = "";
    }

    void msg_show(GameObject obj)
    {
        for (int i = 0; i < text_list.Count; i++)
        {
            if (obj.name == text_list[i].name)
            {
                text_list.RemoveAt(i);
            }

        }
        msg_send();
    }

    void msg_send()
    {
        if (msg.Length > 2 && text_list.Count == 0)
        {
            return;
        }
        else
        {

            msg = "";
            for (int i = 0; i < text_list.Count; i++)
            {
                msg = msg + text_list[i].GetComponent<Text>().text;
            }
            //MyMsg.text = msg;
        }
    }


    void OnDestroyAllObj()
    {
        for (int i = 0; i < text_list.Count; i++)
        {
            if (text_list[i] != null)
            {
                Destroy(text_list[i]);
            }
        }

        valueID = 0;
        text_list.Clear();
    }





}
