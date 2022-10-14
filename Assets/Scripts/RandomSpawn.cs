using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject somePrefab;
    public float Radius = 5.0f;
    public static int countCoins;

    private void Start()
    {
        countCoins = Random.Range(5, 8);
        for (int i = 0; i < countCoins; i++)
        {
            Vector3 randomPos = Random.insideUnitCircle * Radius;
            Instantiate(somePrefab, randomPos, Quaternion.identity);
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(this.transform.position, new Vector3(3, 5, 5));
    }
}
