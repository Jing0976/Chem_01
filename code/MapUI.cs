using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    int step = 0;
    int Count = 10;
    GameObject[] obj_btn;

    // Start is called before the first frame update
    void Start()
    {
        monster_data.Instance.CreateData();

        string studentID = personal_data.Instance.studentID;
        step = PlayerPrefs.GetInt(studentID);
//        Debug.Log(step);
        if (step == 0) {
            PlayerPrefs.SetInt(studentID, 1);
        }

        step = PlayerPrefs.GetInt(studentID);

        obj_btn = new GameObject[Count];
        for (int i = 0; i < Count; i++)
        {
            string path = string.Format("Canvas/play{0}",i+1);
            obj_btn[i] = this.transform.Find(path).gameObject;

            if (i == step-1)
            {
                obj_btn[i].SetActive(true);
            }
            else
            {
                obj_btn[i].SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void step_go_FightUI()
    {
        obj_list_clone.Instance.OpenFightUI();
        Destroy(this.gameObject);
    }

    public void CloseUI()
    {
        obj_list_clone.Instance.OpenMainUI();
        Destroy(this.gameObject);

    }

    private void OnApplicationQuit()
    {
        personal_data.Instance.step = step;
        string studentID = personal_data.Instance.studentID;
        PlayerPrefs.SetInt(studentID, personal_data.Instance.step);
    }
}
