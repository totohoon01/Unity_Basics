using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject bulletEffect;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            //충돌 포인트 
            ContactPoint cont = coll.GetContact(0);
            Vector3 norm = cont.normal;
            Quaternion rot = Quaternion.LookRotation(-norm);
            GameObject effobj = Instantiate(bulletEffect, cont.point, rot);

            Destroy(effobj, 0.8f);
            Destroy(coll.gameObject);
        }
    }
}
