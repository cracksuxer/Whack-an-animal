using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update    
    public AudioClip background_music;
    private AudioSource audio_source;
    public int volume = 100;
    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<AudioSource>(out audio_source))
        {
            audio_source = gameObject.AddComponent<AudioSource>();
        }
        audio_source.clip = background_music;
        audio_source.loop = true;
        audio_source.volume = volume / 100f;
        audio_source.Play();
    }
}

