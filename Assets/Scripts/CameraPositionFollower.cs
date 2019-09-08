using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionFollower : MonoBehaviour
{
    public Transform target;
    public new Transform transform;
    public float moveSpeed = 2.0f;


    private void Start() {
        transform = GetComponent<Transform>();
    }

    public void SetTarget(Transform target) {
        this.target = target;
    }

    private void Update() {
        if (target != null) transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed);
    }
}
