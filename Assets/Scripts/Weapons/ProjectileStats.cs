using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour
{
    
    public float damage = 20;
    public Health hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound("sound_playerImpact");
            hp = collision.gameObject.GetComponent<Health>();
            hp.TakeDamage(damage);
        }
    }
}
