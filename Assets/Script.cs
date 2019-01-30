using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    public Transform tile;
    Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i ++)
        {
            for(int j = 0; j < 10; j++)
            {
                Transform Tile = Instantiate(tile) as Transform;
                vector.x = j;
                vector.z = i;
                int z = Random.Range(0, 100);
                //if(z > 80)
                //{
                //    vector.y = 0f;
                //}

                //랜덤 타일
                if (z < 5)
                {
                    vector.y = 4f;
                }
                else if (z < 15)
                {
                    vector.y = 3f;
                }
                else if (z < 40)
                {
                    vector.y = 2f;
                }
                else if (z < 100)
                {
                    vector.y = 1f;
                }
                Tile.position = vector;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
