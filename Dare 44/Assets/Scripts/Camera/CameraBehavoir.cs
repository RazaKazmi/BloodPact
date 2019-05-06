using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;
public class CameraBehavoir : MonoBehaviour
{
   
    GameObject player;

    [SerializeField]
    Vector2 buffer = new Vector2(10,5);

    // Start is called before the first frame update
    void Start()
    {
        player = GameInformation.entities.player;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.position.x - staticVars.currentRoom.transform.position.x > -buffer.x && player.transform.position.x - staticVars.currentRoom.transform.position.x < buffer.x + 0.5f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            if(player.transform.position.x - staticVars.currentRoom.transform.position.x > 0)
            {
                transform.position = new Vector3(staticVars.currentRoom.transform.position.x + buffer.x + 0.5f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(staticVars.currentRoom.transform.position.x - buffer.x, transform.position.y, transform.position.z);
            }
        }
        

        if (Mathf.Abs(player.transform.position.y - staticVars.currentRoom.transform.position.y) < buffer.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {
            if (player.transform.position.y - staticVars.currentRoom.transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, staticVars.currentRoom.transform.position.y + buffer.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, staticVars.currentRoom.transform.position.y - buffer.y, transform.position.z);
            }
        }

       
    }
}
