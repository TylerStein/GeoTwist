using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBlockBehaviour : MonoBehaviour
{
    public Transform spinRoot;

    public float maxSpinRate = 1f;
    public float spinAcceleration = 5f;
    public float spinBraking = 10f;

    public bool clockwise = true;
    public bool active = true;

    public float currentSpinRate = 0f;

    // Update is called once per frame
    void Update()
    {
        if (active) {
            if (clockwise) {
                if (currentSpinRate < maxSpinRate) {
                    currentSpinRate += Time.deltaTime * spinAcceleration;
                    if (currentSpinRate > maxSpinRate) currentSpinRate = maxSpinRate;
                } else if (currentSpinRate > maxSpinRate) {
                    currentSpinRate -= Time.deltaTime * spinBraking;
                }
            } else {
                if (currentSpinRate > -maxSpinRate) {
                    currentSpinRate -= Time.deltaTime * spinAcceleration;
                    if (currentSpinRate < -maxSpinRate) currentSpinRate = -maxSpinRate;
                } else if (currentSpinRate < -maxSpinRate) {
                    currentSpinRate += Time.deltaTime * spinBraking;
                }
            }
        } else {
            if (currentSpinRate > 0) {
                currentSpinRate -= Time.deltaTime * spinBraking;
                if (currentSpinRate < 0) currentSpinRate = 0;
            } else if (currentSpinRate < 0) {
                currentSpinRate += Time.deltaTime * spinBraking;
                if (currentSpinRate > 0) currentSpinRate = 0;
            }
        }

        spinRoot.Rotate(Vector3.forward, currentSpinRate * Mathf.Deg2Rad, Space.World);
    }

    void stopSpin() {
        currentSpinRate = 0f;
    }
}
