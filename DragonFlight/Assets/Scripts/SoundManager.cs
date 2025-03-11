using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; set; }
    AudioSource myAudio; // AudioSource ÄÄÆ÷³ÍÆ®
    public AudioClip BulletSound;
    public AudioClip DieSound;

    private void Awake()
    {
        if (SoundManager.Instance == null)
        {
            SoundManager.Instance = this;
        }
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(BulletSound);
    }

    public void PlayDieSound()
    {
        myAudio.PlayOneShot(DieSound);
    }
}
