using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestPhysics : MonoBehaviour
{
    public Animator animator;
    public int lives = 3;
    public int score = 0;

    public SpawnManager spawnManager;

    public UIManager uiManager;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = new Vector3(mousePos.x, transform.position.y, 0);
        //Debug.Log($"Mouse position {mousePos}");
    }

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    private void LateUpdate()
    {
        //Log("LateUpdate");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger " + collision.gameObject.name);
        animator.SetTrigger("isEat");
        if (collision.tag == "Food")
        {
            animator.SetTrigger("isEatFull");
            score++;
            uiManager.SetScore(score);
        }
        else
        {
            animator.SetTrigger("isEatFuck");
            lives--;
            uiManager.SetLives(lives);
            if (lives <= 0)
            {
                Debug.Log("Game Over");
                spawnManager.isStartGame = false;
                uiManager.ShowAnimationFade(2);
            }
        }
        Destroy(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);
        Destroy(collision.gameObject);
    }

    public void StartGame()
    {
        lives = 3;
        uiManager.SetLives(lives);
        score = 0;
        uiManager.SetScore(score);
    }
}
