using UnityEngine;
using System.Collections;
using System;
public class FillLeader : MonoBehaviour {
	public TextMesh score0, score1, score2, score3, score4, score5, score6,score7,score8,score9;
	// Use this for initialization
	void Start () {
		fillLeaderBoard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void fillLeaderBoard(){
		int list0 = PlayerPrefs.GetInt ("BestScore", 0);
		score0.text = "1. " + list0;
		int list1 = PlayerPrefs.GetInt ("Score1", 0);
		score1.text = "2. " + list1;
		int list2 = PlayerPrefs.GetInt ("Score2", 0);
		score2.text = "3. " + list2;
		int list3 = PlayerPrefs.GetInt ("Score3", 0);
		score3.text = "4. " + list3;
		int list4 = PlayerPrefs.GetInt ("Score4", 0);
		score4.text = "5. " + list4;
		int list5 = PlayerPrefs.GetInt ("Score5", 0);
		score5.text = "6. " + list5;
		int list6 = PlayerPrefs.GetInt ("Score6", 0);
		score6.text = "7. " + list6;
		int list7 = PlayerPrefs.GetInt ("Score7", 0);
		score7.text = "8. " + list7;
		int list8 = PlayerPrefs.GetInt ("Score8", 0);
		score8.text = "9. " + list8;
		int list9 = PlayerPrefs.GetInt ("Score9", 0);
		score9.text = "10. " + list9;


		

	}
}
