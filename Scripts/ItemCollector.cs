using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;

    [SerializeField] private Text coinsText;

    [SerializeField] private AudioSource ItemSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold Coin"))
        {
            Destroy(collision.gameObject);
            coins = coins + 3;
            coinsText.text = "Coins: " + coins;
            ItemSoundEffect.Play();
        }

        if (collision.gameObject.CompareTag("Silver Coin"))
        {
            Destroy(collision.gameObject);
            coins = coins + 2;
            coinsText.text = "Coins: " + coins;
            ItemSoundEffect.Play();
        }

        if (collision.gameObject.CompareTag("Bronze Coin"))
        {
            Destroy(collision.gameObject);
            coins = coins + 1;
            coinsText.text = "Coins: " + coins;
            ItemSoundEffect.Play();
        }

    }
}
