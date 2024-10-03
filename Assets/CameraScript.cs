using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + 6, 0, -10); 
    }
}
