using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tile[] tilePrefabs;
    public Transform emptyTile;
    private Camera _camera;
    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        Application.targetFrameRate = 90;
        QualitySettings.vSyncCount = 0;
    }
    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }


   public void OnTileClick(Tile tile)
{
    RectTransform emptyRect = emptyTile.GetComponent<RectTransform>();

    if (Vector2.Distance(emptyRect.anchoredPosition, tile.targetPosition) < 201)
    {

        Vector2 lastEmptyPos = emptyRect.anchoredPosition;

        emptyRect.anchoredPosition = tile.targetPosition;
        tile.targetPosition = lastEmptyPos;
    }
}


    private void Shuffle()
    {
        for (int i = 0; i < tilePrefabs.Length; i++)
        {
            if (tilePrefabs[i] != null)
            {
                int randomIndex = Random.Range(0, 15);
                Vector2 lastPos = tilePrefabs[i].targetPosition;
                tilePrefabs[i].targetPosition = tilePrefabs[randomIndex].targetPosition;
                tilePrefabs[randomIndex].targetPosition = lastPos;

            }

        }

    }
}
