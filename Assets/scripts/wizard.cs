using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class wizard : MonoBehaviour
{
   
    public GameObject Quiz1; // Assign the Quiz1 panel in the Inspector
    public GameObject Bridge; // Assign the Bridge in the Inspector
    public GameObject barrier; // Assign the barrier in the Inspector
    public GameObject wizardchar1; // Assign the wizard in the Inspector
    public GameObject wizardchar2; // Assign the wizard in the Inspector
    public GameObject portal; // Assign the portal in the Inspector
    public GameObject Knight;
    public int lives; // Reference to the lives variable
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject GameOverPanel; // Assign the Game Over panel in the Inspector
    public GameObject ExplanationPanel; // Assign the Explanation panel in the Inspector
    public GameObject Correct;
    
    

    private void Update()
    {
        if (lives == 3)
        {
            // Perform actions when lives are 3
            Debug.Log("You have 3 lives left!");
            life1.SetActive(true); // Show life1
            life2.SetActive(true); // Show life2
            life3.SetActive(true); // Show life3

        }
        else if (lives == 2)
        {
            // Perform actions when lives are 2
            Debug.Log("You have 2 lives left!");
            life3.SetActive(false); // Hide life3
        }
        else if (lives == 1)
        {
            // Perform actions when lives are 1
            Debug.Log("You have 1 life left!");
            life2.SetActive(false); // Hide life2
        }
        else if (lives <= 0)
        {
            // Perform actions when lives are 0
            life1.SetActive(false); // Hide life1
            Debug.Log("Game Over!"); // Log game over message
            GameOverPanel.SetActive(true); // Show the Game Over panel
            Time.timeScale = 0f; // Pause the game
            
        }
    }
    public void onClickRetryButton()
    {
        // Restart the game by reloading the current scene
        lives = 3; 
        Time.timeScale = 1f; // Resume the game
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void onClickMainMenu()
    {
        lives = 3; 
        Time.timeScale = 1f; // Resume the game
       SceneManager.LoadScene(0); // Load the Main Menu scene
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Quiz1.SetActive(true); // Unhide the Quiz1 panel
            Time.timeScale = 0f; // Pause the game
            MouseLockSystem.Instance.UnlockMouse(); // Unlock the mouse cursor


        }
    }
    public void OnYayButtonClicked()
    {
        Correct.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
    
    public void OnTrueButtonClicked()
    {
        // Ensure the function works correctly when called by the True button
        if (Quiz1.activeSelf) // Check if the Quiz1 panel is active
        {
            Quiz1.SetActive(false); // Hide the Quiz1 panel
            Correct.SetActive(true); // Show the Correct panel
            if (wizardchar1.activeSelf) // Check if Wizard1 is active
            {
                Quiz1.SetActive(false); // Hide the Quiz1 panel
                Debug.Log("True button clicked!");
                Bridge.SetActive(true); // Unhide the Bridge
                barrier.SetActive(false); // Hide the barrier
                wizardchar1.SetActive(false); // Hide the wizard
                wizardchar2.SetActive(true); // Unhide the wizard
                
            }
            else if (wizardchar2.activeSelf) // Check if Wizard2 is active
            {
                Quiz1.SetActive(false); // Hide the Quiz1 panel
                Debug.Log("True button clicked!");
                portal.SetActive(true); // Unhide the portal
                wizardchar2.SetActive(false); // Hide the wizard
                
                Knight.SetActive(true); // Unhide the Knight
            }
            else if(Knight.activeSelf) // Check if Knight is active
            {
                Quiz1.SetActive(false); // Hide the Quiz1 panel
                Debug.Log("True button clicked!");
                
            }
        }
    }
    public void OnOkButtonClicked()
    {
        ExplanationPanel.SetActive(false); // Hide the Correct panel
        Time.timeScale = 1f; // Resume the game
    }

    public void OnFalseButtonClicked()
    {
        Quiz1.SetActive(false); // Hide the Quiz1 panel
        ExplanationPanel.SetActive(true); // Show the Explanation panel
        
            

        if (wizardchar1.activeSelf)
        {
            Quiz1.SetActive(false); // Hide the Quiz1 panel
            Debug.Log("False button clicked!");
            
            lives -= 1; // Decrease lives by 1
            if (lives <= 0) // Check if lives are less than or equal to 0
            {
                Debug.Log("Game Over!"); // Log game over message
                // Add your game over logic here (e.g., show game over screen, restart level, etc.)
            }
        }
        else if (wizardchar2.activeSelf)
        {
            Quiz1.SetActive(false); // Hide the Quiz1 panel
            Debug.Log("False button clicked!");
            
            lives -= 1; // Decrease lives by 1
            if (lives <= 0) // Check if lives are less than or equal to 0
            {
                Debug.Log("Game Over!"); // Log game over message
                // Add your game over logic here (e.g., show game over screen, restart level, etc.)
            }
        }
        else if (Knight.activeSelf)
        {
            Quiz1.SetActive(false); // Hide the Quiz1 panel
            Debug.Log("False button clicked!");
            
            lives -= 1; // Decrease lives by 1
            if (lives <= 0) // Check if lives are less than or equal to 0
            {
                Debug.Log("Game Over!"); // Log game over message
                // Add your game over logic here (e.g., show game over screen, restart level, etc.)
            }
        }
    
        
    }
}