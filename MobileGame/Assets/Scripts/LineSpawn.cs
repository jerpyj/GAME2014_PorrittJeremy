using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawn : MonoBehaviour
{
    public GameObject lines;

    private Vector3 screenBounds;

    private float spawnCooldown = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        float yspawn = screenBounds.y;
        for (int i = 0; i < 15; i++)
        {
            GameObject linez = Instantiate(lines, new Vector3(0, yspawn, 0), Quaternion.identity);
            Destroy(linez, 12);
            yspawn--;
        }

    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown += Time.deltaTime;

        if (spawnCooldown > Score.lineSpawnSpeed){
            float y = screenBounds.y + 1; 
            GameObject linez = Instantiate(lines, new Vector3(0, y, 0), Quaternion.identity);
            Destroy(linez, 12);
            spawnCooldown = 0;
        }
    }
}
