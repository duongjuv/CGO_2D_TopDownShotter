using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource shotAudio, playerDieAudio;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio(string name)
    {
        switch (name)
        {
            case "PlayerShot":
                shotAudio.Play();
                break;
            /*case "PlayerDie":
                playerDieAudio.Play();
                break;*/
        }
    }
}
