using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public Material notPushedTileMT;
    public Material pushedTileMT;
    public GameObject tileObject;
    Tile [][] map;
    Tile SelectedTile = null;
    int ui_x = 10, ui_y = 10;
    int map_x = 0 , map_y = 0;
    public void SetX(string _x)
    {
        int.TryParse(_x, out ui_x);
    }
    public void SetY(string _y)
    {
        int.TryParse(_y, out ui_y);
    }
    public void Select()
    {
        Reset();

        map_x = ui_x;
        map_y = ui_y;

        map = new Tile[map_y][];
        for (int i = 0; i < map_y; i++)
        {
            map[i] = new Tile[map_x];
            for (int j = 0; j < map_x; j++)
            {
                Vector3 newPosition = new Vector3(j - (float)map_x / 2f, 0, i - (float)map_y / 2f); 
                Tile tile = Instantiate(tileObject, newPosition, Quaternion.identity).GetComponent<Tile>();
                tile.SetHight(0);
                map[i][j] = tile;
            }
        }
    }
    void Reset()
    {
        for (int i = 0; i < map_y; i++)
        {
            for (int j = 0; j < map_x; j++)
            {
                Destroy(map[i][j].gameObject);
            }
        }
    }
    public void Save()
    {
        TextSaveLoad Save = new TextSaveLoad();
        for (int i = 0; i < map_y; i++) {
            for (int j = 0; j < map_x; j++) {
                Save.WriteData(map[j][i].GetHight);
            }
        }
    }
    public void Load()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Select();
    }

    void SetTilePushed(Tile targetTile, bool isPushed)
    {
        Debug.Log(targetTile);
        Debug.Log(targetTile.transform);
        Debug.Log(targetTile.transform.childCount);
        int childCount = targetTile.transform.childCount;
        for(int i=0; i<childCount; ++i)
        {
            var child = targetTile.transform.GetChild(i);
            var childMeshRenderer = child.GetComponent<MeshRenderer>();
            if (isPushed)
            {
                childMeshRenderer.material = pushedTileMT;
            }
            else
            {
                childMeshRenderer.material = notPushedTileMT;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.transform.gameObject.tag == "Tile")
                {
                    if(SelectedTile != null) SetTilePushed(SelectedTile, false);
                    SelectedTile = hit.transform.parent.gameObject.GetComponent<Tile>();
                    SetTilePushed(SelectedTile, true);
                }
            }
        }

        if (SelectedTile != null)
        {
            for (int i = 0; i <= 5; ++i)
            {
                int keyCode = i + 48;
                if (Input.GetKeyDown((KeyCode)keyCode))
                {
                    SelectedTile.SetHight(i);
                }
            }
        }
    }
}
