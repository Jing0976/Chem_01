using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takePhoto : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private WebCamTexture frontCam;
    private Texture defaultBackground;
    string devicNmae;
    public RawImage background;
    public AspectRatioFitter fit;

 

    private void Start()
    {
        defaultBackground = background.texture;
        StartCoroutine(startCam());
    }

    public IEnumerator startCam()
    {
        int maxl = Screen.width;
        if (Screen.height > Screen.width) { maxl = Screen.height; }
//        Debug.Log("TEST:maxl:" + maxl.ToString());
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            devicNmae = devices[0].name;
            backCam = new WebCamTexture(devicNmae, maxl, maxl, 12);
            backCam.wrapMode = TextureWrapMode.Repeat;
            background.texture = backCam;
            backCam.Play();

        }

    }



    private void Update()
    {
      
    }



    public void SaveImage()
    {
        message.Instance.message_3(message_str.read_pic);
        call_server_clone.Instance.UpdateSkill(backCam);
    }
    
   



}
