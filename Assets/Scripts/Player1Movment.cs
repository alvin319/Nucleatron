using UnityEngine;

public class Player1Movment : MonoBehaviour
{
    public float Speed;

    public Vector2 Velocity;

    public const float Deceleration = 0.95f;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Velocity += Vector2.up*Speed*Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Velocity += -Vector2.up * Speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Velocity += -Vector2.right * Speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Velocity += Vector2.right * Speed * Time.fixedDeltaTime;
        }
        transform.Translate(Velocity);
        Velocity -= Velocity*Deceleration;
    }
}
