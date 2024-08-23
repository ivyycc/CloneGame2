using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    [Header("Volume")]
    [Range(0, 1)]
    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float SFXVolume = 1;

    private Bus masterBus;

    [SerializeField] public List<EventInstance> eventInst;


    private EventInstance musicEventInstance;
    private EventInstance musicEventInstance2;
    private EventInstance WindEventInstance;
    private EventInstance CrumbleEventInstance;
    public static AudioManager instance { get; private set; }


    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene");
            Destroy(gameObject);
            return;
        }

        instance = this;
       

        /* if (instance != null && instance != this)
         {
             Debug.LogError("Found more than one Audio Manager in the scene");
             Destroy(gameObject);
             return;
         }*/

        //if (instance != null)
        //{
        //  Debug.LogError("Found more than one Audio Manager in the scene");
        //}


        //instance = this;
        // DontDestroyOnLoad(gameObject);

        /* if (instance == null)
         {
             instance = this;
             DontDestroyOnLoad(gameObject);
         }
         else
         {
             Destroy(gameObject);
             return;
         }*/

        eventInst = new List<EventInstance>();


        masterBus = RuntimeManager.GetBus("bus:/");
        RuntimeManager.LoadBank("Master");
        RuntimeManager.LoadBank("Master.strings");


        //InitializeMusic(FMODEvents.instance.Music);
    }

    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex ==2)
        {
            
            InitializeMusic(FMODEvents.instance.Music);
            InitializeWind(FMODEvents.instance.Snowstorm);
        }
        

    }

    private void Update()
    {
        masterBus.setVolume(masterVolume);
        masterBus.setVolume(SFXVolume);
        masterBus.setVolume(musicVolume);
    }



    public void PlayOneShot(EventReference sound, Vector3 worldpos)
    {
        FMODUnity.RuntimeManager.PlayOneShot(sound, worldpos);
        
    }

    public EventInstance CreateEventInstance(EventReference eR)
    {
        EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance(eR);
        eventInst.Add(eventInstance);

        return eventInstance;
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        FMOD.Studio.EventInstance musicEventInstance = RuntimeManager.CreateInstance(musicEventReference);
        //musicEventInstance = CreateEventInstance(musicEventReference);event:/Music/BackgroundMusic
        musicEventInstance.start();
        Debug.Log("MUSIC STARTED");
    }
    public void InitializeMusic2(EventReference musicEventReference2)
    {
        musicEventInstance2 = RuntimeManager.CreateInstance(musicEventReference2);
        //musicEventInstance = CreateEventInstance(musicEventReference);event:/Music/BackgroundMusic
        musicEventInstance2.start();
        Debug.Log("MUSIC STARTED");
    }

    private void InitializeWind(EventReference WindEventRef)
    {
        WindEventInstance = RuntimeManager.CreateInstance(WindEventRef);
        //FMOD.Studio.EventInstance WindEventInstance = RuntimeManager.CreateInstance(WindEventRef);
        //musicEventInstance = CreateEventInstance(musicEventReference);event:/Music/BackgroundMusic
        WindEventInstance.start();
        Debug.Log("Wind STARTED");
    }

    public void InitializeCrumble(EventReference CrumbEventRef)
    {
        CrumbleEventInstance = RuntimeManager.CreateInstance(CrumbEventRef);
        //FMOD.Studio.EventInstance WindEventInstance = RuntimeManager.CreateInstance(WindEventRef);
        //musicEventInstance = CreateEventInstance(musicEventReference);event:/Music/BackgroundMusic
        CrumbleEventInstance.start();
        Debug.Log("Wind STARTED");
    }

    public void InitializeStartMusic(EventReference startMusicRef)
    {
        //WindEventInstance = RuntimeManager.CreateInstance(WindEventRef);
        FMOD.Studio.EventInstance GameMusicInstance = RuntimeManager.CreateInstance(startMusicRef);
        //musicEventInstance = CreateEventInstance(musicEventReference);event:/Music/BackgroundMusic
        GameMusicInstance.start();
        Debug.Log("Wind STARTED");
    }


    public void SetWindParam(string name, float val)
    {
        WindEventInstance.setParameterByName(name, val);
        Debug.Log($"SetWindParam called with {name}: {val}");
    }

    public void SetCrumbleParam(string name, float val)
    {
        CrumbleEventInstance.setParameterByName(name, val);
        Debug.Log($"SetWindParam called with {name}: {val}");
    }
   
    public void CleanUp()
    {
        //stop and release any created instances
        if (eventInst != null)
        {

            foreach (EventInstance eventInstance in eventInst)
            {
                eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                eventInstance.release();
            }
        }
    }
    private void OnDestroy()
    {
        CleanUp();
    }
    private void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        CleanUp();
    }

    /*public void StopMusic2()
    {
        if (musicEventInstance2.isValid())
        {
            musicEventInstance2.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicEventInstance2.release();
        }
    }*/


}
