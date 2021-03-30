using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioC : MonoBehaviour
{

    public enum Sounds {
        pMove,pJump,aSound,bDeath,bGround,pDamage,lStep,rStep, intro,
    }

    public Sound[] sn;

    int prevBIndex;

    public Sounds[] bSound;

    public static audioC instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        //attach audio source to each Sound object
        foreach (Sound s in sn) {
            s.source = gameObject.AddComponent<AudioSource>();
            matchSource(s.source, s);
            //s.source.clip = s.clip;
            //s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            //s.source.loop = s.loop;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //copies Clip state to Audio Source
    private void matchSource(AudioSource aS, Sound s) {

        aS.clip = s.clip;
        aS.volume = s.volume;
        aS.pitch = s.pitch;
        aS.loop = s.loop;
    }

    private void Start()
    {
        prevBIndex = 0;
        //Play(Sounds.intro);
    }

    //for player sounds
    public void Play(Sounds s) {
        sn[(int)s].source.Play();
    }

    //for enemies & other, creates and gets rid of empty game object
    //with attached audio source
    //attempts to implement 3d sound
    public void Play(Sounds s, Vector3 position, string tag)
    {
        //pluck object with audio source from pool
        GameObject sourceObj = PoolTest.instance.SpawnFromPool(tag, position, Quaternion.identity);
        //retrieve its audio source
        AudioSource aS = sourceObj.GetComponent<AudioSource>();
        //retireve sound from corresponding enum
        Sound sound = sn[(int)s];
        //match audio source to controller's specifications + clip
        matchSource(aS, sound);
        aS.Play();
        //Object.Destroy(soundGameObject, audioSource.clip.length);
    }

    public bool isPlaying (Sounds s) {
        return sn[(int)s].source.isPlaying;
    }

    public void Stop(Sounds s) {
        sn[(int)s].source.Stop();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int curBIndex = Game.instance.getScene();
        Debug.Log("loaded scene");
        //SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Cur index is: " + curBIndex);
        if (isPlaying(bSound[prevBIndex])) Stop(bSound[prevBIndex]);
        Play(bSound[curBIndex]);
        prevBIndex = curBIndex;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //FindObjectOfType<audioC>().Play(still need reference to enum);
    //controller.Play(audioC.Sounds.bDeath);
}
