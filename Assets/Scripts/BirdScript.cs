using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D bird;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource audioSource;
    public AudioClip jumpAudioClip;

    void KillBird()
    {
        logic.GameOver();
        birdIsAlive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            bird.velocity = Vector2.up * flapStrength;
            audioSource.PlayOneShot(jumpAudioClip);;
        }

        if (bird.transform.position.y < -20)
        {
            KillBird();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        KillBird();
    }
}
