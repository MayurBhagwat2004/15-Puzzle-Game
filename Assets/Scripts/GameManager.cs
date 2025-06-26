using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentEmptyTileRow;
    public int currentEmptyTileCol;
    public static GameManager Instance;
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; //Assigning the instance
        }
        else
        {
            Destroy(gameObject); //Destroying the instance if other instance is available
        }
        

    }

   

   
}
