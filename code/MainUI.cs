using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainUI : MonoBehaviour
{
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void MapEvent()
    {
        obj_list_clone.Instance.OpenMapUI();
        Destroy(this.gameObject);
    }

    public void SkillEvent()
    {
        call_server_clone.Instance.get_skill_data();
        Destroy(this.gameObject);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
