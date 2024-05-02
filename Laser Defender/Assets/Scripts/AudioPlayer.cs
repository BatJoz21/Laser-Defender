using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootingClip;
    [SerializeField, Range(0f, 1f)] private float shootingVolume = 1f;

    [Header("Damaged")]
    [SerializeField] private AudioClip damagedClip;
    [SerializeField, Range(0f, 1f)] private float damagedVolume = 1f;

    [Header("Thruster")]
    [SerializeField] private AudioClip thrusterClip;
    [SerializeField, Range(0f, 1f)] private float thrusterVolume = 1f;

    public void PlayShootingClip()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayDamagedClip()
    {
        if (damagedClip != null)
        {
            AudioSource.PlayClipAtPoint(damagedClip, Camera.main.transform.position, damagedVolume);
        }
    }

    public void PlayThrusterClip()
    {
        if (thrusterClip != null)
        {
            AudioSource.PlayClipAtPoint(thrusterClip, Camera.main.transform.position, thrusterVolume);
        }
    }
}
