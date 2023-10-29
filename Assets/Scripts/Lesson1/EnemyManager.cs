using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> Enemies;
    public List<Transform> SpawnPoints;

    public GameObject EnemyPrefab;
    public int EnemyToSpawnCount;

    private Enemy _boss;

    public void PowerupEnemies()
    {
        for (int i = 0; i < EnemyToSpawnCount; i++)
        {
            GameObject newEnemy = Instantiate(EnemyPrefab, SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Quaternion.identity);
            Enemies.Add(newEnemy.transform);
        }

        foreach (Transform enemy in Enemies)
            enemy.transform.localScale = Vector3.one * 2;

        ChooseBoss();
    }

    public void DebuffEnemies()
    {
        foreach (Transform enemy in Enemies)
            enemy.transform.localScale = Vector3.one;


        DechooseBoss();
    }

    private void ChooseBoss()
    {
        _boss = Enemies[Random.Range(0, Enemies.Count)].GetComponent<Enemy>();
        _boss.IsBoss = true;
    }

    private void DechooseBoss()
    {
        _boss.IsBoss = false;
    }
}