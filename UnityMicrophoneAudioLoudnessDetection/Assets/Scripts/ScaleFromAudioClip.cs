using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;

    public float loudnessMultiplier = 100;
    public float loudnessThreshold = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessMultiplier;

        if (loudness < loudnessThreshold)
        {
            loudness = 0;
        }

        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
