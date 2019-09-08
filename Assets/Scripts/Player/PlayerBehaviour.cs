using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    public ShapeSpriteSwitcher spriteSwitcher;
   // public ParticleSystem boostParticleSystem;
   // public Transform boostParticlePivot;
    public EyeController eyeController;
    public Transform spawnPoint;
    public CharacterShadow characterShadow;
    public PlayerSoundController soundController;

    public SetSpawnTrigger spawnTrigger;

    public PlayerShape levelDefaultShape;
    public int levelDefaultDirection = 0;
    public bool levelDefaultClockwise = true;

    [Header("Movement Velocity")]
    public float baseVelocity = 3f;
    public float afterTurnVelocity = 4f;
    public float velocityReturnRate = 1f;

    [Header("Rotation Angles")]
    public PlayerShape triangleAngles = null;
    public PlayerShape squareAngles = null;
    public PlayerShape pentagonAngles = null;
    public PlayerShape hexagonAngles = null;
    public PlayerShape octagonAngles = null;

    private bool rotateClockwise = true;
    [SerializeField] private float currentVelocity = 0f;
    private Vector2 moveDirection = Vector2.up;
    [SerializeField] private int angleIndex = 0;
    [SerializeField] private float angleDeg = 0;
    private float angleRad = 0;
    [SerializeField] private PlayerShape currentShape = null;

    private new Rigidbody2D rigidbody = null;
    private new Transform transform = null;

    [SerializeField] private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        soundController.setMute(true);
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        rigidbody.freezeRotation = true;
        if (levelDefaultShape == null) levelDefaultShape = squareAngles;
        angleIndex = levelDefaultDirection;
        rotateClockwise = levelDefaultClockwise;
        currentShape = levelDefaultShape;

        setRotationAngles(currentShape);
        updateFacingDirection();
        soundController.setMute(false);
    }

    // Update is called once per frame
    void Update()
    {
      //  rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;

        if (isAlive) {
            bool didTouch = false;
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                didTouch = touch.phase == TouchPhase.Began;
            }
            
            bool switchAngle = Input.GetButtonDown("Fire1") || didTouch;

            if (switchAngle) {
                if (rotateClockwise) angleIndex++;
                else angleIndex--;

                if (angleIndex >= currentShape.angles.Length) angleIndex = 0;
                else if (angleIndex < 0) angleIndex = currentShape.angles.Length - 1;

                updateFacingDirection();
                currentVelocity = afterTurnVelocity;

                //  boostParticleSystem.Play();
            }

            moveForward();

            if (currentVelocity > baseVelocity) {
                currentVelocity -= Time.deltaTime * velocityReturnRate;
                if (currentVelocity < baseVelocity) currentVelocity = baseVelocity;
            } else if (currentVelocity < baseVelocity) {
                currentVelocity += Time.deltaTime * velocityReturnRate;
            }
        } else {
            rigidbody.velocity = Vector2.zero;
            if (!spriteSwitcher.isAlive && spriteSwitcher.doneDying) {
                soundController.setMute(true);
                spriteSwitcher.setAlive(true);
                spriteSwitcher.updateSprite();
                isAlive = true;
                setRotationAngles(levelDefaultShape);
                angleIndex = levelDefaultDirection;
                updateFacingDirection();
                setRotationDirection(levelDefaultClockwise);
                transform.position = spawnPoint.position;
                soundController.setMute(false);
                spawnTrigger.onRespawn();
            }
        }
    }

    public void toggleRotationDirection() {
        rotateClockwise = !rotateClockwise;
        spriteSwitcher.setRotationDirection(rotateClockwise);
        spriteSwitcher.updateSprite();
        eyeController.blink();
        soundController.onChangeDirection();
    }

    public void setRotationDirection(bool clockwise) {
        rotateClockwise = clockwise;
        spriteSwitcher.setRotationDirection(rotateClockwise);
        spriteSwitcher.updateSprite();
        eyeController.blink();
        soundController.onChangeDirection();
    }

    public void setRotationAngles(PlayerShape definition) {
        currentShape = definition;
        if (angleIndex >= currentShape.angles.Length) angleIndex = 0;
        else if (angleIndex < 0) angleIndex = currentShape.angles.Length - 1;
        spriteSwitcher.setShapeSprites(definition);
        spriteSwitcher.setActiveDirection(angleIndex);
        spriteSwitcher.updateSprite();
        eyeController.pupilLookAt(angleRad, 1f);
        characterShadow.setShape(definition.type);
        eyeController.blink();
        soundController.onChangeShape();
    }

    public void setRotationAnglesShape(ERotationAngle rotationAngle) {
        switch(rotationAngle) {
            case ERotationAngle.TRIANGLE:
                setRotationAngles(triangleAngles);
                break;
            case ERotationAngle.SQUARE:
                setRotationAngles(squareAngles);
                break;
            case ERotationAngle.PENTAGON:
                setRotationAngles(pentagonAngles);
                break;
            case ERotationAngle.HEXAGON:
                setRotationAngles(hexagonAngles);
                break;
            case ERotationAngle.OCTAGON:
                setRotationAngles(octagonAngles);
                break;
        }
    }

    public void setSpawnTransform(Transform spawn) {
        spawnPoint = spawn;
    }

    public void setSpawnShape(PlayerShape shape, int direction = 0, bool clockwise = true) {
        levelDefaultShape = shape;
        levelDefaultDirection = direction;
        levelDefaultClockwise = clockwise;
    }

    public void setAngleIndex(int index) {
        angleIndex = index;
        if (angleIndex >= currentShape.angles.Length) angleIndex = 0;
        else if (angleIndex < 0) angleIndex = currentShape.angles.Length - 1;
        updateFacingDirection();
        currentVelocity = afterTurnVelocity;
    }

    private void updateFacingDirection() {
        // rigidbody.freezeRotation = false;
        angleDeg = currentShape.angles[angleIndex];
        angleRad = angleDeg * Mathf.Deg2Rad;
        // boostParticlePivot.transform.eulerAngles = new Vector3(boostParticlePivot.eulerAngles.x, boostParticlePivot.eulerAngles.y, angleDeg);
        // (Vector3.forward, angleDeg, Space.World);

        // boostParticlePivot.Rotate(Vector3.forward, angleDeg, Space.World);
        moveDirection.Set(Mathf.Sin(angleRad), Mathf.Cos(angleRad));
       // rigidbody.SetRotation(angleDeg);
       // rigidbody.freezeRotation = true;

        spriteSwitcher.setActiveDirection(angleIndex);
        spriteSwitcher.setRotationDirection(rotateClockwise);
        spriteSwitcher.updateSprite();
        eyeController.pupilLookAt(angleRad, 1f);
        soundController.onTurn();

    }

    private void moveForward() {
        rigidbody.velocity = moveDirection * currentVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "RespawnCollider") {
            isAlive = false;
            spriteSwitcher.setAlive(false);
            spriteSwitcher.updateSprite();
            soundController.onDie();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {

    }
}
