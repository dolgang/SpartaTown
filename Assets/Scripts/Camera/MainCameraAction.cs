using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject Target;

    public float offsetX = 0.0f;
    public float offsetY = 0.0f;

    public float CameraSpeed = 10.0f;
    Vector3 TargetPos;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            -10
            );

        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}
