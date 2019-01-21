using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShot : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void GotShot()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
