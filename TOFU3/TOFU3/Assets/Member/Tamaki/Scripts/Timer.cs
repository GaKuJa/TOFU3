using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	//　トータル制限時間
	private float totalTime;
	[SerializeField]
	private int minute;
	[SerializeField]
	private float seconds;
	private Text timerText;
	private float oldSeconds;

	void Start()
	{
		totalTime = minute * 60 + seconds;
		oldSeconds = 0f;
		timerText = GetComponentInChildren<Text>();
	}

	void Update()
	{
		//制限時間が0秒以下なら何もしない
		if (totalTime <= 0f)
		{
			return;
		}
		//一旦トータルの制限時間を計測；
		totalTime = minute * 60 + seconds;
		totalTime -= Time.deltaTime;

		//再設定
		minute = (int)totalTime / 60;
		seconds = totalTime - minute * 60;

		//タイマー表示用UIテキストに時間を表示する
		if ((int)seconds != (int)oldSeconds)
		{
			timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
		}
		oldSeconds = seconds;
		//　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する		
		if (totalTime <= 0f)
		{
			Debug.Log("制限時間終了");
		}
	}
}
