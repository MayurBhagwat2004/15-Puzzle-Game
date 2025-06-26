using UnityEngine;
using TMPro;
public class TilesGenerator : MonoBehaviour
{
    public GameManager gameManager;
    bool randomNumUsed;
<<<<<<< HEAD
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
=======
    [SerializeField]float xOffset;
    [SerializeField]float yOffset;
>>>>>>> d1e0e2f6b6694b7425f6036bd6ce34baaaeb4342
    float spacingX = 100f;
    float spacingY = 100f;
    [SerializeField] private GameObject tile;
    public GameObject[,] tiles = new GameObject[4, 4]; //creating a tileset of 3x3 order

    void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            AssignAllTiles();
        }
    }

    private void AssignAllTiles()
    {
        Vector2 pos;
        int count = 1;
        TextMeshProUGUI text;
<<<<<<< HEAD
        int emptyTileX, emptyTileY;
        emptyTileX = Random.Range(0, 4);
        emptyTileY = Random.Range(0, 4);
=======
        int randomTileX,randomTileY;
        randomTileX = Random.Range(0,4);
        randomTileY = Random.Range(0,4);
>>>>>>> d1e0e2f6b6694b7425f6036bd6ce34baaaeb4342
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
<<<<<<< HEAD
                if (i == emptyTileX && j == emptyTileY)
                {
                    tiles[i, j] = null;
=======
                if ((i == randomTileY || j == randomTileX) && !randomNumUsed)
                {
                    randomNumUsed = true;
>>>>>>> d1e0e2f6b6694b7425f6036bd6ce34baaaeb4342
                    continue;
                }
                else
                {
                    pos = new Vector2(i * spacingX, j * spacingY);
                    tiles[i, j] = Instantiate(tile, pos, Quaternion.identity, gameObject.transform);
                    text = tiles[i, j].GetComponentInChildren<TextMeshProUGUI>();
                    text.text = count.ToString();
                    count++;

                }
            }
        }
        gameObject.transform.position = new Vector2(xOffset, yOffset);
    }

    void Update()
    {

    }
}
