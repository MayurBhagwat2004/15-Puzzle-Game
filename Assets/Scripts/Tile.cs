using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Vector2 correctPosition;
    private RawImage spriteRenderer;
    public Vector2 targetPosition;

    private RectTransform rectTransform;

    void Awake()
    {
        spriteRenderer = GetComponent<RawImage>();
        rectTransform = GetComponent<RectTransform>();

        // store everything in anchored space
        correctPosition = rectTransform.anchoredPosition;
        targetPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) > 0.1f)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition,targetPosition,0.2f);
        }


        // compare using Vector2.Distance to avoid floating-point error
        if (Vector2.Distance(targetPosition, correctPosition) < 1f)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameManager.Instance.OnTileClick(this);
    }
}
