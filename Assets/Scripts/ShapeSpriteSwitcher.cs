using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpriteSwitcher : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public PlayerShape activeShape;
    public int activeDirection = 0;
    public bool isAlive = true;
    public bool clockwise = true;

    public bool isDirty = false;
    public bool doneDying = false;

    private float deathAnimTime = 0f;
    public float deathDuration = 0.15f;
    int deathFrame = 0;

    public void setShapeSprites(PlayerShape shape) {
        activeShape = shape;
        isDirty = true;
    }

    public void setRotationDirection(bool cw) {
        clockwise = cw;
        isDirty = true;
    }

    public void setActiveDirection(int direction) {
        activeDirection = direction;
        isDirty = true;
    }

    public void setAlive(bool alive) {
        deathFrame = 0;
        deathAnimTime = 0;
        isAlive = alive;
        doneDying = false;

        if (!isAlive) {
            spriteRenderer.sprite = activeShape.deathSprites[deathFrame];
        } else {
            isDirty = true;
        }
    }

    public void updateSprite() {
        if (isDirty) {
            if (clockwise) spriteRenderer.sprite = activeShape.clockwiseSprites[activeDirection];
            else spriteRenderer.sprite = activeShape.counterClockwiseSprites[activeDirection];
            isDirty = false;
        }
    }

    private void Update() {
        if (isAlive) {
            if (isDirty) {
                if (clockwise) spriteRenderer.sprite = activeShape.clockwiseSprites[activeDirection];
                else spriteRenderer.sprite = activeShape.counterClockwiseSprites[activeDirection];
                isDirty = false;
            }
        } else {
            int spritesCount = activeShape.deathSprites.Length - 1;

            if (deathFrame < spritesCount) {
                float deathFrameTime = deathDuration / spritesCount;
                deathAnimTime += Time.deltaTime;

                if (deathAnimTime > deathFrameTime) {
                    deathAnimTime = 0;
                    deathFrame++;
                    spriteRenderer.sprite = activeShape.deathSprites[deathFrame];
                }
            } else {
                doneDying = true;
            }
        }
    }
}
