using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerShape : MonoBehaviour
{
    public PlayerShape playerShape;
    public PlayerBehaviour player;
    public bool overrideDirection = false;
    public int newDirection = 0;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    public void setPlayerShape() {
        player.setRotationAngles(playerShape);
        if (overrideDirection) {
            player.setAngleIndex(newDirection);
        }
    }
}
