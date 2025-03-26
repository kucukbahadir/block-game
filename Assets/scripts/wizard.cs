using UnityEngine;
using UnityEngine.UI;

public class wizard : MonoBehaviour
{
   
    public GameObject Quiz1; // Assign the Quiz1 panel in the Inspector
    public GameObject Bridge; // Assign the Bridge in the Inspector
    public GameObject barrier; // Assign the barrier in the Inspector
    public GameObject wizardchar1; // Assign the wizard in the Inspector
    public GameObject wizardchar2; // Assign the wizard in the Inspector
    public GameObject portal;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.gameObject.CompareTag("player"))
        {
            Quiz1.SetActive(true); // Unhide the Quiz1 panel
            Time.timeScale = 0f; // Pause the game
            


        }
    }
    public void OnTrueButtonClicked()
    {
        Quiz1.SetActive(false); // Hide the Quiz1 panel
        Debug.Log("True button clicked!");
        Bridge.SetActive(true); // Unhide the Bridge
        barrier.SetActive(false); // Hide the barrier
        wizardchar1.SetActive(false); // Hide the wizard
        Time.timeScale = 1f; // Resume the game

    }

    public void OnFalseButtonClicked()
    {
        Quiz1.SetActive(false); // Hide the Quiz1 panel
        Debug.Log("False button clicked!");
        Time.timeScale = 1f; // Resume the game
    }
}