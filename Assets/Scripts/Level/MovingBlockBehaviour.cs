using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockBehaviour : MonoBehaviour
{
    public bool loopMove = false;
    public bool loopForward = true;

    public float moveSpeed = 2f;

    public Transform block = null;

    public int targetIndex = 0;
    public int lastIndex = 0;
    public float interpDist = 0;

    public Transform[] targets = new Transform[0];

    public bool isAtTarget = false;

    // Start is called before the first frame update
    void Start() {

    }

    public void setLooping(bool loop) {
        loopMove = loop;
    }

    public void moveToNext() {
        moveToTarget(targetIndex + 1);
    }

    public void moveToPrev() {
        moveToTarget(targetIndex - 1);
    }

    private void moveToTarget(int index) {
        if (index == targetIndex) return;

        if (index < 0) index = targets.Length - 1;
        else if (index >= targets.Length) index = 0;

        lastIndex = targetIndex;
        targetIndex = index;
        updateIsAtTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAtTarget) {
            block.transform.position = Vector3.Lerp(targets[lastIndex].transform.position, targets[targetIndex].transform.position, interpDist);
            updateIsAtTarget();
            interpDist += Time.deltaTime * moveSpeed;
        } else {
            interpDist = 0;
            if (loopMove) {
                if (loopForward) moveToNext();
                else moveToPrev();
            }
        }
    }

    void updateIsAtTarget() {
        isAtTarget = Mathf.Approximately(getDistanceToTarget(), 0);
    }

    float getDistanceToTarget() {
        return Vector3.Distance(block.transform.position, targets[targetIndex].transform.position);
    }
}
