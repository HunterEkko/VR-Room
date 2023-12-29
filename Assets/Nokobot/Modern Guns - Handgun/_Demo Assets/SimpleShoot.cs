using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")][SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")][SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")][SerializeField] private float ejectPower = 150f;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;

    [Header("PlayerController")]
    [SerializeField] PlayerController playerController;
    private GrabMode grabMode;
    private void Awake()
    {
        if (playerController != null)
        {
            playerController.LeftShooted += OnLeftShootPressed;
            playerController.RightShooted += OnRightShootPressed;
        }
    }
    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        // //If you want a different input, change it here
        // if (Input.GetMouseButton(0))
        // {
        //     //Calls animation on the gun that has the relevant animation events that will fire
        //     gunAnimator.SetTrigger("Fire");
        // }
    }

    //This function creates the bullet behavior
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }
        PlayGunSound();
        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        GameObject tempBullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        tempBullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        Destroy(tempBullet, destroyTimer);
    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }
    //我寫的------------------------------------------------------------------------------------------------------------------------------------------------
    void PlayGunSound()
    {
        audioSource.Stop();
        audioSource.Play();
    }
    void OnLeftShootPressed()
    {
        if (grabMode == GrabMode.LEFT_GRAB)
            GenerateBullet();
    }
    void OnRightShootPressed()
    {
        if (grabMode == GrabMode.RIGHT_GRAB)
            GenerateBullet();
    }
    void GenerateBullet()
    {
        gunAnimator.SetTrigger("Fire");
    }
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        string tagname = args.interactorObject.transform.tag;

        if (tagname == "LeftHand")
        {
            grabMode = GrabMode.LEFT_GRAB;
        }
        else
        {
            grabMode = GrabMode.RIGHT_GRAB;
        }
    }
    public void OnSelectExited(SelectExitEventArgs args)
    {
        grabMode = GrabMode.NO_GRAB;
    }
    private void OnDestroy()
    {
        if (playerController != null)
        {
            playerController.LeftShooted -= OnLeftShootPressed;
            playerController.RightShooted -= OnRightShootPressed;
        }
    }

}
