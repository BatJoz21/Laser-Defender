using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [Header("Fire Rate")]
    [SerializeField] private float minimumFiringRate = 0.1f;
    [SerializeField] private float varianceFiringRate = 0;
    [SerializeField] private float baseFiringRate = 2.0f;
    [Header("AI Toogle")]
    [SerializeField] private bool useAI;

    private bool isFiring;
    private Coroutine firingCoroutine;

    public bool IsFiring { get => isFiring; set => isFiring = value; }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
            yield return new WaitForSecondsRealtime(GetRandomFireRate());
        }
    }

    private float GetRandomFireRate()
    {
        float randomRate = Random.Range(baseFiringRate - varianceFiringRate, baseFiringRate + varianceFiringRate);
        return Mathf.Clamp(randomRate, minimumFiringRate, float.MaxValue);
    }
}
