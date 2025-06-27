using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace;
    private Camera _camera;
    [SerializeField] private TileScript[] tiles;
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
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 2)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TileScript thisTile = hit.transform.GetComponent<TileScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                }
            }
        }
    }

    public void Shuffle()
    {
        for (int i=0;i<14;i++) {
            if (tiles[i] != null)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 14);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
            }
        }
    }
}
