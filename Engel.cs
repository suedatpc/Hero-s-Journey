using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //we added this for using different lvls in our game

public class Engel : MonoBehaviour
{
    private Scene _scene; 

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); //This line of code retrieves the currently active scene and stores it in "_scene"
        Debug.Log(_scene.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) //if the other object has a tag named "player" we should load scene 
        {
            Score.lives--;
            SceneManager.LoadScene(_scene.name);
        }
    }
}