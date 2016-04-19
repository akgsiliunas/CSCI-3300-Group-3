using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour
{

    public static int Difficulty; //to access this in any script use if(DifficultyScript.Difficulty==1)
    private int Number;
    public Color targetcolor;
    public Text[] textsArray;

    void Start()
    {
        Number = 0;
        textsArray[Number].color = targetcolor;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (Number > 0)
            {
                Number--;
            }
            /* else
             {
                 Number = 3;
             }*/
           // Debug.Log(Number);
            for (int i=0;i<4;i++)
            {
                textsArray[i].color = new Color(1,1,1,1);
            }
            textsArray[Number].color = targetcolor;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (Number < 3)
            {
                Number++;
            }
          //  Debug.Log(Number);
           /* else
            {
                Number = 0;
            }*/
            for (int i = 0; i < 4; i++)
            {
                textsArray[i].color = new Color(1, 1, 1, 1);
            }
            textsArray[Number].color = targetcolor;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Difficulty = Number;
            Application.LoadLevel(2);
        }
    }
}
