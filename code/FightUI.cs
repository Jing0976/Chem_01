using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FightUI : MonoBehaviour
{
    GameObject fight_btn_obj, Question_ui_obj, BG, fight_btn;
    Text QuestionText, textA, textB, textC, textD, monster_hp, player_hp;
    monster_table data;
    qrcode takePhoto;
    GameObject photoUI_obj;

    GameObject Player_fight, monster_fight;

    GameObject Cube, Player;
    int player_ph_value = 100;
    int Cube_ph_value;



    void Start()
    {
        fight_btn_obj = this.transform.Find("Canvas/objUI/fight_btn").gameObject;
        Question_ui_obj = this.transform.Find("Canvas/objUI/Question_ui").gameObject;
        photoUI_obj = this.transform.Find("Canvas/photoUI").gameObject;
        BG = this.transform.Find("Canvas/objUI/BG").gameObject;
        fight_btn = this.transform.Find("Canvas/objUI/fight_btn").gameObject;

        Cube = this.transform.Find("Cube").gameObject;
        Player = this.transform.Find("Player").gameObject;

        QuestionText = this.transform.Find("Canvas/objUI/Question_ui/Question_value").GetComponent<Text>();
        textA = this.transform.Find("Canvas/objUI/Question_ui/item_list/A/Text").GetComponent<Text>();
        textB = this.transform.Find("Canvas/objUI/Question_ui/item_list/B/Text").GetComponent<Text>();
        textC = this.transform.Find("Canvas/objUI/Question_ui/item_list/C/Text").GetComponent<Text>();
        textD = this.transform.Find("Canvas/objUI/Question_ui/item_list/D/Text").GetComponent<Text>();

        monster_hp = this.transform.Find("Canvas/objUI/BG/monster_hp/Text").GetComponent<Text>();
        player_hp = this.transform.Find("Canvas/objUI/BG/player_hp/Text").GetComponent<Text>();

        takePhoto = this.transform.Find("Camera").GetComponent<qrcode>();

        Player_fight = this.transform.Find("Player/fight_p").gameObject;
        monster_fight = this.transform.Find("Cube/fight_p").gameObject;

        
        



        fight_btn_obj.SetActive(true);
        BG.SetActive(true);
        Question_ui_obj.SetActive(false);
        photoUI_obj.SetActive(false);
        takePhoto.enabled = false;
        Player_fight.SetActive(false);
        monster_fight.SetActive(false);


    }

    public void start_show()
    {
        fight_btn_obj.SetActive(true);
        BG.SetActive(true);
        Question_ui_obj.SetActive(false);
        photoUI_obj.SetActive(false);
        takePhoto.enabled = false;
    }

    public void GetMonsterData(monster_table _data)
    {
        data = _data;
        ShowHP();
    }


    void ShowHP()
    {
        Start();
        obj_list_clone.Instance.create_monster(data.ID, Cube);
        Cube_ph_value = data.HP;
        monster_hp.text = string.Format("HP:{0}", Cube_ph_value.ToString());
        player_hp.text = string.Format("HP:{0}", player_ph_value);
    }

    void Update()
    {

    }

    public void FightEvent()
    {
        takePhoto.enabled = true;
        photoUI_obj.SetActive(true);
        Cube.SetActive(false);
        Player.SetActive(false);
        BG.SetActive(false);
        fight_btn.SetActive(false);

    }

    public void FightEvent_GetQuestion ()
    {
        photoUI_obj.SetActive(false);
        Cube.SetActive(true);
        Player.SetActive(true);
        BG.SetActive(true);
        Question_ui_obj.SetActive(true);

        QuestionText.text = Fight.Instance.topic1_data_table1.Question;
        textA.text = Fight.Instance.topic1_data_table1.Answer1;
        textB.text = Fight.Instance.topic1_data_table1.Answer2;
        textC.text = Fight.Instance.topic1_data_table1.Answer3;
        textD.text = Fight.Instance.topic1_data_table1.Answer4;
    }


    public void AnswerA_Event()
    {
        string answer = textA.text;
        call_server_clone.Instance.answer_the_question(answer);

    }

    public void AnswerB_Event()
    {
        string answer = textB.text;
        call_server_clone.Instance.answer_the_question(answer);
    }

    public void AnswerC_Event()
    {
        string answer = textC.text;
        call_server_clone.Instance.answer_the_question(answer);
    }

    public void AnswerD_Event()
    {
        string answer = textD.text;
        call_server_clone.Instance.answer_the_question(answer);
    }

    //Lose
    public void changePlayerHP()
    {
        player_ph_value = player_ph_value - int.Parse(Fight.Instance.topic1_data_table1.attack);
        player_hp.text = string.Format("HP:{0}", player_ph_value.ToString());

        StartCoroutine(monster_fight_event());
        StopCoroutine(monster_fight_event());
        if (player_ph_value <= 0)
        {
            obj_list_clone.Instance.OpenResultUI();
            Result.Instance.Show_Lose();
            Destroy(this.gameObject);
            return;
        }

        start_show();
    }

    IEnumerator monster_fight_event()
    {
        Player_fight.SetActive(true);
        yield return new WaitForSeconds(5f);
        Player_fight.SetActive(false);
    }

    //Win
    public void changeCubeHP()
    {
        Cube_ph_value = Cube_ph_value - int.Parse(Fight.Instance.topic1_data_table1.ID);
        monster_hp.text = string.Format("HP:{0}", Cube_ph_value.ToString());
        StartCoroutine(player_fight_event());
        StopCoroutine(player_fight_event());
        if (Cube_ph_value <= 0)
        {
            obj_list_clone.Instance.OpenResultUI();
            Result.Instance.Show_Win();
            Destroy(this.gameObject);
            return;
        }
        
        start_show();
    }

    IEnumerator player_fight_event()
    {
        monster_fight.SetActive(true);
        yield return new WaitForSeconds(2f);
        monster_fight.SetActive(false);
    }

}
