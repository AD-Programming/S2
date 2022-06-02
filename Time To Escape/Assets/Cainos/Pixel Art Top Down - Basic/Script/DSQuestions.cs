using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Question
{
    public string Title;
    public string Answer_1;
    public string Answer_2;
    public string Answer_3;
    public string Answer_4;
    public string  correct;
    
}

public class DSQuestions : MonoBehaviour
{
    //  [SerializeField]
    public List<Question> lstQuestions = new List<Question>();
    public Text txtQuestion;
    public Text txtTime;
    public Button AnswerButtonA;
    public Button AnswerButtonB;
    public Button AnswerButtonC;
    public Button AnswerButtonD;
    public GameObject diamond;
    public GameObject door;
    public GameObject Grid;
    public GameObject lost_panel;
    public GameObject knight;
    float bienTG = 0;
    float bienTG2 = 0;
    public int countdown = 3600;

    public int CurrentQuestion = -1;
    bool stop = false;
    // Start is called before the first frame update
    void Start()
    {

        //if(lstQuestions.Count!=0)
        //{
        //    txtQuestion.text = lstQuestions[CurrentQuestion].Title;
        //    AnswerButtonA.transform.GetChild(0).GetComponent<Text>().text = lstQuestions[CurrentQuestion].Answer_1;
        //    AnswerButtonB.transform.GetChild(0).GetComponent<Text>().text = lstQuestions[CurrentQuestion].Answer_2;
        //    AnswerButtonC.transform.GetChild(0).GetComponent<Text>().text = lstQuestions[CurrentQuestion].Answer_3;
        //    AnswerButtonD.transform.GetChild(0).GetComponent<Text>().text = lstQuestions[CurrentQuestion].Answer_4;
        //}

        AnswerButtonA.onClick.AddListener(delegate {
            if (AnswerButtonA.transform.GetChild(0).GetComponent<Text>().text == lstQuestions[CurrentQuestion].correct)
            {
                gameObject.SetActive(false);
                Grid.SetActive(true);
                diamond.SetActive(true);
                door.SetActive(true);
                AudioController.Ins.PlayRightSound();
            }
            else
            {
                txtQuestion.text = lstQuestions[CurrentQuestion].correct;
                bienTG2 = Time.time + 1f;
                stop = true;

            }
        });
        AnswerButtonB.onClick.AddListener(delegate {
            if (AnswerButtonB.transform.GetChild(0).GetComponent<Text>().text == lstQuestions[CurrentQuestion].correct)
            {
                gameObject.SetActive(false);
                Grid.SetActive(true);
                diamond.SetActive(true);
                door.SetActive(true);
                AudioController.Ins.PlayRightSound();
            }
            else
            {
                txtQuestion.text = lstQuestions[CurrentQuestion].correct;
                bienTG2 = Time.time + 1f;
                stop = true;


            }
        });
        AnswerButtonC.onClick.AddListener(delegate {
            if (AnswerButtonC.transform.GetChild(0).GetComponent<Text>().text == lstQuestions[CurrentQuestion].correct)
            {
                gameObject.SetActive(false);
                Grid.SetActive(true);
                diamond.SetActive(true);
                door.SetActive(true);
                AudioController.Ins.PlayRightSound();
            }
            else
            {
                txtQuestion.text = lstQuestions[CurrentQuestion].correct;
                bienTG2 = Time.time + 1f;
                stop = true;


            }
        });
        AnswerButtonD.onClick.AddListener(delegate {
            if (AnswerButtonD.transform.GetChild(0).GetComponent<Text>().text == lstQuestions[CurrentQuestion].correct)
            {
                //if (CurrentQuestion < 9)
                //{
                gameObject.SetActive(false);
                Grid.SetActive(true);
                diamond.SetActive(true);
                door.SetActive(true);
                AudioController.Ins.PlayRightSound();
                //}
                //else if(CurrentQuestion==9)
                //{
                //    //thuc hien j do
                //}

            }
            else
            {
                txtQuestion.text = lstQuestions[CurrentQuestion].correct;
                bienTG2 = Time.time + 1f;
                stop = true;


            }
        });



    }
    private void OnEnable()
    {

        CurrentQuestion++;
        //Debug.Log("Cau hoi tiep theo:" + CurrentQuestion);
        if (CurrentQuestion < lstQuestions.Count)
        {
            txtQuestion.text = lstQuestions[CurrentQuestion].Title;
            AnswerButtonA.transform.GetChild(0).GetComponent<Text>().text = lstQuestions[CurrentQuestion].Answer_1;
            AnswerButtonB.transform.GetChild(0).GetComponent<Text>().text = lstQuestions[CurrentQuestion].Answer_2;
            AnswerButtonC.transform.GetChild(0).GetComponent<Text>().text = lstQuestions[CurrentQuestion].Answer_3;
            AnswerButtonD.transform.GetChild(0).GetComponent<Text>().text = lstQuestions[CurrentQuestion].Answer_4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > bienTG)
        {
            gameObject.transform.GetChild(4).GetComponent<Text>().text = countdown.ToString();
            countdown = countdown - 1;
            bienTG = Time.time + 1.0f;
        }

        if ((stop) || (countdown == 0)) 
        {
            if (Time.time > bienTG2)
            {
                AudioController.Ins.PlayLoseSound();
                gameObject.SetActive(false);
                Grid.SetActive(false);
                diamond.SetActive(false);
                door.SetActive(false);
                knight.SetActive(false);
                lost_panel.SetActive(true);
                stop = false;
                AudioController.Ins.StopMusic();
            }
        }


    }
}
