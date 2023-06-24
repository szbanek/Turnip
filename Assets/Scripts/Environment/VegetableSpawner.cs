using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class VegetableSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;
    [SerializeField]
    private float startSpawnPercent;

    private void Start()
    {
        if(Random.Range(0, 100) < startSpawnPercent)
        {
            SpawnVegetable();
        }
        else
        {
            StartSpawnCoroutine();
        }
    }

    private void SpawnVegetable()
    {
        VegetableInteractionController controller = Instantiate(prefab, transform.position, transform.rotation).GetComponent<VegetableInteractionController>();
        controller.OnPickedUp += OnVegetablePickedUp;
    }

    private void StartSpawnCoroutine()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        SpawnVegetable();
    }

    private void OnVegetablePickedUp(object sender, System.EventArgs e)
    {
        StartSpawnCoroutine();
        ((VegetableInteractionController)sender).OnPickedUp -= OnVegetablePickedUp;
    }
}
