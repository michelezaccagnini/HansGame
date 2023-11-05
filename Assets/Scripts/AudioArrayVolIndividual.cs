using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TunedAudioClip
{
    public AudioClip clip;
    [Range(0, 1)] public float volume;
    [Range(0, 1)] public float pitch;
    [Range(0, 1)] public float timePoint;


}

[RequireComponent(typeof(AudioSource))]
public class AudioArrayVolIndividual : MonoBehaviour
{
    private AudioSource source;
    public TunedAudioClip[] clips;

    private void Awake()
    {
        Debug.Assert(clips != null, this);
        Debug.Assert(clips.Length != 0, this);

        source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        int clipToPlay = Random.Range(0, clips.Length);

        source.PlayOneShot(clips[clipToPlay].clip, clips[clipToPlay].volume);
        source.PlayOneShot(clips[clipToPlay].clip, clips[clipToPlay].pitch);
        source.PlayOneShot(clips[clipToPlay].clip, clips[clipToPlay].timePoint);
    }
}