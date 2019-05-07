using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using GameInformation;

public class BossRoomChoice : MonoBehaviour
{

    [SerializeField]
    bool leave;

    [SerializeField]
    GameObject desc;

    bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!leave)
                {
                    staticVars.mapControl.regenMap();
                }
                else
                {
                    //entities.player.transform.position = new Vector3(0, 2, 0);
                    //entities.player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    SceneManager.LoadScene("HubWorld");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            triggered = true;
            desc.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            triggered = false;
            desc.SetActive(false);
        }
    }
}
