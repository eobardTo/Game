using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
	}
	public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

 public void QuitGame()
    {
        Application.Quit();
    }
 public void Update()
 {
 	if (SceneManager.GetActiveScene().name == "SampleScene")
 	{
 		if (Input.GetKey("escape"))
 		{
 			SceneManager.LoadScene("Menu");
 		}
 	}
 }
}

