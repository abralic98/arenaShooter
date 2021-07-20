using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float range = 100f;
    public ParticleSystem muzzleFlash;
    public Camera fpsCam;
    [SerializeField] GameObject impactEffectGround;
    [SerializeField] GameObject impactEffectMetal;
    [SerializeField] GameObject impactEffectPlayer;
    [SerializeField] GameObject impactEffectWood;
    [SerializeField] GameObject impactEffectStone;
    [SerializeField] GameObject terrain;
    [SerializeField] float fireRate = 1f;
    [SerializeField] AudioSource shot;
    private int weaponType = 1;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) // get buttondown mozes drzat samo ce jednom stisnit za automatske puske nije 
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        shot.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(hit.collider.gameObject.name);
            if (target != null)
            {
                target.TakeDamage(damage,weaponType);
            }
            if (hit.collider.gameObject.name == "Terrain" || hit.collider.gameObject.name == "Terrain (1)" || hit.collider.gameObject.name == "road_0001" || hit.collider.gameObject.tag == "CtBaseDustProps")
            {
                GameObject impactGO = Instantiate(impactEffectGround, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
            if (hit.collider.gameObject.tag == "CtArmyBunker" ||
                hit.collider.gameObject.tag == "Tank" ||
                hit.collider.gameObject.tag == "BaseLampCT" ||
                hit.collider.gameObject.tag == "StreetLamp" ||
                hit.collider.gameObject.tag == "CtMetalProps" ||
                hit.collider.gameObject.tag == "CtBaseTurrets")
            {
                GameObject impactGO = Instantiate(impactEffectMetal, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
            if (hit.collider.gameObject.tag == "CtBaseWalls" || hit.collider.gameObject.tag == "CtBaseBunkers")
            {
                GameObject impactGO = Instantiate(impactEffectStone, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
            if (hit.collider.gameObject.tag == "Human")
            {
                GameObject impactGO = Instantiate(impactEffectPlayer, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }

        }

    }
}
