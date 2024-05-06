using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private int enemyPoints = 0;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private bool applyCameraShake;
    [SerializeField] private bool isPlayer;

    private CameraShake cameraShake;
    private AudioPlayer audioPlayer;
    private ScoreKeeper scoreKeeper;

    public int GetHealth { get => health; }

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.Damage);
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamagedClip();
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(enemyPoints);
        }
        Destroy(gameObject);
    }
}
