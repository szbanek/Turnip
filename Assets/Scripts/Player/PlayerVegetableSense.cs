using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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
    [SerializeField]
    private PostProcessVolume postProcessVolume;

    private bool isSensing = false;
    private float standardFOV;

    private float fovTarget;

    private float maxAngle = 120;

    private PlayerStats playerStats;
    private Dictionary<VegetableInteractionController, InteractionIconController> activeIcons = new Dictionary<VegetableInteractionController, InteractionIconController>();

    private void Start()
    {
        standardFOV = Camera.main.fieldOfView;
        fovTarget = Camera.main.fieldOfView;
        playerStats = GetComponent<PlayerStats>();
        postProcessVolume.weight = 0;
    }

    private void Update()
    {
        float fovSpeed = (standardFOV - standardFOV * fovMultiplier) / fovDuration;
        float postProcessSpeed = 1 / fovDuration;
        Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, fovTarget, fovSpeed * Time.deltaTime);
        postProcessVolume.weight = Mathf.MoveTowards(postProcessVolume.weight, isSensing ? 1 : 0, postProcessSpeed * Time.deltaTime);

        if (!isSensing)
        {
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, playerStats.SenseRange, LayerMask.GetMask("Vegetables"));
        var vegetables = colliders.Where(x =>
        {
            Vector3 vegetablePosition = x.transform.position - transform.position;
            vegetablePosition.y = 0;
            return Vector3.Angle(transform.forward, vegetablePosition.normalized) <= maxAngle;
        });
        var controllers = vegetables.Select(e => { return e.GetComponent<VegetableInteractionController>(); });
        foreach (VegetableInteractionController controller in controllers)
        {
            if (controller == null)
            {
                continue;
            }
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
