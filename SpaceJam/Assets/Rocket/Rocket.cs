using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rocket : MonoBehaviour
{

    public float enginePower = 10;
    public bool isEngineOn = false;
    public bool isRotating = false;
    public float engineDirection = 0; // Angle in degree
    public float correctionFactor = 0.1f; // Factor to correct the angle drift

    public Rigidbody2D body;
    public GameObject obj;
    [SerializeField] private Animator animator;

    public Vector2 DegreeToVector(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
    
    void Start()
    {

    }

    void Update()
    {
        obj.transform.rotation = Quaternion.Euler(0, 0, engineDirection - 90);
        if (isEngineOn)
        {
            body.AddForce(DegreeToVector(engineDirection) * enginePower * Time.deltaTime);
            animator.SetBool("isAccelerating", true);
        }
        else
        {
            animator.SetBool("isAccelerating", false);
        }
    }

    private void LateUpdate()
    {
        Vector2 velocity = body.linearVelocity;
        if (velocity.magnitude > 0.1f && !isRotating)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            float normAngleDiff = (angle - engineDirection) / 360;
            if (normAngleDiff > 0)
            {
                engineDirection += normAngleDiff * correctionFactor;
            }
            else
            {
                engineDirection -= -normAngleDiff * correctionFactor;
            }
                
        }
    }
}

