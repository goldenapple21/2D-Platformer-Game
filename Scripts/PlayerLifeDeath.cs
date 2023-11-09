using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLifeDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Renderer ren;

    [SerializeField] private AudioSource PlayerDeathSoundEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ren = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }


    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        ren.enabled = false;
        Invoke(nameof(RestartLevel), 3.0f);
        PlayerDeathSoundEffect.Play();
    }

    private void RestartLevel()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


