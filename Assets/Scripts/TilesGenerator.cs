using UnityEngine;
using TMPro;
public class TilesGenerator : MonoBehaviour
{
    public GameManager gameManager;
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
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == 3 && j == 3)
                {
                    break;
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
        gameObject.transform.position = new Vector2(xOffset,yOffset);
    }

    void Update()
    {
        
    }
}
