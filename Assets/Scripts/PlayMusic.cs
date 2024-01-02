using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SE DEBE CREAR UN COMPONENTE VACÍO EN LA ESCENA Y AÑADIRLE ESTE SCRIPT PARA QUE FUNCIONE
// LA CANCION DEBE ESTAR EN ASSETS/RESOURCES

public class PlayMusic : MonoBehaviour
{
    public AudioClip background_music;
    private AudioSource audio_source;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        if (audio_source == null) {
            audio_source = gameObject.AddComponent<AudioSource>();
        }
        audio_source.clip = background_music;
        audio_source.loop = true;
        audio_source.Play();        
    }

}
