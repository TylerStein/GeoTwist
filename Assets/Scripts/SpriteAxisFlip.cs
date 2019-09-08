using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAxisFlip : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public void setX(bool flip) {
        spriteRenderer.flipX = flip;
    }
    public void setY(bool flip) {
        spriteRenderer.flipY = flip;
    }

    public void flipX() {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void flipY() {
        spriteRenderer.flipY = !spriteRenderer.flipY;
    }
}
