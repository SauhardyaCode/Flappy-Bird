using UnityEngine;

public class SWAudioManagerScript : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundClip;
    public AudioClip buttonClip;

    public float[] pitchRandomizeRange = { 0.9f, 1.1f };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = backgroundClip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, bool pitchRandomizeOn = true, float pitch = 1)
    {
        if (pitchRandomizeOn)
        {
            sfxSource.pitch = Random.Range(pitchRandomizeRange[0], pitchRandomizeRange[1]);
        }
        else
        {
            sfxSource.pitch = pitch;
        }
        sfxSource.PlayOneShot(clip);
    }
}
