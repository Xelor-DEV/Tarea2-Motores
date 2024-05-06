using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnRate;
    [SerializeField] private float limitInferior;
    [SerializeField] private float limitSuperior;

    void Start()
    {
        SetMinMax();
        StartCoroutine(SpawnEnemies());
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    IEnumerator SpawnEnemies()
    {
        bool execute = true;
        while (execute == true)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, enemies.Length);
            float spawnYPosition = Random.Range(limitInferior, limitSuperior);
            Vector3 spawnPosition = new Vector3(transform.position.x, spawnYPosition, 0);
            Instantiate(enemies[randomIndex], spawnPosition, Quaternion.identity);
        }
    }
}
