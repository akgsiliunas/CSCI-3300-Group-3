using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public string[] Alphabets;
    public int[] selectedNO;
    public Text[] SelectedText;
    public static GameOverScreen Instance;
    public GameObject Panel;
    public static string playerfullname;

	void OnEnable ()
    {
        Instance = this;

        selectedNO[0] = 0;
        selectedNO[1] = 0;
        selectedNO[2] = 0;

        SelectedText[0].text = Alphabets[selectedNO[0]];
        SelectedText[1].text = Alphabets[selectedNO[1]];
        SelectedText[2].text = Alphabets[selectedNO[2]];

    }

    public void ShowPanel()
    {
        Panel.SetActive(true);
    }

    public void PanelClose()
    {
        Panel.SetActive(false);
        playerfullname = Alphabets[selectedNO[0]] + Alphabets[selectedNO[1]] + Alphabets[selectedNO[2]];
    }
   //go to any script and call GameOverScreen.Instance.ShowPanel(); it will open the gameover popup
   // to close the popup use method  GameOverScreen.Instance.PanelClose();
// to get player name use   string name = GameOverScreen.playerfullname;

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
