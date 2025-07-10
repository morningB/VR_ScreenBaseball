using UnityEngine;

public abstract class Ball : MonoBehaviour, IBallDestroy
{
    [SerializeField] protected BallData ballData;
    public Vector3 direction { get; set; }
    protected Rigidbody rb;

    public virtual void Initialize(BallData data)
    {
        ballData = data;
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Throw(Vector3 throwDirection)
    {
        direction = throwDirection.normalized;
        if (rb != null)
        {
            rb.linearVelocity = direction * ballData.speed;
        }
    }

    protected abstract void Move();
    
    private void Update()
    {
        Move();
    }

    void OnCollisionEnter(Collision collision)
    {
        var hittable = collision.gameObject.GetComponent<IHittable>();

        if (hittable != null)
        {
            //Debug.Log("공맞음");
            Vector3 reflectedDir = Vector3.Reflect(direction, collision.contacts[0].normal);
            direction = reflectedDir.normalized;
            if (rb != null)
            {
                rb.linearVelocity = -direction * ballData.speed;
            }
            hittable.OnHit(-direction, this);
        }
    }

    public void BallDestroy()
    {
        Destroy(gameObject);
    }
}