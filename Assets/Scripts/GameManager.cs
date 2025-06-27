using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tile[] tilePrefabs;
    public Transform emptyTile;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D raycast = Physics2D.Raycast(ray.origin, ray.direction);
            if (raycast)
            {
                if (Vector2.Distance(emptyTile.position, raycast.transform.position) < 2)
                {
                    Vector2 lastEmptySpacePosition = emptyTile.position;
                    Tile tile = raycast.transform.GetComponent<Tile>();
                    emptyTile.position = tile.targetPosition;
                    tile.targetPosition = lastEmptySpacePosition;
                }
            }
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
