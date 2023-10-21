using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawning : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public GameObject policeToSpawn;

    public GameObject bonus;

    private float spawnCooldown = 5.0f;
    private float PoliceSpawn = 0.0f;
    private float PoliceSpawnMax = 10.0f;

    private float bonusSpawn = 0.0f;
    private float bonusSpawnMax = 12.0f;
    private Vector3 screenBounds;
    private int rand;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        spawnCooldown += Time.deltaTime;
        PoliceSpawn += Time.deltaTime;
        bonusSpawn += Time.deltaTime;

        if (spawnCooldown > Score.carSpawnSpeed){
            float x = Random.Range(-screenBounds.x, screenBounds.x);
            float y = screenBounds.y + 3; 
            rand = Random.Range(0, objectsToSpawn.Length);
            GameObject SpawnedCar = Instantiate(objectsToSpawn[rand], new Vector3(x, y, 0), Quaternion.identity);
            Destroy(SpawnedCar, 8);
            spawnCooldown = 0;

            //makes game harder
            Score.score++;
            Score.gamePace += 0.05f;
            Score.lineSpawnSpeed -= 0.001f;
            if (Score.carSpawnSpeed > 1.0f)
                Score.carSpawnSpeed -= 0.05f;
            Debug.Log(Score.carSpawnSpeed);
        }
        
        if (PoliceSpawn > PoliceSpawnMax){
            float x = Random.Range(-screenBounds.x, screenBounds.x);
            float y = -screenBounds.y - 1; 
            GameObject SpawnedCar = Instantiate(policeToSpawn, new Vector3(x, y, 0), Quaternion.identity);
            Destroy(SpawnedCar, 8);
            PoliceSpawn = 0;
            PoliceSpawnMax = Random.Range(7.0f, 15.0f);
        }

        if (bonusSpawn > bonusSpawnMax){
            float x = Random.Range(-screenBounds.x, screenBounds.x);
            float y = screenBounds.y + 3; 
            GameObject SpawnedCar = Instantiate(bonus, new Vector3(x, y, 0), Quaternion.identity);
            Destroy(SpawnedCar, 8);
            bonusSpawn = 0;
            bonusSpawnMax = Random.Range(10.0f, 20.0f);
            Debug.Log("Hello");
        }

    }
}
