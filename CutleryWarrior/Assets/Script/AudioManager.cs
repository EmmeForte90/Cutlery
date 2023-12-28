using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    #region Header
    [Tooltip("Musica di base")]
    public int MusicBefore;
    [Tooltip("Musica da attivare se necessario quando la telecamera inquadra l'evento")]
    public int MusicAfter;
    [Header("Music")]
    [SerializeField] public AudioClip[] listmusic; // array di AudioClip contenente tutti i suoni che si vogliono riprodurre
    private AudioSource[] bgm; // array di AudioSource che conterrà gli oggetti AudioSource creati
    private bool bgmActive = false;
    [SerializeField] public AudioClip[] Ambiental; // array di AudioClip contenente tutti i suoni che si vogliono riprodurre
    [SerializeField] public AudioClip[] UiM; // array di AudioClip contenente tutti i suoni che si vogliono riprodurre
    private AudioSource[] sgm; // array di AudioSource che conterrà gli oggetti AudioSource creati
    private AudioSource[] ugm; // array di AudioSource che conterrà gli oggetti AudioSource creati
    private bool sgmActive = false;
    public AudioMixer MSX;
    public AudioMixer SFX;
    public static AudioManager instance;
    #endregion
    public void Awake()
    {
        if (instance == null){instance = this;}
        bgm = new AudioSource[listmusic.Length]; // inizializza l'array di AudioSource con la stessa lunghezza dell'array di AudioClip
        for (int i = 0; i < listmusic.Length; i++) // scorre la lista di AudioClip
        {
        bgm[i] = gameObject.AddComponent<AudioSource>(); // crea un nuovo AudioSource come componente del game object attuale (quello a cui è attaccato lo script)
        bgm[i].clip = listmusic[i]; // assegna l'AudioClip corrispondente all'AudioSource creato
        bgm[i].playOnAwake = false; // imposto il flag playOnAwake a false per evitare che il suono venga riprodotto automaticamente all'avvio del gioco
        bgm[i].loop = true; // imposto il flag playOnAwake a false per evitare che il suono venga riprodotto automaticamente all'avvio del gioco
        }
        foreach (AudioSource audioSource in bgm){audioSource.outputAudioMixerGroup = MSX.FindMatchingGroups("Master")[0];}
        //
        sgm = new AudioSource[Ambiental.Length]; // inizializza l'array di AudioSource con la stessa lunghezza dell'array di AudioClip
        for (int i = 0; i < Ambiental.Length; i++) // scorre la lista di AudioClip
        {
            sgm[i] = gameObject.AddComponent<AudioSource>(); // crea un nuovo AudioSource come componente del game object attuale (quello a cui è attaccato lo script)
            sgm[i].clip = Ambiental[i]; // assegna l'AudioClip corrispondente all'AudioSource creato
            sgm[i].playOnAwake = false; // imposto il flag playOnAwake a false per evitare che il suono venga riprodotto automaticamente all'avvio del gioco
            sgm[i].loop = false; // imposto il flag playOnAwake a false per evitare che il suono venga riprodotto automaticamente all'avvio del gioco
        }
        foreach (AudioSource audioSource in sgm){audioSource.outputAudioMixerGroup = SFX.FindMatchingGroups("Master")[0];}
        //
        ugm = new AudioSource[UiM.Length]; // inizializza l'array di AudioSource con la stessa lunghezza dell'array di AudioClip
        for (int i = 0; i < UiM.Length; i++) // scorre la lista di AudioClip
        {
            ugm[i] = gameObject.AddComponent<AudioSource>(); // crea un nuovo AudioSource come componente del game object attuale (quello a cui è attaccato lo script)
            ugm[i].clip = UiM[i]; // assegna l'AudioClip corrispondente all'AudioSource creato
            ugm[i].playOnAwake = false; // imposto il flag playOnAwake a false per evitare che il suono venga riprodotto automaticamente all'avvio del gioco
            ugm[i].loop = false; // imposto il flag playOnAwake a false per evitare che il suono venga riprodotto automaticamente all'avvio del gioco
        }
        foreach (AudioSource audioSource in ugm){audioSource.outputAudioMixerGroup = SFX.FindMatchingGroups("Master")[0];}
    }
    public void SetVolume(float volume){MSX.SetFloat("Volume", volume);}
    public void SetSFX(float volume){SFX.SetFloat("Volume", volume);}
    public void PlayMFX(int soundToPlay)
    {
        if (!bgmActive)
        {
            bgm[soundToPlay].Play();
            bgmActive = true;
        }
    }
    public void StopMFX(int soundToPlay)
    {
        if (bgmActive)
        {
            bgm[soundToPlay].Stop();
            bgmActive = false;
        }
    }
    
    public void PlaySFX(int soundToPlay)
    {
        if (!sgmActive)
        {
            sgm[soundToPlay].Play();
            sgmActive = true;
            StartCoroutine(Restoresfx());
        }
    }
    public void StopSFX(int soundToPlay)
    {
        if (sgmActive)
        {
            sgm[soundToPlay].Stop();
            sgmActive = false;
        }
    }
    public void PlayUFX(int soundToPlay){ugm[soundToPlay].Play();}
    public IEnumerator Restoresfx(){yield return new WaitForSeconds(1f); sgmActive = false;}
    public void CrossFadeINAudio(int soundToPlay){StartCoroutine(FadeIn(bgm[soundToPlay], 1f));}
    public void CrossFadeOUTAudio(int soundToPlay){StartCoroutine(FadeOut(bgm[soundToPlay], 1f));}
    public IEnumerator FadeOut(AudioSource bgm, float FadeTime)
{
    // Impostare la variabile bgmActive a false per indicare che l'audio è in fase di dissolvenza
    bgmActive = false;

    // Memorizzare il volume iniziale dell'audio
    float startVolume = bgm.volume;

    // Ridurre gradualmente il volume durante il tempo specificato per la dissolvenza
    while (bgm.volume > 0)
    {
        bgm.volume -= startVolume * Time.deltaTime / FadeTime;
        yield return null;
    }

    // Interrompere la riproduzione dell'audio una volta completata la dissolvenza
    bgm.Stop();

    // Ripristinare il volume iniziale dell'audio
    bgm.volume = startVolume;
}

public IEnumerator FadeIn(AudioSource bgm, float FadeTime)
{
    // Impostare la variabile bgmActive a false per indicare che l'audio è in fase di dissolvenza
    bgmActive = false;

    // Impostare il volume iniziale a 0.2f per evitare che l'audio parta troppo forte
    float startVolume = 0.2f;

    // Impostare il volume dell'audio a 0 e avviare la riproduzione
    bgm.volume = 0;
    bgm.Play();

    // Aumentare gradualmente il volume durante il tempo specificato per la dissolvenza
    while (bgm.volume < 0.5f)
    {
        bgm.volume += startVolume * Time.deltaTime / FadeTime;
        yield return null;
    }

    // Impostare il volume dell'audio a 0.5f dopo completata la dissolvenza per un volume finale desiderato
    bgm.volume = 0.5f;
}
}