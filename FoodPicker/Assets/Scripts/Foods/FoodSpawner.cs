using System.Collections;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private FoodsData foodsData;
    [SerializeField] private float timeDelay = 4f;
    [SerializeField] Transform spawnPoint;

    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            Instantiate(foodsData.FoodsSettings.Food[Random.Range(0, foodsData.FoodsSettings.Food.Length)], spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(timeDelay);
        }
    }
}
