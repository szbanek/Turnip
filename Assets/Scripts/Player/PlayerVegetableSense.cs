using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerVegetableSense : MonoBehaviour
{
    [SerializeField]
    private GameObject linePrefab;
    [SerializeField]
    private float linesVisibilityDuration;
    [SerializeField]
    private float linesLength;

    private List<PlayerSenseLine> lines = new List<PlayerSenseLine>();

    private Coroutine currentCoroutine;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public void Sense()
    {
        if (currentCoroutine != null)
        {
            return;
        }

        Collider[] vegetables = Physics.OverlapSphere(transform.position, playerStats.SenseRange, LayerMask.GetMask("Vegetables"));
        foreach (Collider vegetable in vegetables)
        {
            PlayerSenseLine line = CreateLine(vegetable);
            lines.Add(line);
        }
        currentCoroutine = StartCoroutine(ClearLinesCoroutine());
    }

    private IEnumerator ClearLinesCoroutine()
    {
        yield return new WaitForSeconds(linesVisibilityDuration);
        foreach (PlayerSenseLine line in lines)
        {
            Destroy(line.gameObject);
        }
        lines.Clear();
        currentCoroutine = null;
    }

    private PlayerSenseLine CreateLine(Collider vegetable)
    {
        PlayerSenseLine line = Instantiate(linePrefab).GetComponent<PlayerSenseLine>();
        line.StartTransform = transform;
        line.EndTransform = vegetable.transform;
        line.Length = linesLength;
        return line;
    }
}
