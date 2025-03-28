using UnityEngine;
using UnityEngine.UI;

public class wizard : MonoBehaviour
{
   
    public GameObject Quiz1; // Assign the Quiz1 panel in the Inspector
    public GameObject Bridge; // Assign the Bridge in the Inspector
    public GameObject barrier; // Assign the barrier in the Inspector
    public GameObject wizardchar1; // Assign the wizard in the Inspector
    public GameObject wizardchar2; // Assign the wizard in the Inspector
    public GameObject portal; // Assign the portal in the Inspector
    public GameObject Knight;


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Quiz1.SetActive(true); // Unhide the Quiz1 panel
            Time.timeScale = 0f; // Pause the game
            


        }
    }
    public void OnTrueButtonClicked()
    {
        // Ensure the function works correctly when called by the True button
        if (Quiz1.activeSelf) // Check if the Quiz1 panel is active
        {
            if (wizardchar1.activeSelf) // Check if Wizard1 is active
            {
                Quiz1.SetActive(false); // Hide the Quiz1 panel
                Debug.Log("True button clicked!");
                Bridge.SetActive(true); // Unhide the Bridge
                barrier.SetActive(false); // Hide the barrier
                wizardchar1.SetActive(false); // Hide the wizard
                wizardchar2.SetActive(true); // Unhide the wizard
                Time.timeScale = 1f; // Resume the game
            }
            else if (wizardchar2.activeSelf) // Check if Wizard2 is active
            {
                Quiz1.SetActive(false); // Hide the Quiz1 panel
                Debug.Log("True button clicked!");
                portal.SetActive(true); // Unhide the portal
                wizardchar2.SetActive(false); // Hide the wizard
                Time.timeScale = 1f; // Resume the game
                Knight.SetActive(true); // Unhide the Knight
            }
            else if(Knight.activeSelf) // Check if Knight is active
            {
                Quiz1.SetActive(false); // Hide the Quiz1 panel
                Debug.Log("True button clicked!");
                Time.timeScale = 1f; // Resume the game
            }
        }
    }

    public void OnFalseButtonClicked()
    {
        if (wizardchar1.activeSelf)
        {
            Quiz1.SetActive(false); // Hide the Quiz1 panel
            Debug.Log("False button clicked!");
            Time.timeScale = 1f; // Resume the game
        }
        else if (wizardchar2.activeSelf)
        {
            Quiz1.SetActive(false); // Hide the Quiz1 panel
            Debug.Log("False button clicked!");
            Time.timeScale = 1f; // Resume the game
        }
        else if (Knight.activeSelf)
        {
            Quiz1.SetActive(false); // Hide the Quiz1 panel
            Debug.Log("False button clicked!");
            Time.timeScale = 1f; // Resume the game
        }
        
    }
}