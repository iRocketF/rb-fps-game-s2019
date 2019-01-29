using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerShooter : MonoBehaviour
{

    public Camera playerCam;
    public GameObject hitObject;
    public Transform player;

    public float damage = 10f;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Transform>();
        playerCam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1Cntrl"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        AudioManager.instance.PlaySound("SoundRandom1");

        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
        {
            hitObject = hit.transform.gameObject;

            Target target = hitObject.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
            else
            {
                StartCoroutine(ShotGen(hit.point));
            }
        }
    }

    private IEnumerator ShotGen(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }

    void OnGUI()
    {
        int size = 12;
        float posX = playerCam.pixelWidth / 2 - size / 4;
        float posY = playerCam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
