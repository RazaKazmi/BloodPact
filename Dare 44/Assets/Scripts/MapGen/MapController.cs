using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    [SerializeField]
    float xOffset, yOffset;

    [SerializeField]
    float baseXOffset, baseYOffset;

    [SerializeField]
    int xSize, ySize;

    [SerializeField]
    GameObject[] roomPrefabs;

    [SerializeField]
    GameObject bossRoom;

    [SerializeField]
    GameObject EntranceRoom;

    [SerializeField]
    GameObject vendorRoom;


    [SerializeField]
    GameObject[,] rooms;


    // Start is called before the first frame update
    void Start()
    {
        GameInformation.staticVars.mapControl = this;
        Vector2 venLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        Vector2 venLoc2 = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        Vector2 bossLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        Vector2 startLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));

        while (startLoc == bossLoc)
        {
            bossLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        }
        while (startLoc == venLoc || bossLoc == venLoc)
        {
            venLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        }
        while (startLoc == venLoc2 || venLoc == venLoc2 || bossLoc == venLoc2)
        {
            venLoc2 = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        }


        rooms = new GameObject[xSize, ySize];

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                GameObject t;
                if (bossLoc == new Vector2(i, j))
                {
                    t = Instantiate<GameObject>(bossRoom, transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);

                }
                else if (startLoc == new Vector2(i, j))
                {
                    t = Instantiate<GameObject>(EntranceRoom, transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);

                    GameInformation.entities.player.transform.position = t.transform.position;
                }
                else if (venLoc == new Vector2(i, j))
                {
                    t = Instantiate<GameObject>(vendorRoom, transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);

                }
                else if (venLoc2 == new Vector2(i, j))
                {
                    t = Instantiate<GameObject>(vendorRoom, transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);

                }
                else
                {
                    t = Instantiate<GameObject>(roomPrefabs[Random.Range(0, roomPrefabs.Length)], transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);
                }

                //if (i == xSize - 1)
                //{
                //    t.GetComponent<Room>().rightBlocker.SetActive(true);
                //}
                //if (i == 0)
                //{
                //    t.GetComponent<Room>().leftBlocker.SetActive(true);
                //}

                //if (j == ySize - 1)
                //{
                //    t.GetComponent<Room>().topBlocker.SetActive(true);
                //}
                //if (j == 0)
                //{
                //    t.GetComponent<Room>().bottomBlocker.SetActive(true);
                //}

                t.transform.parent = transform;
                rooms[i, j] = t;
            }
        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void regenMap()
    {
        GameInformation.staticVars.currentfloor++;

        Vector2 startLoc = Vector2.zero;
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                if (rooms[i, j].GetComponent<Room>().boss)
                    startLoc = new Vector2(i, j);


            }
        }

        Vector2 venLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        Vector2 venLoc2 = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        Vector2 bossLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));

        while (startLoc == bossLoc)
        {
            bossLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        }
        while (startLoc == venLoc || bossLoc == venLoc)
        {
            venLoc = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        }
        while (startLoc == venLoc2 || venLoc == venLoc2 || bossLoc == venLoc2)
        {
            venLoc2 = new Vector2(Random.Range(0, xSize - 1), Random.Range(0, ySize - 1));
        }

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {

                Destroy(rooms[i, j]);

                GameObject t;
                if (bossLoc == new Vector2(i, j))
                {
                    t = Instantiate<GameObject>(bossRoom, transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);

                }
                else if (startLoc == new Vector2(i, j))
                {
                    t = Instantiate<GameObject>(EntranceRoom, transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);

                }
                else if (venLoc == new Vector2(i, j))
                {
                    t = Instantiate<GameObject>(vendorRoom, transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);

                }
                else if (venLoc2 == new Vector2(i, j))
                {
                    t = Instantiate<GameObject>(vendorRoom, transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);

                }
                else
                {
                    t = Instantiate<GameObject>(roomPrefabs[Random.Range(0, roomPrefabs.Length - 1)], transform.position + new Vector3((xOffset * (i - (xSize * 0.5f))) + baseXOffset, (yOffset * (j - (ySize * 0.5f))) + baseYOffset, 0), transform.rotation);
                }

                if (i == xSize - 1)
                {
                    t.GetComponent<Room>().rightBlocker.SetActive(true);
                }
                if (i == 0)
                {
                    t.GetComponent<Room>().leftBlocker.SetActive(true);
                }

                if (j == ySize - 1)
                {
                    t.GetComponent<Room>().topBlocker.SetActive(true);
                }
                if (j == 0)
                {
                    t.GetComponent<Room>().bottomBlocker.SetActive(true);
                }

                t.transform.parent = transform;
                rooms[i, j] = t;
            }
        }
    }
}


