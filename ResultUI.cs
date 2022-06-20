using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    GameObject Win_obj, Lose_obj;

    // Start is called before the first frame update
    void Start()
    {
        Win_obj = this.transform.Find("Canvas/win").gameObject;
        Lose_obj = this.transform.Find("Canvas/lose").gameObject;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Show_Win()
    {
        StartCoroutine(show_win());
    }

    IEnumerator show_win()
    {
        Start();
        Win_obj.SetActive(true);
        Lose_obj.SetActive(false);
        string studentID = personal_data.Instance.studentID;
        int step = PlayerPrefs.GetInt(studentID) + 1;
        PlayerPrefs.SetInt(studentID, step);
        personal_data.Instance.step = step;
        yield return new WaitForSeconds(3f);
        obj_list_clone.Instance.OpenMapUI();
        Destroy(this.gameObject);
    }

    public void Show_Lose()
    {
        StartCoroutine(show_lose());
    }

    IEnumerator show_lose()
    {
        Start();
        Win_obj.SetActive(false);
        Lose_obj.SetActive(true);
        yield return new WaitForSeconds(3f);
        obj_list_clone.Instance.OpenMapUI();
        Destroy(this.gameObject);
    }

}
