using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleShoot : MonoBehaviour
{

    public SteamVR_Action_Boolean fireAction; //

    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public AudioSource ShootAU;
    public RaycastHit hit;
    public GameObject bullethole;
    public Transform bulletholeparent;
    public GameObject line;

    public GameObject SmokeParticleSystem;
    public GameObject FireFlash;
    public GameObject Beam;
    public GameObject Robothit;
    public AudioSource Robotsound;




    public float shotPower = 100f;

    private Interactable interactable; //

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
        interactable = GetComponent<Interactable>(); //


    }

    void FixedUpdate()
    {
        if (interactable.attachedToHand != null) //
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType; //

            if (fireAction[source].stateDown)
            {
                GetComponent<Animator>().SetTrigger("Fire");

                ProjectileRaycast();

            }


        }



        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("Fire");

            ProjectileRaycast();

        }
    }

    void Shoot()
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        GameObject tempFlash;
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        GameObject Smoke = Instantiate(SmokeParticleSystem, barrelLocation.position, barrelLocation.rotation);
        Destroy(Smoke, 0.5f);
        GameObject Fireflash = Instantiate(FireFlash, barrelLocation.position, barrelLocation.rotation);
        Destroy(Fireflash, 0.5f);
        GameObject beam = Instantiate(Beam, barrelLocation.position, barrelLocation.rotation);
        Destroy(beam, 0.1f);

        RaycastHit hitInfo;
        bool hasHit = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hitInfo, 100);

        if(line)
        {
            GameObject liner = Instantiate(line);
            liner.GetComponent<LineRenderer>().SetPositions(new Vector3[] { barrelLocation.position, barrelLocation.position + barrelLocation.forward * 100 });

            Destroy(liner, 0.5f);
        }



        ShootAU.Play();

        //Destroy(tempFlash, 0.5f);
        // Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);

    }

    void ProjectileRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject Newbullet = Instantiate(bullethole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            Newbullet.transform.position += new Vector3(0, 0.01f, 0);
            Destroy(Newbullet, 4f);
            Newbullet.transform.parent = bulletholeparent;
            
           GameObject Newhittrig = Instantiate(Robothit, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
           Destroy(Newhittrig, 6f);
           Robotsound.Play();
        }

    }
    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
