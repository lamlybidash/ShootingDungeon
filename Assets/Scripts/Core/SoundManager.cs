using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private List<AudioClip> _clips;

    private Dictionary<string, AudioClip> _clipDict = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (var clip in _clips)
            {
                _clipDict[clip.name] = clip;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(string clipName)
    {
        if (_clipDict.TryGetValue(clipName, out var clip))
        {
            _sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"Clip '{clipName}' not found in SoundManager!");
        }
    }

    public void PlayMusic(string clipName, bool loop = true)
    {
        if (_clipDict.TryGetValue(clipName, out var clip))
        {
            _musicSource.clip = clip;
            _musicSource.loop = loop;
            _musicSource.Play();
        }
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }
}
