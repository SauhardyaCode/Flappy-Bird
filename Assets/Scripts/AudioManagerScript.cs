using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundClip;
    public AudioClip crashClip;
    public AudioClip pointClip;
    public AudioClip buttonClip;
    public AudioClip gameOver1;
    public AudioClip gameOver2;
    public AudioClip flapClip;

    public float backgroundVolume;
    public float[] pitchRandomizeRange = { 0.9f, 1.1f };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = backgroundClip;
        musicSource.volume = backgroundVolume;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, bool pitchRandomizeOn = true, float pitch = 1, float[] pitchRange = null)
    {
        if (pitchRandomizeOn)
        {
            if (pitchRange == null)
            {
                pitchRange = pitchRandomizeRange;
            }
            sfxSource.pitch = Random.Range(pitchRange[0], pitchRange[1]);
        }

        else
        {
            sfxSource.pitch = pitch;
        }
            sfxSource.PlayOneShot(clip);
    }

}
