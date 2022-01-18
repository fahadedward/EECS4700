using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public enum Portal
    {
        PortalOne,
        PortalTwo,
        PortalThree,
        PortalFour,
        BPortal
    }

    [SerializeField]
    GameObject[] portals;
    
    Portal portal;

    public Portal PortalEnum
    {
        get { return portal; }
        set { portal = value; }
    }

    void Start()
    {
        portal = Portal.PortalOne;
    }

    void changePortals()
    {
        switch (portal)
        {
            case Portal.PortalOne:
                portals[0].SetActive(true);
                portals[1].SetActive(false);
                portals[2].SetActive(false);
                portals[3].SetActive(false);
                break; 
            case Portal.PortalTwo:
                portals[0].SetActive(false);
                portals[1].SetActive(true);
                portals[2].SetActive(false);
                portals[3].SetActive(false);
                break;
            case Portal.PortalThree:
                portals[0].SetActive(false);
                portals[1].SetActive(false);
                portals[2].SetActive(true);
                portals[3].SetActive(false);
                break;
            case Portal.PortalFour:
                portals[0].SetActive(false);
                portals[1].SetActive(false);
                portals[2].SetActive(false);
                portals[3].SetActive(true);
                break;
                //portals[1].SetActive(false);
                // portals[2].SetActive(false);
                //  portals[3].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        changePortals();
    }
}
