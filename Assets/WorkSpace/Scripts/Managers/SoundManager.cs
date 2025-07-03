/**
 * @file SoundManager.cs
 * @brief 音関係のマネージャー
 * @author Sum1r3
 * @date 2025/6/17
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource BGMSource;
    [SerializeField]
    private AudioSource SoundSource;
    [SerializeField]
    private List<AudioClip> BGMClips = new List<AudioClip>();
    [SerializeField]
    private List<AudioClip> SoundClip = new List<AudioClip>();
    private void Start() {
        instance = this; 
    }

    public void PlaySound(int SoundIndex) {
        if (BGMSource == null || SoundIndex > SoundClip.Count || SoundIndex < 0) return; 

        SoundSource.PlayOneShot(SoundClip[SoundIndex]);
    }
    
}
