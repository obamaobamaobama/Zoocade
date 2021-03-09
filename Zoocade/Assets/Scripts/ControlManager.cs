using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ControlManager : MonoBehaviour
{
    // The controls prefab to read from
    public GameObject controls;


    // Player 1 stuff
    private string Player1_A_button;
    private string Player1_B_button;

    public UnityEvent P1A_held;
    public UnityEvent P1A_pressed;
    public UnityEvent P1A_released;

    public UnityEvent P1B_held;
    public UnityEvent P1B_pressed;
    public UnityEvent P1B_released;
    public UnityEvent P1AB_held;      //P1 Double Inputs
    public UnityEvent P1AB_pressed;
    public UnityEvent P1AB_released;

    // Player 2 stuff
    private string Player2_A_button;

    private string Player2_B_button;
    public UnityEvent P2A_held;
    public UnityEvent P2A_pressed;
    public UnityEvent P2A_released;

    public UnityEvent P2B_held;
    public UnityEvent P2B_pressed;
    public UnityEvent P2B_released;

    public UnityEvent P2AB_held;      //P2 Double Inputs
    public UnityEvent P2AB_pressed;
    public UnityEvent P2AB_released;

    private void Start()
    {
        // Set controls from the controls prefab
            // Player 1
        Player1_A_button = controls.GetComponent<Controls>().Player1_A_button;
        Player1_B_button = controls.GetComponent<Controls>().Player1_B_button;

            // Player 2
        Player2_A_button = controls.GetComponent<Controls>().Player2_A_button;
        Player2_B_button = controls.GetComponent<Controls>().Player2_B_button;
    }


    private void Update()
    {
        // Player 1 controls
        if (Input.GetKey(Player1_A_button))     { P1A_held.Invoke(); }
        if (Input.GetKeyDown(Player1_A_button)) { P1A_pressed.Invoke(); }
        if (Input.GetKeyUp(Player1_A_button))   { P1A_released.Invoke(); }

        if (Input.GetKey(Player1_B_button))     { P1B_held.Invoke(); }
        if (Input.GetKeyDown(Player1_B_button)) { P1B_pressed.Invoke(); }
        if (Input.GetKeyUp(Player1_B_button))   { P1B_released.Invoke(); }
        
        if (Input.GetKey(Player1_A_button) && Input.GetKey(Player1_B_button)) { P1AB_held.Invoke(); }
        if (Input.GetKeyDown(Player1_A_button) && Input.GetKeyDown(Player1_B_button)) { P1AB_pressed.Invoke(); }
        if (Input.GetKeyUp(Player1_A_button) && Input.GetKeyUp(Player1_B_button)) { P1AB_released.Invoke(); }

        // Player 2 controls
        if (Input.GetKey(Player2_A_button))     { P2A_held.Invoke(); }
        if (Input.GetKeyDown(Player2_A_button)) { P2A_pressed.Invoke(); }
        if (Input.GetKeyUp(Player2_A_button))   { P2A_released.Invoke(); }

        if (Input.GetKey(Player2_B_button))     { P2B_held.Invoke(); }
        if (Input.GetKeyDown(Player2_B_button)) { P2B_pressed.Invoke(); }
        if (Input.GetKeyUp(Player2_B_button))   { P2B_released.Invoke(); }

        if (Input.GetKey(Player2_A_button) && Input.GetKey(Player2_B_button)) { P2AB_held.Invoke(); }
        if (Input.GetKeyDown(Player2_A_button) && Input.GetKeyDown(Player2_B_button)) { P2AB_pressed.Invoke(); }
        if (Input.GetKeyUp(Player2_A_button) && Input.GetKeyUp(Player2_B_button)) { P2AB_released.Invoke(); }



        // DEBUG (REMOVE BEFORE RELEASE)
        if (Input.GetKeyDown("r"))
		{
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		}
	}
}
