using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 카메라 컨트롤러 스크립트 */
public class CameraController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3 (
            transform.position.x, playerPos.y, transform.position.z);
        
    }
}
