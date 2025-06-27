using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Vector2 targetPosition;
    [SerializeField]private Vector2 correctPosition;
    private SpriteRenderer _sprite;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
        correctPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        if (targetPosition == correctPosition)
        {
            _sprite.color = Color.green;
        }
        else
        {
            _sprite.color = Color.white;
        }
    }
}
