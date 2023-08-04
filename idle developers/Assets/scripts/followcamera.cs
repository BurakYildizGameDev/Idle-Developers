using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float cameraspeed=5f;
    Vector3 offset;
    void Start()
    {
        offset= transform.position-player.position;
        //burada takip icin gerkli olacak mesafeyi ayarladýk
    }

    
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,player.position+offset,cameraspeed);
        //camera takibi icin
    }
}
