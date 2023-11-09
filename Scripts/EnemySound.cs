using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource EnemyDefeatSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            EnemyDefeatSoundEffect.Play();
        }
    }

}