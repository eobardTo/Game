using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private float timeBetweenWaves = 3f;    
    [SerializeField] private float enemyMult; 
    

    [SerializeField] private float radius = 5f;
    [SerializeField] private float innerRadius = 4f;
    [SerializeField] private Vector3 originPoint = Vector3.zero;

    [Header("Components")]

    [SerializeField] GameObject enemy;
    [SerializeField] Animator waveAnim;


    [SerializeField] public int waveCount = 1;
    [SerializeField] private float checkInterval = 2;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave() {

        while (true)
        {
            
            yield return new WaitForSeconds(checkInterval); 
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0) {
            	
                GameController.Instance.WaveCount(waveCount);
                yield return new WaitForSeconds(timeBetweenWaves);

                SpawnEnemies();

            } 
                
        }
        
    }

    private void SpawnEnemies() {

        for (int i = 0; i < waveCount * enemyMult; i++)
        {

            Vector2 spawnpos = new Vector2(Random.Range(0, radius), Random.Range(0, radius));

            while (Vector2.Distance(Vector2.zero,spawnpos) < innerRadius) {
                spawnpos = new Vector2(Random.Range(0, radius), Random.Range(0, radius));
            }

            if (Random.Range(0, 100) > 50)
            {
                spawnpos = -spawnpos;
            }

            Instantiate(enemy, spawnpos, new Quaternion(0, 0, 0, 0));
        }

        waveCount++;

    }

}
