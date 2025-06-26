using System;
using UnityEngine;

public class NumberBox : MonoBehaviour
{
    public int index = 0;
    int x = 0;
    int y = 0;

    private Action<int, int> spawFunc = null;
    public void Init(int i, int j, int index, Sprite sprite,Action<int, int> swapFunc)
    {
        this.index = index;
        this.GetComponent<SpriteRenderer>().sprite = sprite;
        UpdatePos(i, j);
        this.spawFunc = swapFunc;
    }

    public void UpdatePos(int i, int j)
    {
        x = i;
        y = j;
        this.gameObject.transform.localPosition = new Vector2(i, j);
    }

    public bool IsEmpty()
    {
        return index == 16;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {
            spawFunc(x,y);
        }
    }
}
