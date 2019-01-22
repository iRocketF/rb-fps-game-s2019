using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerShooter : MonoBehaviour {

    private Camera playerCam;
    public GameObject hitObject;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Transform>();
        playerCam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1Cntrl")){
            AudioManager.instance.PlaySound("SoundRandom1");

            Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));

            RaycastHit hit;

            if(Physics.Raycast (rayOrigin,playerCam.transform.forward, out hit))
            {
                hitObject = hit.transform.gameObject;

                TargetShot target = hitObject.GetComponent<TargetShot>();

                if(target !=null)
                {
                    target.GotShot();
                } else
                {
                    StartCoroutine(ShotGen(hit.point));
                }
                
            }
        }
    }

    private IEnumerator ShotGen(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy (sphere);
    }

    void OnGUI()
    {
        int size = 12;
        float posX = playerCam.pixelWidth / 2 - size / 4;
        float posY = playerCam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
