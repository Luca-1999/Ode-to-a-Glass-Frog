using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioC : MonoBehaviour
{

    public enum Sounds {
        pMove,pJump,aSound,bDeath,bGround,pDamage,lStep,rStep,
    }

    public Sound[] sn;

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

    //copies Clip state to Audio Source
    private void matchSource(AudioSource aS, Sound s) {

        aS.clip = s.clip;
        aS.volume = s.volume;
        aS.pitch = s.pitch;
        aS.loop = s.loop;
    }

    private void Start()
    {
        Play(Sounds.bGround);
    }

    //for player effects and
    public void Play(Sounds s) {
        sn[(int)s].source.Play();
    }

    //for enemies, creates and gets rid of empty game object
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

    //FindObjectOfType<audioC>().Play(still need reference to enum);
    //controller.Play(audioC.Sounds.bDeath);
}
