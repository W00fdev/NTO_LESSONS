using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public Transform TargetTransform;
    public Transform PlayerTransform;

    public float UpdateTickTime;

    public float Radius;
    public float MapRadius;

    private RectTransform _rect;

    void Start()
    {
        _rect = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        Vector2 PlayerPositionXZ = new Vector2(PlayerTransform.position.x, PlayerTransform.position.z);

        Vector2 TargetPositionXZ = new Vector2();
        TargetPositionXZ.x = TargetTransform.position.x;
        TargetPositionXZ.y = TargetTransform.position.z;

        Vector2 CameraDirectionXZ = new Vector2();
        CameraDirectionXZ.x = Camera.main.transform.forward.x;
        CameraDirectionXZ.y = Camera.main.transform.forward.z;

        float angle = Vector2.SignedAngle(CameraDirectionXZ, TargetPositionXZ - PlayerPositionXZ) + 90f;
        angle = Mathf.Deg2Rad * angle;

        float distance = Vector2.Distance(PlayerPositionXZ, TargetPositionXZ);
        float distanceNormalized = Mathf.Clamp(distance / MapRadius, -1f, 1f);
        float radarPosition = distanceNormalized * Radius;

        _rect.anchoredPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radarPosition;
    }

}
