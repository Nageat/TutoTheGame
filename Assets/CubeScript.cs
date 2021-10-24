using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameManager GM;

    public Material Material;


    public Material Red;
    public Material Green;
    public Material Bleu;
    public Material Jaune;

    void Update()
    {
        GetComponent<Renderer>().material = Material;
    }

    private void Start()
    {
        Material = Red;

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "HoleRed" && GM.GetComponent<GameManager>().IsTakeCube == true)
        {
            GM.GetComponent<GameManager>().IsTakeCube = false;
            GM.GetComponent<GameManager>().Cube.transform.position = GM.GetComponent<GameManager>().RedZone.transform.position;

            if (GM.GetComponent<GameManager>().Gamestat == 0)
            {
                StartCoroutine(Good());
                Material = Green;
            }
            else if (GM.GetComponent<GameManager>().Gamestat != 0)
            {
                StartCoroutine(Bad());

            }

        }

        if (other.gameObject.name == "HoleYellow" && GM.GetComponent<GameManager>().IsTakeCube == true)
        {
            GM.GetComponent<GameManager>().IsTakeCube = false;
            GM.GetComponent<GameManager>().Cube.transform.position = GM.GetComponent<GameManager>().YellowZpne.transform.position;

            if (GM.GetComponent<GameManager>().Gamestat == 1)
            {
                StartCoroutine(Good());
                Material = Bleu;
            }
            else if (GM.GetComponent<GameManager>().Gamestat != 0)
            {
                StartCoroutine(Bad());

            }

        }

        if (other.gameObject.name == "HoleBleu" && GM.GetComponent<GameManager>().IsTakeCube == true)
        {
            GM.GetComponent<GameManager>().IsTakeCube = false;
            GM.GetComponent<GameManager>().Cube.transform.position = GM.GetComponent<GameManager>().BleuZone.transform.position;

            if (GM.GetComponent<GameManager>().Gamestat == 2)
            {
                StartCoroutine(Good());
                Material = Jaune;
            }
            else if (GM.GetComponent<GameManager>().Gamestat != 0)
            {
                StartCoroutine(Bad());

            }

        }

        if (other.gameObject.name == "HoleRed" && GM.GetComponent<GameManager>().IsTakeCube == true && GM.GetComponent<GameManager>().Gamestat !=0)
        {
            GM.GetComponent<GameManager>().IsTakeCube = false;
            GM.GetComponent<GameManager>().Cube.transform.position = GM.GetComponent<GameManager>().RedZone.transform.position;

            if (GM.GetComponent<GameManager>().Gamestat == 3)
            {
                StartCoroutine(Good());
                Material = Red;
            }
            else if (GM.GetComponent<GameManager>().Gamestat != 0)
            {
                StartCoroutine(Bad());

            }

        }


        if (other.tag == "Player")
        {
            GM.GetComponent<GameManager>().PlayerIsInAreaOfTake = true;
        }


   

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GM.GetComponent<GameManager>().PlayerIsInAreaOfTake = false;
        }
    }


    IEnumerator Good()
    {

        GM.GetComponent<GameManager>().Gamestat++;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        Debug.Log("GOOD ");
    }

    IEnumerator Bad()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        Debug.Log("Bad ");

    }
}
