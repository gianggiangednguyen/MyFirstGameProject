using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> lstFood;

    public float timerSpawnFood = 3;

    public float countdownSpawnFood;

    public bool isStartGame;

    // Start is called before the first frame update
    void Start()
    {
        countdownSpawnFood = timerSpawnFood;
        //isStartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartGame)
        {
            countdownSpawnFood -= Time.deltaTime;
            if (countdownSpawnFood <= 0)
            {
                countdownSpawnFood = timerSpawnFood;
                // Spawn random food
                SpawnRandomFood();
            }
        }
    }

    private void SpawnRandomFood()
    {
        int indexFood = Random.Range(0, lstFood.Count);
        var goFood = Instantiate(lstFood[indexFood], transform);
        var randomPositionX = Random.Range(-2.5f, 2.5f);
        goFood.transform.localPosition = new Vector3(randomPositionX, y: 0, z: 0);
    }
}
