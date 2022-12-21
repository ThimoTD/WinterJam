using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
