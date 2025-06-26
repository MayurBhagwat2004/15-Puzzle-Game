using UnityEngine;
using TMPro;
public class TilesGenerator : MonoBehaviour
{
    public GameManager gameManager;
    bool randomNumUsed;
    [SerializeField]float xOffset;
    [SerializeField]float yOffset;
    float spacingX = 100f;
    float spacingY = 100f;
    [SerializeField] private GameObject tile;
    public GameObject[,] tiles = new GameObject[4,4]; //creating a tileset of 3x3 order

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

    int emptyRow = Random.Range(0, 4);
    int emptyCol = Random.Range(0, 4);

    for (int row = 0; row < 4; row++)
    {
        for (int col = 0; col < 4; col++)
        {
            if (row == emptyRow && col == emptyCol)
            {
                gameManager.currentEmptyTileRow = row;
                gameManager.currentEmptyTileCol = col;
                tiles[row, col] = null;
                continue;
            }

            int flippedRow = 3 - row;
            pos = new Vector2(col * spacingX, flippedRow * spacingY);

            tiles[row, col] = Instantiate(tile, pos, Quaternion.identity, transform);
            text = tiles[row, col].GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = count.ToString();
            }

            count++;
        }
    }

    transform.position = new Vector2(xOffset, yOffset);
}


    void Update()
    {
        
    }
}
