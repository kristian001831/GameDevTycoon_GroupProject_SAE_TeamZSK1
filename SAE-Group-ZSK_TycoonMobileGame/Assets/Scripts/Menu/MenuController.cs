using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private List<Menu> menus = new List<Menu>();

    [SerializeField] private GameObject failScreen;
    private FailSystem failSystem;
    
    private void Start()
    { 
        // Show the first menu on start
        ShowMenu(menus[0]);
        failSystem = FindObjectOfType<FailSystem>();
        failSystem.OnGameFailed += ShowFailScreen;
    }

    private void ShowFailScreen()
    {
        failScreen.SetActive(true);
    }
    
    public void ShowMenu(Menu menuToShow)
    {
        // ensure this is the menu we are tracking
        if(menus.Contains(menuToShow) == false)
        {
            Debug.LogErrorFormat("{0} is not in the list of menus", menuToShow.name);
            return;
        }

        // Enable this menu, and disable the others
        foreach (var otherMenu in menus)
        {
            // is this the menu we want to display?
            if (otherMenu == menuToShow)
            {
                otherMenu.gameObject.SetActive(true);

                // Tell the Menu object to invoke its "did appear" action
                otherMenu.menuDidAppear.Invoke();
            }
            else 
            {
                // Is this menu currently active? if so, disappear action
                if (otherMenu.gameObject.activeInHierarchy)
                { 
                    otherMenu.menuWillDisappear.Invoke();
                }
                // and mark it as inactive
                otherMenu.gameObject.SetActive(false);
            }
        }
    }

    // for the start button
    public void PlayGame(int level)
    {
        SceneManager.LoadScene(level);
    }

    // for the quit button 
    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Application quit...");
    }
}
