using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;
    public AudioClip fireSound;
    private new AudioSource audio;
    public MeshRenderer muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            audio.PlayOneShot(fireSound, 0.8f);
            StartCoroutine(ShowMuzzleEffect());
        }
    }
    IEnumerator ShowMuzzleEffect()
    {
        //오프셋 변경
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        muzzleFlash.material.mainTextureOffset = offset;

        //회전 처리
        Quaternion rot = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;

        //스케일 변경
        muzzleFlash.transform.localScale = Vector3.one * Random.Range(1.0f, 2.0f);

        muzzleFlash.enabled = true;

        yield return new WaitForSeconds(0.3f);
        muzzleFlash.enabled = false;
    }
}
