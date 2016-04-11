using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Leaderboard : MonoBehaviour {

	public RectTransform parent;
	public GameObject rowPrefab;

	void Start () {

		


		string namesRaw = PlayerPrefs.GetString ("name", string.Empty);
		string scoresRaw = PlayerPrefs.GetString ("score");
		// if we have something
		if(namesRaw.Length >= 3){
			string[] names = namesRaw.Split ('_');
			string[] scores = scoresRaw.Split ('_');


			List<KeyValuePair<string,int>> scoresList = new List<KeyValuePair<string, int>> ();

			for (int i = 0; i < scores.Length; i++) {
				KeyValuePair<string, int> kp = new KeyValuePair<string, int> (names[i],int.Parse(scores[i]));
				scoresList.Add (kp);
			}

			scoresList.Sort ((pair2, pair1) => pair1.Value.CompareTo (pair2.Value));

			if(names.Length != scores.Length){
				Debug.LogError ("Invalid scores");
				return;
			}
			int totalRows = names.Length;
			// 70 is height of a single row and 10 is space between each row
			float totalHeight = totalRows * (70 + 10);
			Vector2 size = parent.sizeDelta;
			size.y = totalHeight;
			parent.sizeDelta = size;

			Debug.Log (totalRows);
			Vector3 position = new Vector3(0f,10f,0f);

			for (int i = 0; i < totalRows; i++) {
				
				position.y = -i * (70 + 10);
				GameObject row = Instantiate (rowPrefab) as GameObject;
				LBRow lbr = row.GetComponent<LBRow> ();
				lbr.name.text = scoresList[i].Key;
				lbr.score.text = scoresList[i].Value.ToString();
				lbr.trans.parent = parent;
				position.x = 0;
				lbr.trans.localPosition = position;
				lbr.trans.localScale = Vector3.one;
				int ix = i + 1;
				string rank = ix.ToString ();
				if (ix % 10 == 1 && ix != 11) {
					rank += "st";
				} else if (ix % 10 == 2 && ix != 12) {
					rank += "nd";
				} else if (ix % 10 == 3 && ix != 13) {
					rank += "rd";
				} else {
					rank += "th";
				}
				lbr.rank.text = rank;
			}
		}
	}

	

}
