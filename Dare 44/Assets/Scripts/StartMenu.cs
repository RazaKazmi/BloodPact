using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using GameInformation;
public class StartMenu : MonoBehaviour
{
    [SerializeField]
    GameObject playerRef;

    [SerializeField]
    GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        staticVars.souls = PlayerPrefs.GetFloat("Souls", 0);
        staticVars.maxFloor = PlayerPrefs.GetInt("Floor", 1);
        Upgrades.statcount[0] = PlayerPrefs.GetInt("sMaxHP", 1);
        Upgrades.statcount[1] = PlayerPrefs.GetInt("sMaxMP", 1);
        Upgrades.statcount[2] = PlayerPrefs.GetInt("sMelee", 1);
        Upgrades.statcount[3] = PlayerPrefs.GetInt("sMagic", 1);
        Upgrades.statcount[4] = PlayerPrefs.GetInt("sMana", 1);
        Upgrades.statcount[5] = PlayerPrefs.GetInt("sMagicResist", 1);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject t = Instantiate<GameObject>(playerRef);
            DontDestroyOnLoad(t);
            DontDestroyOnLoad(music);
            SceneManager.LoadScene("HubWorld",LoadSceneMode.Single);
        }
    }
}
