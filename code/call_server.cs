using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;


public class call_server : MonoBehaviour
{
    //string url = "http://192.168.0.107/Teaching/";
    string url = "https://aitlab.tru.io:20443/Teaching/";
    //string url = "http://aitlab.tru.io:20480/Teaching/";
    string topic1_student_data = "topic1_student_data.php";
    string topic1_student_update_skill = "topic1_student_update_skill_iOS.php";
    string topic1_read_txt = "read_txt.php";
    string topic1_send_question = "topic1_send_question.php";
    string topic1_answer_the_question = "topic1_answer_the_question.php";
    string topic1_student_skill_data = "topic1_student_skill_data.php";
    string topic1_send_token_end = "topic1_send_token_end.php";
    string topic1_send_skill_answer = "topic1_get_msg.php";
    string topic1_sned_skill_count = "topic1_skill_data_count.php";


    int count;

    int start_value = 0;
    int end_value = 0;
    topic_list_table1 topic1_data1;
    topic_list_table2 topic1_data2;
    topic_list_table3 topic1_data3;
    List<skill_table> DataList = new List<skill_table>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region 登入執行
    public void GetToken(string studendID, string name)
    {
        StartCoroutine(get_load_token(studendID,name));
    }



    IEnumerator get_load_token(string studendID, string name)
    {
        string url_path = string.Format("{0}{1}", url, topic1_student_data);
        DateTime MyDate = System.DateTime.Now;
        string myTime = MyDate.ToString("yyyy-MM-dd HH:mm:ss");
        WWWForm student_data = new WWWForm();
        student_data.AddField("studentID", studendID);
        student_data.AddField("name", name);
        student_data.AddField("time", myTime);
        UnityWebRequest get_data = UnityWebRequest.Post(url_path, student_data);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            Debug.Log(get_data.error);
        }
        else
        {
            string json = get_data.downloadHandler.text;
            personal_data.Instance.Token = json;

            login.Instance.CloseUI();

        }
    }

    #endregion



    #region 拍照上傳化學元素
    [System.Serializable]
    public class topic_list_table1
    {
        public topic1_physical_table values;
    }

    [System.Serializable]
    public class topic1_physical_table
    {

        public string ID;
        public string topic;
        public string Chemical_formula;
        public string Commentary;
        public string Source;

    }


    public void upload_skill_answer(string answer)
    {
        StartCoroutine(upload_student_skill_answer(answer));
    }

    IEnumerator upload_student_skill_answer(string answer)
    {
        WWWForm form = new WWWForm();
        form.AddField("answer", answer);
        string url_path = string.Format("{0}{1}", url, topic1_send_skill_answer);

        UnityWebRequest get_data = UnityWebRequest.Post(url_path, form);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            //Debug.Log("test:" + get_data.error);
        }
        else
        {
            string json_str = get_data.downloadHandler.text;
            if (json_str == "Error:1fail" || json_str == "Error:1{\"values\":null}" || json_str == "fail" || json_str == "{\"values\":null}")
            {
                Fight.Instance.skill_data = null;
                // Debug.Log("test1_1");
                Fight.Instance.show_read_pic_fail();
                // Debug.Log("test1_2");

            }
            else
            {
                //  Debug.Log("test3");
                topic_list_table1 topic_list_table1 = JsonUtility.FromJson<topic_list_table1>(json_str);
                topic1_data1 = topic_list_table1;
                topic1_data_table data = new topic1_data_table();
                data.ID = topic1_data1.values.ID;
                data.topic = topic1_data1.values.topic;
                data.Chemical_formula = topic1_data1.values.Chemical_formula;
                data.Commentary = topic1_data1.values.Commentary;
                data.Source = topic1_data1.values.Source;
                Fight.Instance.skill_data = data;
                Fight.Instance.show_read_pic_message();
            }

        }
    }

    public void update_skill(WebCamTexture backCam)
    {
        StartCoroutine(update_skill_pic(backCam));
    }

    public byte[] file_stream(string fileName)
    {
        FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        byte[] bytes = new byte[fileStream.Length];
        fileStream.Read(bytes, 0, bytes.Length);
        fileStream.Close();
        return bytes;
        //Stream stream = new MemoryStream(bytes);
        //return stream;
    }

    IEnumerator update_skill_pic(WebCamTexture backCam)
    {
        
        Texture2D t2d = new Texture2D(backCam.width, backCam.height, TextureFormat.ARGB32, true);

        t2d.SetPixels(backCam.GetPixels());
        t2d.Apply();

        byte[] bytes = t2d.EncodeToPNG();
        //string path = Application.persistentDataPath + "/img.png";
        //File.WriteAllBytes(path, bytes);
       // byte[] img = file_stream(path);
        
        WWWForm form = new WWWForm();
        form.AddField("ID",personal_data.Instance.studentID);
        form.AddBinaryData("READ_PIC", bytes, "image.png", "image/png");
        string url_path = string.Format("{0}{1}", url, topic1_student_update_skill);

        //UnityWebRequest get_data = UnityWebRequest.Put(url_path, bytes);
        UnityWebRequest get_data = UnityWebRequest.Post(url_path, form);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            //Debug.Log("test:" + get_data.error);
        }
        else
        { 
            //Debug.Log("test:" + get_data.downloadHandler.text);
            StartCoroutine(PostData(get_data.downloadHandler.text));
            Destroy(t2d);
        }   
        
        


    }

    IEnumerator PostData(string path)
    {

        
        string url_path = string.Format("{0}{1}", url, topic1_read_txt);
        Debug.Log("test:" + url_path);
        WWWForm student_data = new WWWForm();
        student_data.AddField("path", path);
        UnityWebRequest get_data = UnityWebRequest.Post(url_path, student_data);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            //Debug.Log(get_data.error);
        }
        else
        {
            try
            {
                string json_str = get_data.downloadHandler.text;
                if (json_str == "Error:1fail" || json_str == "Error:1{\"values\":null}" || json_str == "fail" || json_str == "{\"values\":null}")
                {
                    Fight.Instance.skill_data = null;
                   // Debug.Log("test1_1");
                    Fight.Instance.show_read_pic_fail();
                   // Debug.Log("test1_2");

                }
                else
                {
                  //  Debug.Log("test3");
                    topic_list_table1 topic_list_table1 = JsonUtility.FromJson<topic_list_table1>(json_str);
                    topic1_data1 = topic_list_table1;
                    topic1_data_table data = new topic1_data_table();
                    data.ID = topic1_data1.values.ID;
                    data.topic = topic1_data1.values.topic;
                    data.Chemical_formula = topic1_data1.values.Chemical_formula;
                    data.Commentary = topic1_data1.values.Commentary;
                    data.Source = topic1_data1.values.Source;
                    Fight.Instance.skill_data = data;
                    Fight.Instance.show_read_pic_message();
                }


            }
            catch (Exception e)
            {
                Debug.LogError("pic_message:" + e.ToString());
                Fight.Instance.skill_data = null;
                Fight.Instance.show_read_pic_fail();
             //   Debug.Log("test2");
            }

        }
        
        
           

    }




    #endregion


    #region 給考題
    [System.Serializable]
    public class topic_list_table2
    {
        public topic1_physical_question values;
    }

    [System.Serializable]
    public class topic1_physical_question
    {

        public string ID;
        public string topic;
        public string Chemical_formula;
        public string QuestionID;
        public string Question;
        public string Answer1;
        public string Answer2;
        public string Answer3;
        public string Answer4;
        public string attack;

    }


    public void send_question(string ID)
    {
        StartCoroutine(Send_Question(ID));
    }

    IEnumerator Send_Question(string ID)
    {
        string url_path = string.Format("{0}{1}", url, topic1_send_question);
        //Debug.Log(url_path);
        WWWForm student_data = new WWWForm();
        student_data.AddField("ID", ID);
        UnityWebRequest get_data = UnityWebRequest.Post(url_path, student_data);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            Debug.Log(get_data.error);
        }
        else
        {
            string json = get_data.downloadHandler.text;
            topic1_data2 = JsonUtility.FromJson<topic_list_table2>(json);
            topic1_data_table1 data = new topic1_data_table1();
            data.ID = topic1_data2.values.ID;
            data.topic = topic1_data2.values.topic;
            data.Chemical_formula = topic1_data2.values.Chemical_formula;
            data.QuestionID = topic1_data2.values.QuestionID;
            data.Question = topic1_data2.values.Question;
            data.Answer1 = topic1_data2.values.Answer1;
            data.Answer2 = topic1_data2.values.Answer2;
            data.Answer3 = topic1_data2.values.Answer3;
            data.Answer4 = topic1_data2.values.Answer4;
            data.attack = topic1_data2.values.attack;
            Fight.Instance.topic1_data_table1 = data;
            Fight.Instance.FightEvent_GetQuestion();

            //Debug.Log(json);
            //personal_data.Instance.Token = json;

            //考題欄位未寫

        }
    }

    

    #endregion


    #region 回傳學生答案

    public void answer_the_question(string token, string ID,string Answer)
    {
        StartCoroutine(Answer_The_Question(token, ID, Answer));
    }

    IEnumerator Answer_The_Question(string token, string ID, string Answer)
    {
        string url_path = string.Format("{0}{1}", url, topic1_answer_the_question);
        WWWForm student_data = new WWWForm();
        student_data.AddField("token", token);
        student_data.AddField("ID", ID);
        student_data.AddField("Answer", Answer);
        UnityWebRequest get_data = UnityWebRequest.Post(url_path, student_data);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            Debug.Log(get_data.error);
        }
        else
        {
            string json = get_data.downloadHandler.text;
            //personal_data.Instance.Token = json;

            if (json == "success")
            {
                Fight.Instance.changeCubeHP();
            }
            else
            {
                Fight.Instance.changePlayerHP();
            }
            //success

            

        }

    }

    #endregion


    #region 取得技能

    [System.Serializable]
    public class topic_list_table3
    {
        public List<topic1_physical_skill> values;
    }

    [System.Serializable]
    public class topic1_physical_skill
    {

        public string ID;
        public string topic;
        public string Chemical_formula;
        public string Description;
        public string source;
        public string HasValue;

    }

    public void get_skill_data(string token)
    {
        Debug.Log(token);
        StartCoroutine(skill_count(token));

        
        //StartCoroutine(skill_data(token,1));
        //StartCoroutine(skill_data(token,2));

    }

    IEnumerator skill_count(string token)
    {

        string url_path = string.Format("{0}{1}", url, topic1_sned_skill_count);
        UnityWebRequest get_data = UnityWebRequest.Get(url_path);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            Debug.Log(get_data.error);
        }
        else
        {
            string json = get_data.downloadHandler.text;
            count = int.Parse(json);

            start_value = 0;
            end_value = 0;

            int count_value = count % 20;
            int count1 = (count / 20);
            if (count_value > 0)
            {
                count1 = count1 + 1;
            }

            get_skill(count1,token);


        }
    }


    void get_skill(int count1,string token)
    {
        for (int i = 0; i < count1; i++)
        {
            start_value = 20 * i;
            end_value = 20 * (i + 1);
            if (count < end_value)
            {
                end_value = count;
            }
            StartCoroutine(skill_data(token, start_value, end_value));

        }
    }

    IEnumerator skill_data(string token,int start_value,int end_value)
    {
       
        
        string url_path = string.Format("{0}{1}", url, topic1_student_skill_data);
        WWWForm student_data = new WWWForm();
        student_data.AddField("token", token);
        student_data.AddField("start_value", start_value);
        student_data.AddField("end_value", end_value);
        UnityWebRequest get_data = UnityWebRequest.Post(url_path, student_data);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            Debug.Log(get_data.error);
        }
        else
        { 
            string json =  get_data.downloadHandler.text;
//            Debug.Log(json);
            topic1_data3 = JsonUtility.FromJson<topic_list_table3>(json);
            
            for (int i = 0; i < topic1_data3.values.Count; i++)
            {
                skill_table data = new skill_table();
                data.ID = topic1_data3.values[i].ID;
                data.topic = topic1_data3.values[i].topic;
                data.Chemical_formula = topic1_data3.values[i].Chemical_formula;
                data.Description = topic1_data3.values[i].Description;
                data.source = topic1_data3.values[i].source;
                data.HasValue = topic1_data3.values[i].HasValue;
                DataList.Add(data);
            }


            if (count == end_value)
            {
                obj_list_clone.Instance.OpenSkillInfoUI();


                yield return new WaitForSeconds(0.01f);

                skill.Instance.GetData(DataList);
            }

            //obj_list_clone.Instance.OpenSkillInfoUI();

            //personal_data.Instance.Token = json;

            //取得技能欄位未寫

        }

        

            
    }

    #endregion

    

    #region 結束token


    public void send_token_end(string token)
    {
        StartCoroutine(Send_Token(token));
    }

    IEnumerator Send_Token(string token)
    {
        string url_path = string.Format("{0}{1}", url, topic1_send_token_end);
        WWWForm student_data = new WWWForm();
        student_data.AddField("token", token);
        UnityWebRequest get_data = UnityWebRequest.Post(url_path, student_data);
        yield return get_data.SendWebRequest();
        if (get_data.isNetworkError || get_data.isHttpError)
        {
            Debug.Log(get_data.error);
        }
        else
        {
            string json = get_data.downloadHandler.text;
            

        }
    }

    #endregion


    private void OnApplicationQuit()
    {
        string token = personal_data.Instance.Token;
        if (token == string.Empty)
            return;
        send_token_end(token);
    }
}
