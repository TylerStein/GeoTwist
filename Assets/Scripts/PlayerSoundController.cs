using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public SoundEffectBehaviour changeDirectionSFX;
    public SoundEffectBehaviour turnSFX;
    public SoundEffectBehaviour shapeSFX;
    public SoundEffectBehaviour dieSFX;

    private bool mute = false;

    public void setMute(bool muted) {
        mute = muted;
    }

    public void onChangeDirection() {
       if (!mute) changeDirectionSFX.PlaySound();
    }

    public void onTurn() {
        if (!mute) turnSFX.PlaySound();
    }

    public void onChangeShape() {
        if (!mute) shapeSFX.PlaySound();
    }

    public void onDie() {
        if (!mute) dieSFX.PlaySound();
    }
}
