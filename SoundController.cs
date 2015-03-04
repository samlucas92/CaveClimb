using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip    ClickSound,flyUp,ScoreIncrease,GameOver;
	
	public static SoundController Static ;
	public AudioSource[]  audioSources;
	public AudioSource bgAudio;
	
	//public AudioSource scoreCount,bgSound ;
	
	void Start () {
		
		Static = this;
	}
	
	// Update is called once per frame
	
	public void PlayScoreIncrease()
	{
		
		swithAudioSources (ScoreIncrease);
		
	}
	public void PlayFlyUp()
	{
		
		swithAudioSources (flyUp);
		
	}



	public void PlayGameOver()
	{
		bgAudio.volume=0;
		swithAudioSources (GameOver);
		
	}
	
	public void PlayClickSound()
	{
		
		swithAudioSources (ClickSound);
		
	}

	//public void StopSounds ()
	//{
	//	audio.Stop ();
	//}
	
	void swithAudioSources( AudioClip clip)
	{
		if(audioSources[0].isPlaying) 
		{
			audioSources[1].PlayOneShot(clip);
		}
		else audioSources[0].PlayOneShot(clip);
		
	}
}
