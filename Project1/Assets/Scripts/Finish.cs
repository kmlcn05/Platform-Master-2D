using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    public GameObject player;

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();

        if(player == null)
            player = FindObjectOfType<PlayerMovement>().gameObject;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {

        Point.point += player.GetComponent<ItemCollector>().cherries;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}