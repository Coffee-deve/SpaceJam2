using UnityEngine;

public class PlanetGravitation : MonoBehaviour
{

    public Rocket rocket;

    public Rigidbody2D body;

    public float G = 0.1f; // Gravitational constant

    Vector2 atracctionForce(Rigidbody2D planet, Rigidbody2D rocket)
    {
        Vector2 direction = planet.position - rocket.position;
        float distance = direction.magnitude;
        if (distance == 0) return Vector2.zero; // Avoid division by zero
        float forceMagnitude = G * (planet.mass * rocket.mass) / (distance * distance);
        return direction.normalized * forceMagnitude;
    }

    void Start()
    {
        
    }

    void Update()
    {
        rocket.body.AddForce(atracctionForce(body, rocket.body) * Time.deltaTime);
    }
}
