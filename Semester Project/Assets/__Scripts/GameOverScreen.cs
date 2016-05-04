using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public int score;
    public Text scoretext;
    public string[] Alphabets;
    public int[] selectedNO;
    public Text[] SelectedText;
  
   // public GameObject Panel;
    public static string playerfullname;
    public int num;

	void OnEnable ()
    {
        score = ScoreManager.SM.globalScore;
        //score = Random.Range(10000,50000);// this is just testing until we have the original score.
        scoretext.text = score.ToString();// we have to set score to this int variaable score when we have it.
        // Instance = this;

        selectedNO[0] = 0;
        selectedNO[1] = 0;
        selectedNO[2] = 0;

        SelectedText[0].text = Alphabets[selectedNO[0]];
        SelectedText[1].text = Alphabets[selectedNO[1]];
        SelectedText[2].text = Alphabets[selectedNO[2]];
        num = 1;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            UpButton(num);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            DownButton(num);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            num++;
            if (num == 4)
            {
                Debug.Log("save name and score");
                if (PlayerPrefs.HasKey("name"))
                {
                    string s1 = PlayerPrefs.GetString("name");
                    PlayerPrefs.SetString("name", s1 + "_" + Alphabets[selectedNO[0]] + Alphabets[selectedNO[1]] + Alphabets[selectedNO[2]]);
                    PlayerPrefs.Save();

                    string s2 = PlayerPrefs.GetString("score");
                    PlayerPrefs.SetString("score", s2 + "_" + score);
                    PlayerPrefs.Save();

                    Debug.Log(PlayerPrefs.GetString("name"));
                    Debug.Log(PlayerPrefs.GetString("score"));
                   // Application.LoadLevel(3);
                  //  SceneManager.LoadScene(3);
                }
                else
                {
                    PlayerPrefs.SetString("name", Alphabets[selectedNO[0]] + Alphabets[selectedNO[1]] + Alphabets[selectedNO[2]]);
                    PlayerPrefs.Save();

                    PlayerPrefs.SetString("score", score.ToString());
                    PlayerPrefs.Save();

                    Debug.Log(PlayerPrefs.GetString("name"));
                    Debug.Log(PlayerPrefs.GetString("score"));
                }

                SceneManager.LoadScene(4);

            }
        }
    }

    public void UpButton(int num)
    {
        if (num==1)
        {
            if (selectedNO[0] == 0)
            {
                selectedNO[0] = 25;
            }
            else
            {
                selectedNO[0] = selectedNO[0] - 1;
            }

            SelectedText[0].text = Alphabets[selectedNO[0]];

        }
        else if (num==2)
        {
            if (selectedNO[1] == 0)
            {
                selectedNO[1] = 25;
            }
            else
            {
                selectedNO[1] = selectedNO[1] - 1;
            }

            SelectedText[1].text = Alphabets[selectedNO[1]];
        }
        else if (num==3)
        {
            if (selectedNO[2] == 0)
            {
                selectedNO[2] = 25;
            }
            else
            {
                selectedNO[2] = selectedNO[2] - 1;
            }

            SelectedText[2].text = Alphabets[selectedNO[2]];
        }
    }

    public void DownButton(int num)
    {
        if (num == 1)
        {
            if (selectedNO[0] == 25)
            {
                selectedNO[0] = 0;
            }
            else
            {
                selectedNO[0] = selectedNO[0] + 1;
            }

            SelectedText[0].text = Alphabets[selectedNO[0]];
        }
        else if (num == 2)
        {
            if (selectedNO[1] == 25)
            {
                selectedNO[1] = 0;
            }
            else
            {
                selectedNO[1] = selectedNO[1] + 1;
            }

            SelectedText[1].text = Alphabets[selectedNO[1]];
        }
        else if (num == 3)
        {
            if (selectedNO[2] == 25)
            {
                selectedNO[2] = 0;
            }
            else
            {
                selectedNO[2] = selectedNO[2] + 1;
            }

            SelectedText[2].text = Alphabets[selectedNO[2]];
        }
    }
}
