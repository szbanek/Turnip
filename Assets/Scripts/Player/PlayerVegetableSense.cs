using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerVegetableSense : MonoBehaviour
{
    [SerializeField]
    [Range(0.00001f, 1)]
    private float fovMultiplier;
    [SerializeField]
    private float fovDuration;
    [SerializeField]
    private GameObject iconPrefab;

    private bool isSensing = false;
    private float standardFOV;
    private float fovSpeed;

    private float fovTarget;

    private PlayerStats playerStats;
    private Dictionary<VegetableInteractionController, InteractionIconController> activeIcons = new Dictionary<VegetableInteractionController, InteractionIconController>();

    private void Start()
    {
        standardFOV = Camera.main.fieldOfView;
        fovTarget = Camera.main.fieldOfView;
        fovSpeed = (standardFOV - standardFOV * fovMultiplier) / fovDuration;
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, fovTarget, fovSpeed * Time.deltaTime);

        if (!isSensing)
        {
            return;
        }

        Collider[] vegetables = Physics.OverlapSphere(transform.position, playerStats.SenseRange, LayerMask.GetMask("Vegetables"));
        var controllers = vegetables.Select(e => { return e.GetComponent<VegetableInteractionController>(); });
        foreach (VegetableInteractionController controller in controllers)
        {
            if (!activeIcons.ContainsKey(controller))
            {
                activeIcons.Add(controller, Instantiate(iconPrefab, UIHUDController.Instance.InteractionIconCanvas).GetComponent<InteractionIconController>());
                activeIcons[controller].ShowIcon(controller.VegetableIcon, controller.Position);
            }
        }
        List<VegetableInteractionController> toRemove = new List<VegetableInteractionController>();
        foreach (VegetableInteractionController controller in activeIcons.Keys)
        {
            if (!controllers.Contains(controller))
            {
                toRemove.Add(controller);
                activeIcons[controller].OnHideEvent += (e, _) => Destroy(((MonoBehaviour)e).gameObject);
                activeIcons[controller].HideIcon();
            }
        }
        foreach (var controller in toRemove)
        {
            activeIcons.Remove(controller);
        }
    }

    public void StartSense()
    {
        isSensing = true;
        fovTarget = standardFOV * fovMultiplier;
    }

    public void StopSense()
    {
        foreach (var icon in activeIcons)
        {
            icon.Value.OnHideEvent += (e, _) => Destroy(((MonoBehaviour)e).gameObject);
            icon.Value.HideIcon();
        }
        activeIcons.Clear();
        isSensing = false;
        fovTarget = standardFOV;
    }
}
