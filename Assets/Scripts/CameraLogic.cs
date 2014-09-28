using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CameraLogic : MonoBehaviour
{
    public float CameraSpeed;

    public Collider2D Bound;

    public float CurrnetBoundMinX;
	public float CurrnetBoundMaxX;
	public float CurrnetBoundMinY;
	public float CurrnetBoundMaxY;

    public float FreezeCoolDown;
    public float FreezeCoolDownTimer;

	void Start ()
	{
	    Bound = GetComponent<Collider2D>();
	    FreezeCoolDownTimer = FreezeCoolDown;
	}

    void FixedUpdate()
    {
        UpdateBound();
        if (FreezeCoolDownTimer > 0f)
        {
            FreezeCoolDownTimer -= Time.fixedDeltaTime;
            return;
        }
        transform.Translate(0, CameraSpeed * Time.fixedDeltaTime, 0);
    }

    void UpdateBound()
    {
        CurrnetBoundMinX = Bound.bounds.min.x;
        CurrnetBoundMaxX = Bound.bounds.max.x;
        CurrnetBoundMinY = Bound.bounds.min.y;
        CurrnetBoundMaxY = Bound.bounds.max.y;
    }

    public void ResetFreeze()
    {
        FreezeCoolDownTimer = FreezeCoolDown;
    }
}
