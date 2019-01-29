using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sounds {
	public string name;
	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume = 1f;
	[Range(0.5f, 1.5f)]
	public float pitch = 1f;
	[Range(0f, 1.5f)]
	public float randomVolume = 0f;
	[Range(0f, 1.5f)]
	public float randomPitch = 0f;

	private AudioSource source;

	public void SetSource (AudioSource _source) {
		source = _source;
		source.clip = clip;
	}

	public void Play () {
		source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
		source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
		source.PlayOneShot(clip, volume);
	}

	public void PlaySingle () {
		source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
		source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
		source.Play();
	}

	public void Stop () {
		source.Stop();
	}

	public void SetLooping (bool _loop) {
		source.loop = _loop;
	}

	public bool CheckPlaying () {
		return source.isPlaying;
	}
}
public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
 

    public List<Sounds> sounds;
	
	void Awake () {
		if (instance != null) {
			Debug.LogError("More than one AudioManager in scene!");
            
		} else {
			instance = this;
            DontDestroyOnLoad(this);
		}
	}

	void Start () {
		for (int i = 0; i < sounds.Count; i++) {
			GameObject _go = new GameObject("Sound_" + sounds[i].name + "_" + i);
			sounds[i].SetSource(_go.AddComponent<AudioSource>());
			_go.transform.SetParent(this.transform);
		}
	}

	public void PlaySound (string _name) {
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].name == _name) {
				sounds[i].Play();
				return;
			}
		}
		// PLEASE BRACKEYS I HOPE THIS WORKS IM TIRED
		Debug.LogWarning("yeet" + _name + "is yeetn't");
	}

	public void PlaySoundSingle (string _name) {
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].name == _name) {
				sounds[i].PlaySingle();
				return;
			}
		}
		// PLEASE BRACKEYS I HOPE THIS WORKS IM TIRED
		Debug.LogWarning("yeet" + _name + "is yeetn't");
	}

	public bool IsPlaying (string _name) {
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].name == _name) {
				return sounds[i].CheckPlaying();
			}
		}
		// PLEASE BRACKEYS I HOPE THIS WORKS IM TIRED
		Debug.LogWarning("yeet" + _name + "is yeetn't");
		return false;
	}

	public void SetLoop (string _name, bool _loop) {
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].name == _name) {
				sounds[i].SetLooping(_loop);
				return;
			}
		}
		// PLEASE BRACKEYS I HOPE THIS WORKS IM TIRED
		Debug.LogWarning("yeet" + _name + "is yeetn't");
	}

	public void StopSound (string _name) {
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].name == _name) {
				sounds[i].Stop();
				return;
			}
		}
		// PLEASE BRACKEYS I HOPE THIS WORKS IM TIRED
		Debug.LogWarning("yeet" + _name + "is yeetn't");
	}
}
