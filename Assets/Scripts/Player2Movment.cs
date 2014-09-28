using UnityEngine;
using System.Collections;

public class Player2Movment : MonoBehaviour {

    public float Speed;

    public Vector2 Velocity;

    public const float Deceleration = 0.95f;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Velocity += Vector2.up * Speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Velocity += -Vector2.up * Speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Velocity += Vector2.right * Speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Velocity += -Vector2.right * Speed * Time.fixedDeltaTime;
        }
        transform.Translate(Velocity);
        Velocity -= Velocity * Deceleration;
    }
}
