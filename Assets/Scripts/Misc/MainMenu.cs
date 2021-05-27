using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //for any code that isnt my own, check relivent blog post for citation
    public GameObject mainmenu; //gets menu game object 
    public GameObject options; //gets option game object 
    public void PlayGame()// button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //on button press increase queue by 1 
    }

    public void Options() //button
    {
        mainmenu.SetActive(false); //set menu to false 
        options.SetActive(true); //sets options to true 
    }

    public void Back() //button
    {
        mainmenu.SetActive(true); //set menu to true 
        options.SetActive(false); //sets options to false
    }

    public void BackAgain() //button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);//on button press decreases queue by 2
    }


    public void PlayGameAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//on button press decreases queue by 2
    }
}
