using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private AudioSource audioSource;
    private AudioClip[] audioClips;
    public Tile[] tilePrefabs;
    public Transform emptyTile;
    private Camera _camera;

    public bool tilesAssigned;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        Application.targetFrameRate = 90;
        QualitySettings.vSyncCount = 0;
        tilePrefabs = new Tile[15];
    }
    void Start()
    {
        // audioSource.clip = audioClips[0];
        // audioSource.Play();
        _camera = Camera.main;
        Shuffle();
    }

    private void Update()
    {
        if (tilesAssigned) //Checking if the all the tiles are assigned or not using flag variable
            return;
        else
            AssignTiles();  //Calling the assigning method
    }

    public bool AssignTiles()
    {
        if (tilesAssigned) //Flag assigned if the tiles are added to the gameManager
            return true;

        GameObject tilesParent = GameObject.FindWithTag("TilesParent");
        if (tilesParent != null) //Checks if the tilesParent is found or not
        {
            for (int i = 0; i < 15; i++)
            {
                Tile tile = tilesParent.transform.GetChild(i).GetComponent<Tile>();
                tilePrefabs[i] = tile; //Assigns the tiles to the array of tiles
            }
            emptyTile = GameObject.Find("EmptyTile").GetComponent<Transform>();
            if (emptyTile != null)
            {
                tilesAssigned = true; //Setting the flag to true if all tiles are found and assigned in gameManager
                Shuffle(); //Calling the shuffling method to randomly place tiles
                return true;
            }
            else
            {
                tilesAssigned = false; //If the empty tile is not found then setting the flag to false
                return false;
            }            
        }
        else
        {
            return true;
        }
    }


    public void OnTileClick(Tile tile)
    {
        RectTransform emptyRect = emptyTile.GetComponent<RectTransform>(); //Getting the transform of empty tile

        if (Vector2.Distance(emptyRect.anchoredPosition, tile.targetPosition) < 201)
        {

            Vector2 lastEmptyPos = emptyRect.anchoredPosition;

            emptyRect.anchoredPosition = tile.targetPosition; //Assigning the empty tile position to adjacent tile position
            tile.targetPosition = lastEmptyPos; //Assigning the current selected tile position to empty tile position
        }
    }


    private void Shuffle()
    {
        for (int i = 0; i < tilePrefabs.Length; i++)
        {
            if (tilePrefabs[i] != null)
            {
                int randomIndex = Random.Range(0, 15);
                Vector2 lastPos = tilePrefabs[i].targetPosition;    //Assigning the tile position
                tilePrefabs[i].targetPosition = tilePrefabs[randomIndex].targetPosition; //Assigning the selected tile position to randomly selected tile position
                tilePrefabs[randomIndex].targetPosition = lastPos; //Assigning the randomly selected tile position to the previously selected tile

            }

        }

    }

    public void Sound()
    {
        
    }
}
