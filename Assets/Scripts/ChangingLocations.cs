using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingLocations : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player, cam, cam2;

   
    [SerializeField]
    Transform[] portalDestinations;

    [SerializeField]
    Portals portal;

    Player playerScript;
    [SerializeField]
    public GameObject[] BPortal;

    Basketball basketball;
    
    [SerializeField]
    InputFromPlayer inputFromPlayer;

    [SerializeField]
    Sounds warpSound;

    [SerializeField]
    GameObject score;
    void Awake()
    {
        portal = FindObjectOfType<Portals>();
        playerScript = FindObjectOfType<Player>();
        basketball = FindObjectOfType<Basketball>();
        inputFromPlayer = FindObjectOfType<InputFromPlayer>();
        warpSound = FindObjectOfType<Sounds>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(portal.PortalEnum == Portals.Portal.PortalOne)
            {
                cam.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                player.gameObject.SetActive(false);
                player.transform.position = new Vector3(portalDestinations[0].transform.position.x, portalDestinations[0].transform.position.y + 1.25f,
                portalDestinations[0].transform.position.z);
                cam.gameObject.SetActive(true);
                cam2.gameObject.SetActive(true);
                player.gameObject.SetActive(true);
                warpSound.PlayWarp();
            }
            if (portal.PortalEnum == Portals.Portal.PortalTwo)
            {
                cam.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                player.gameObject.SetActive(false);
                player.transform.position = new Vector3(portalDestinations[1].transform.position.x - 10, portalDestinations[1].transform.position.y + 1.08f, portalDestinations[1].transform.position.z);
                cam.gameObject.SetActive(true);
                cam2.gameObject.SetActive(true);
                player.gameObject.SetActive(true);
                warpSound.PlayWarp();
                score.gameObject.SetActive(true);
            }
            if (portal.PortalEnum == Portals.Portal.PortalThree)
            {
                cam.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                player.gameObject.SetActive(false);
                player.transform.position = new Vector3(portalDestinations[2].transform.position.x, portalDestinations[2].transform.position.y + 1.08f, portalDestinations[2].transform.position.z);
                player.transform.rotation = Quaternion.Euler(0f, 95f, 0f);
                cam.gameObject.SetActive(true);
                cam2.gameObject.SetActive(true);
                player.gameObject.SetActive(true);
                BPortal[2].SetActive(true);
                warpSound.PlayWarp();
                score.gameObject.SetActive(false);
                playerScript.Speed = 7f;
            }
            if (portal.PortalEnum == Portals.Portal.PortalFour)
            {
                cam.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                player.gameObject.SetActive(false);
                player.transform.position = new Vector3(portalDestinations[3].transform.position.x, portalDestinations[3].transform.position.y + 1.12f, portalDestinations[3].transform.position.z);
                cam.gameObject.SetActive(true);
                cam2.gameObject.SetActive(true);
                player.gameObject.SetActive(true);
                warpSound.PlayWarp();
                playerScript.Speed = 4f;
            }
            if (portal.PortalEnum == Portals.Portal.BPortal)
            {
                playerScript.ToyCounter = 0;
                basketball.Score = 0;
                inputFromPlayer.PlayerInput = " ";
                cam.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                player.gameObject.SetActive(false);
                player.transform.position = new Vector3(portalDestinations[4].transform.position.x, portalDestinations[4].transform.position.y + 1.08f, portalDestinations[4].transform.position.z);
                cam.gameObject.SetActive(true);
                cam2.gameObject.SetActive(true);
                player.gameObject.SetActive(true);
                warpSound.PlayWarp();
                if (BPortal[0].activeSelf == true)
                {
                    portal.PortalEnum = Portals.Portal.PortalTwo;
                }
                if (BPortal[1].activeSelf == true)
                {
                    portal.PortalEnum = Portals.Portal.PortalThree;
                    playerScript.Speed = 4f;
                }
                if (BPortal[2].activeSelf == true)
                {
                    portal.PortalEnum = Portals.Portal.PortalFour;
                }
            }

        }
     
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(portal.PortalEnum);
        if(playerScript.ToyCounter >= 4)
        {
            BPortal[0].SetActive(true);
            portal.PortalEnum = Portals.Portal.BPortal;
        }
        if(basketball.Score >= 4)
        {
            BPortal[1].SetActive(true);
            portal.PortalEnum = Portals.Portal.BPortal;
        }
    }
}
