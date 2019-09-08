using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public Transform pupilRoot;
    public Transform pupilTransform;

    public float maxPupilRadius = 0.15f;

    public float pupilRotateRate = 2.0f;
    public float pupilRadiusRate = 2.0f;

    public float currentPupilAngle = 0f;
    public float currentPupilRadius = 0f;

    public bool rotateClockwise = true;
    public bool isRotating = false;
    
    [SerializeField] private Vector3 pupilRotationOffset = Vector3.zero;

    public SpriteRenderer eyelidRenderer;
    public Sprite[] eyelidSprites;
    public int eyelidSpriteFrame;
    public float blinkDuration = 0.1f;
    public float blinkTimer = 0f;
    public bool isBlinking = false;

    // Update is called once per frame
    void Update()
    {
        pupilRotationOffset.Set(Mathf.Sin(currentPupilAngle), Mathf.Cos(currentPupilAngle), 0);
        pupilTransform.position = pupilRoot.position + pupilRotationOffset * currentPupilRadius;

        if (isBlinking) {
            int spritesCount = eyelidSprites.Length;
            float blinkFrameTime = blinkDuration / spritesCount;
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= blinkFrameTime) {
                eyelidSpriteFrame++;
                blinkTimer = 0;
                if (eyelidSpriteFrame >= spritesCount) {
                    eyelidSpriteFrame = 0;
                    isBlinking = false;
                }

                eyelidRenderer.sprite = eyelidSprites[eyelidSpriteFrame];
            }
        }
    }

    public void pupilLookAt(float angle, float radiusAmount = 1f) {
        if (angle > 360 || angle < 0) angle = 0;

        currentPupilAngle = angle;
        currentPupilRadius = maxPupilRadius * radiusAmount;
    }

    public void blink() {
        isBlinking = true;
        blinkTimer = 0f;
    }
}
