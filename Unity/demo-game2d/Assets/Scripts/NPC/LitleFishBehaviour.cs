using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitleFishBehaviour : FishBehaviour
{
    public Transform gameObjectToFallow;
    public Transform floor;
    public float marginFloor;
    public float RandomicFactorValue = 1.7f;
    public float forceToSwiming = 10;

    private Vector3 fishStartPosition;
    private Vector3 startPositionObjectToFallow;
    private float startDistance;

    // Start is called before the first frame update
    void Start()
    {
        fishStartPosition = transform.position;
        startPositionObjectToFallow = gameObjectToFallow.position;

        startDistance = Vector3.Distance(fishStartPosition, startPositionObjectToFallow);
    }

    void FixedUpdate()
    {
        ControlRigidBodyVelocity();
        ControlRigidBodyRotate();
        if ((transform.position.y < gameObjectToFallow.position.y && RandomicBehaviourSwimingOrNot())
            || transform.position.y < floor.position.y + marginFloor)
            SwimingUp((float)(forceToSwiming * (GetRandomDoubleValue() + 1)));
        // changeDistance();
    }

    private bool RandomicBehaviourSwimingOrNot()
    {
        if (RandomicFactorValue <= 0)
            return true;

        if (GetRandomDoubleValue() < 1 / RandomicFactorValue)
            return true;

        return false;
    }

    private void changeDistance()
    {
        if (Vector3.Distance(transform.position, gameObjectToFallow.position) > startDistance)
            transform.Translate(Vector3.forward * forceToSwiming * Time.deltaTime);
        else
            transform.Translate(Vector3.forward * (forceToSwiming * -1) * Time.deltaTime);
    }

    private double GetRandomDoubleValue()
    {
        System.Random random = new System.Random();
        return random.NextDouble();
    }
}
