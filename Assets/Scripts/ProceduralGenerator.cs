using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    [SerializeField] private List<LevelData> levelDataList;
    private int seed;
    private int currentLevelIndex = 0;
    private int currentObjectIndex = 0;
    private LevelData currentLevelData;
    private Transform playerTransform;

    private void Awake()
    {
        seed = Random.Range(0, 1000);
        currentLevelIndex = seed % levelDataList.Count;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentLevelData = levelDataList[currentLevelIndex];
        GenerateLevel();
        StartCoroutine(CheckLevel());
    }

    private IEnumerator CheckLevel()
    {
        while (true)
        {
            GenerateLevel();
            yield return new WaitForSeconds(1);
        }
    }

    private void GenerateLevel()
    {
        float distance=Vector3.Distance(playerTransform.position, transform.position);
        if (distance < 100)
        {
            SpawnLevel();
            currentObjectIndex++;
            if (currentObjectIndex>=currentLevelData.levelPiecePrefab.Count)
            {
                currentObjectIndex = 0;
            }
            transform.position += Vector3.forward * 50;
        }
    }

    private void SpawnLevel()
    {
        GameObject obj = Instantiate(currentLevelData.levelPiecePrefab[currentObjectIndex]);
        Vector3 position = obj.transform.position;
        position.z = transform.position.z;
        obj.transform.position = position;
    }

}
