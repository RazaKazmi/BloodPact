using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!transform.parent.GetComponent<Room>().start)
        {
            MoveToLayer(transform.parent, 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameInformation.staticVars.currentRoom = gameObject;
            MoveToLayer(transform.parent,0);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            GameInformation.staticVars.currentRoom = gameObject;
    }

    void MoveToLayer(Transform root, int layer)
    {
        Stack<Transform> moveTargets = new Stack<Transform>();
        moveTargets.Push(root);
        Transform currentTarget;
        while (moveTargets.Count != 0)
        {
            currentTarget = moveTargets.Pop();
            currentTarget.gameObject.layer = layer;
            foreach (Transform child in currentTarget)
                moveTargets.Push(child);
        }
    }
}
