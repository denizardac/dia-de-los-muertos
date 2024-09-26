
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PropObject : MonoBehaviour
{
    [SerializeField]Prop prop;
    [SerializeField]SpriteRenderer spriteRenderer;
   
    public bool IsEnemy {get; private set;}

    public bool RotateClockWise;

    void Start()
    {
        if ( Random.Range(0f,1f) > 0.5f)
        {
            RotateClockWise = true;
        }
    }
    void Awake()
    {
    BoxCollider2D collider = GetComponent<BoxCollider2D>();
    collider.isTrigger = true; 
    }
    public void SetProp(Prop _prop)
    {
        spriteRenderer.sprite = _prop.Visual;
        IsEnemy = prop.Enemy;
    }

    void Update()
    {
        if(transform.position.y < -2f ) {
            Destroy(gameObject);
        }

        if(RotateClockWise==true)
        {
            transform.Rotate(Vector3.forward,150f*Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward,-150f*Time.deltaTime);
        }
    }
}
