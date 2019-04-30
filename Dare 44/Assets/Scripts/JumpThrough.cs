using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThrough : MonoBehaviour
{

    bool fall;
    bool canFall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (canFall)
                fall = true;
        }

        canFall = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!fall)
        {
            if (other.tag == "Head")
            {
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameInformation.entities.player.GetComponent<BoxCollider>(), true);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().right.GetComponent<BoxCollider>(), true);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().left.GetComponent<BoxCollider>(), true);
            }
            if (other.tag == "Foot")
            {
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameInformation.entities.player.GetComponent<BoxCollider>(), false);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().right.GetComponent<BoxCollider>(), false);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().left.GetComponent<BoxCollider>(), false);

                canFall = true;
            }
        }
        else
        {
            if (other.tag == "Head")
            {
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameInformation.entities.player.GetComponent<BoxCollider>(), false);
                fall = false;
            }
            if (other.tag == "Foot")
            {
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameInformation.entities.player.GetComponent<BoxCollider>(), true);
                canFall = true;
            }
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (!fall)
        {
            if (other.tag == "Head")
            {
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameInformation.entities.player.GetComponent<BoxCollider>(), true);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().right.GetComponent<BoxCollider>(), true);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().left.GetComponent<BoxCollider>(), true);
            }
            if (other.tag == "Foot")
            {
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameInformation.entities.player.GetComponent<BoxCollider>(), false);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().right.GetComponent<BoxCollider>(), false);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().left.GetComponent<BoxCollider>(), false);

                canFall = true;
            }
        }
        else
        {
            if (other.tag == "Head")
            {
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameInformation.entities.player.GetComponent<BoxCollider>(), false);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().right.GetComponent<BoxCollider>(), false);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().left.GetComponent<BoxCollider>(), false);
                fall = false;
            }
            if (other.tag == "Foot")
            {
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameInformation.entities.player.GetComponent<BoxCollider>(), true);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().right.GetComponent<BoxCollider>(), true);
                Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.transform.parent.GetComponent<FallThroughLogic>().left.GetComponent<BoxCollider>(), true);
                canFall = true;
            }
        }
    }
}
