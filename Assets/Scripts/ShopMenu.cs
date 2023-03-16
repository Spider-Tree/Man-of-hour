using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{


    public GameObject shopMenu;

    public GameObject pauseMenu;


    public bool shopOpen;

    // Start is called before the first frame update
    void Start()
    {

        shopMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(shopOpen)
            {
                
                CloseShop();
            }
            else
            {
                pauseMenu.SetActive(false);
                OpenShop();
            }
        }
    }

    public void OpenShop()
    {
        shopMenu.SetActive(true);
        shopOpen = true; 
    }

        public void CloseShop()
    {
        shopMenu.SetActive(false);
        shopOpen = false; 
    }

}
