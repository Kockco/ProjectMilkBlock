using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int m_nHight = 0;

    public void SetHight(int hight)
    {
        Vector3 newPos = transform.position;
        newPos.y = hight;
        m_nHight = hight;
        transform.position = newPos;
    }
    public int GetHight()
    {
        return m_nHight;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
