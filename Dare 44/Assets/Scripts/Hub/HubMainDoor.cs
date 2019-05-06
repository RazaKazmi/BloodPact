using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using GameInformation;
public class HubMainDoor : MonoBehaviour
{
    [SerializeField]
    Text floorText;

    [SerializeField]
    Text errorText;

    bool visible = false;



    // Start is called before the first frame update
    void Start()
    {

        //PlayerPrefs.SetFloat("Souls", staticVars.souls);
        //PlayerPrefs.SetInt("Floor", staticVars.maxFloor);
        //PlayerPrefs.SetInt("sMaxHP", Upgrades.statcount[0]);
        //PlayerPrefs.SetInt("sMaxMP", Upgrades.statcount[1]);
        //PlayerPrefs.SetInt("sMelee", Upgrades.statcount[2]);
        //PlayerPrefs.SetInt("sMagic", Upgrades.statcount[3]);
        //PlayerPrefs.SetInt("sMana", Upgrades.statcount[4]);
        //PlayerPrefs.SetInt("sMagicResist", Upgrades.statcount[5]);

        //PlayerPrefs.SetFloat("MaxHP", entities.player.GetComponent<Player>().maxHealth);
        //PlayerPrefs.SetFloat("MaxMP", entities.player.GetComponent<Player>().maxMana);
        //PlayerPrefs.SetFloat("Melee", entities.player.GetComponent<Player>().meleeDamageIncrease);
        //PlayerPrefs.SetFloat("Magic", entities.player.GetComponent<Player>().magicDamageIncrease);
        //PlayerPrefs.SetFloat("Mana", entities.player.GetComponent<Player>().ManaCostReduction);
        //PlayerPrefs.SetFloat("MagicResist", entities.player.GetComponent<Player>().damageResistance);

        GameInformation.entities.player.transform.position = new Vector3(0,3,0);
        GameInformation.entities.player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //GameInformation.entities.player.GetComponent<Player>().addHP(GameInformation.entities.player.GetComponent<Player>().maxHealth);
        //GameInformation.entities.player.GetComponent<Player>().addMP(GameInformation.entities.player.GetComponent<Player>().maxMana);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.LeftAlt))
        {
            PlayerPrefs.DeleteAll();
        }

        floorText.text = "Floor " + staticVars.currentfloor.ToString();

        if(staticVars.currentfloor > staticVars.maxFloor)
        {
            staticVars.maxFloor = staticVars.currentfloor;
        }

        if (visible)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!decreaseFloor())
                {
                    errorText.gameObject.SetActive(true);
                }
                else
                {
                    errorText.gameObject.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!increaseFloor())
                {
                    errorText.gameObject.SetActive(true);
                }
                else
                {
                    errorText.gameObject.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                startGame();
            }
        }

    }

    bool increaseFloor()
    {
        if (staticVars.currentfloor < staticVars.maxFloor)
        {
            staticVars.currentfloor++;
            return true;
        }
        return false;
    }

    bool decreaseFloor()
    {
        if (staticVars.currentfloor > 1)
        {
            staticVars.currentfloor--;
            return true;
        }
        return false;
    }

    public void startGame()
    {
        DontDestroyOnLoad(entities.player.transform.parent);
        SceneManager.LoadScene("GameWorld");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            errorText.gameObject.SetActive(false);
            visible = true;
            floorText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            errorText.gameObject.SetActive(false);
            visible = false;
            floorText.gameObject.SetActive(false);
        }
    }
}