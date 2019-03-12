using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    public float maximumHeightForSwimming = 4.5f;
    public float maximumVelocityForSwimming = 3.5f;
    public float degressToRotate = 10;
    public float speedToSwiming;

    public GameObject meshObject;
     
    // Components
    protected new Rigidbody2D rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    void Awake()
    {
        LoadOwnComponents();
    }

    void FixedUpdate()
    {
        //rigidbody2D.AddForce(Vector2.right * speedToSwiming, ForceMode2D.Force);
    }

    private void LoadOwnComponents()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void ControlRigidBodyVelocity()
    {
        if (rigidbody2D.velocity.y < maximumVelocityForSwimming * -1)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x , maximumVelocityForSwimming * -1);
    }

    protected void ControlRigidBodyRotate()
    {
        meshObject.transform.rotation = Quaternion.Euler(0, 0, rigidbody2D.velocity.y * degressToRotate);
    }

    protected void SwimingUp(float forceToSwiming)
    {
        if (transform.position.y < maximumHeightForSwimming)
        {
            rigidbody2D.AddRelativeForce(Vector2.up * forceToSwiming, ForceMode2D.Force);

            if (rigidbody2D.velocity.y > maximumVelocityForSwimming)
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maximumVelocityForSwimming);
        }
    }

    protected void SwimingFoword(float move)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * speedToSwiming * 10f * Time.fixedDeltaTime, rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}
