using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for textmeshPro

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>(); //caching
        _text.text = Score.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Elmas"))
        {
            _audio.Play();
            Destroy(other.gameObject); //destroy a specific game object
            Score.totalScore++;
            _text.text = Score.totalScore.ToString();
        }
    }
}
