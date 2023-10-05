using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public TestPhysics testPhysics;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            // - lives
            testPhysics.animator.SetTrigger("isEatFuck");
            testPhysics.lives--;
            testPhysics.uiManager.SetLives(testPhysics.lives);
            if (testPhysics.lives <= 0)
            {
                testPhysics.uiManager.ShowAnimationFade(2);
                testPhysics.spawnManager.isStartGame = false;
            }
        }
    }
}
