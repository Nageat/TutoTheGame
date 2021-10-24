using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    public int Gamestat = 0;

    public System.Collections.Generic.List<GameObject> ColorsText = new System.Collections.Generic.List<GameObject>();
    public GameObject RedZone;
    public GameObject GreenZone;
    public GameObject YellowZpne;
    public GameObject BleuZone;



    public Transform CubeTakeZone;
    public Transform Cube;
    public bool IsTakeCube = false;
    public bool PlayerIsInAreaOfTake = false;
    public bool CanInteract = true;
    // Start is called before the first frame update
    void Start()
    {

    }

// Update is called once per frame
    void Update()
    {
        if (Gamestat > 0)
        {
            ColorsText[Gamestat-1].SetActive(false);

        }
        ColorsText[Gamestat].SetActive(true);

        if (IsTakeCube)
        {
            Cube.transform.position = CubeTakeZone.transform.position;
        }
        InputCheck();



    }

    void InputCheck()
    {
        if (PlayerIsInAreaOfTake && Keyboard.current.eKey.wasPressedThisFrame && IsTakeCube == false)
        {
            IsTakeCube = true;
        }
        else if (PlayerIsInAreaOfTake && Keyboard.current.eKey.wasPressedThisFrame && IsTakeCube == true)
        {
            IsTakeCube = false;
        }
    }

}
