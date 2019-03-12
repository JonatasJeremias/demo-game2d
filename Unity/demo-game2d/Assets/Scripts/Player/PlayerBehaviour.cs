using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : FishBehaviour
{
    public float forceToSwiming = 10;
    private bool swimingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerifyInputs();
    }

    void FixedUpdate()
    {
        ControlRigidBodyVelocity();
        ControlRigidBodyRotate();
        SwimingFoword(1);

        if (swimingUp)
        {
            SwimingUp(forceToSwiming);
            swimingUp = false;
        }
    }

    private void VerifyInputs()
    {
        if (Input.GetMouseButton(0))
        {
            if (transform.position.y < maximumHeightForSwimming)
            {
                swimingUp = true;
            }
        }
    }
}
