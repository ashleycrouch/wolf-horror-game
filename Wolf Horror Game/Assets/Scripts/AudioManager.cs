using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip = null;
    [SerializeField] private AudioSource audioSource = null;
    public static AudioManager Instance = null;

    private void Awake()
    {
        Instance = this;
        audioSource.loop = true;
    }
    public void PlaySong(AudioClip audioClip)
    {
        if (this.audioClip != audioClip)
        {
            this.audioClip = audioClip;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
