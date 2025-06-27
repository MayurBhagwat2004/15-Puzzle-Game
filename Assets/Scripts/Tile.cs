using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Vector2 correctPosition;
    private SpriteRenderer spriteRenderer;
    public Vector2 targetPosition;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        correctPosition = transform.position;
        targetPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, targetPosition, 0.05f);
        if (targetPosition == correctPosition)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.white;
            
        }
    }
}
