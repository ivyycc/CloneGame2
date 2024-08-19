using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{

    [field: Header("UI SFX")]
    [field: SerializeField] public EventReference select { get; private set; }
    [field: SerializeField] public EventReference play { get; private set; }
    [field: SerializeField] public EventReference quit { get; private set; }

    [field: Header("Other SFX")]
    [field: SerializeField] public EventReference collectFloatie { get; private set; }
    [field: SerializeField] public EventReference levelUp { get; private set; }

    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerJump { get; private set; }
    [field: SerializeField] public EventReference playerOblivion { get; private set; }
    [field: SerializeField] public EventReference playerHit { get; private set; }
    [field: SerializeField] public EventReference playerLand { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference Music { get; private set; }

    public static FMODEvents instance { get; private set; }

    public void Awake()
    {

        if (instance != null) //&& instance != this)
        {
            Debug.LogError("Found more than one Audio Manager in the scene");
            // Destroy(gameObject);
            //return;
        }

        instance = this;
        // DontDestroyOnLoad(gameObject);

    }
}
