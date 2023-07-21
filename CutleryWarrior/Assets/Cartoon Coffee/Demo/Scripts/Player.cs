using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transformComponent;
    int rightClickWaitTime = 0;
    public int rightClickWaitTimeLimit = 10;
    public float angleMax = 90;
    public float angleMin = -70;
    int chargeTime = 0;
    int midChargeTime = 60;
    int fullChargeLimit = 400;
    bool muzzleFlash = false;
    Color muzzleFlashColor;
    GameObject projectileObject = null;
    GameObject burstObject = null;
    GameObject loopObject;
    GameObject chargeObject = null;



    void Start()
    {
        transformComponent = GetComponent<Transform>();
        loopObject = new GameObject();
        
    }

    // Sets the rotation of the arm
    void SetArmRotation()
    {
        Quaternion rot = new Quaternion();
        float shootAngle = GetAngle() * Mathf.Rad2Deg;
        rot.eulerAngles = new Vector3(0,0,shootAngle);
        transform.rotation = rot;
    }
    // Finds the angle from the origin position of the arm to the mouse position.
    public float GetAngle()
    {
        Vector3 trueMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Mathf.Atan2(trueMousePosition.y - transform.position.y, trueMousePosition.x - transform.position.x) * Mathf.Rad2Deg > angleMax)
        {
            return Mathf.Deg2Rad * angleMax;
        }
        if(Mathf.Atan2(trueMousePosition.y - transform.position.y, trueMousePosition.x - transform.position.x) * Mathf.Rad2Deg < angleMin)
        {
            return Mathf.Deg2Rad * angleMin;
        }

        return Mathf.Atan2(trueMousePosition.y - transform.position.y, trueMousePosition.x - transform.position.x);
    }
    // Finds the origin point of the end of the arm while utilzing rotation
    public Vector2 CircleAroundCenter(float centerX, float centerY, float dstX, float dstY)
    {
        Vector2 tempVector = new Vector2();
        tempVector.x = (float)(Mathf.Cos(GetAngle())*(dstX-centerX) - Mathf.Sin(GetAngle()) * (dstY-centerY)+centerX);
        tempVector.y = (float) (Mathf.Sin(GetAngle()) * (dstX -centerX) + Mathf.Cos(GetAngle())*(dstY-centerY)+centerY);

        return tempVector;
    }

    // Checks if the player controller will shoot a bullet
    public void CheckShot()
    {
        // Increase right click time
        if(rightClickWaitTime < rightClickWaitTimeLimit)
        {
            rightClickWaitTime++;
        }

        if (GameObject.FindWithTag("Menu").GetComponentInParent<SideMenu>().selectedItem == "projectile")
        {
            projectileObject = GameObject.FindGameObjectWithTag("Menu").GetComponent<SideMenu>().selectedItemObject;
            
            // Left click shoot for both charge and not chargable shots
            if (Input.GetMouseButtonUp(0) && projectileObject.GetComponent<Projectile>().isChargeable || Input.GetMouseButtonDown(0) && !projectileObject.GetComponent<Projectile>().isChargeable)
            {
                ShootBullet();
                chargeTime = 0;
            }

            // Increases charge time for chargable shots
            if(projectileObject.GetComponent<Projectile>().isChargeable && Input.GetMouseButton(0))
            {
                chargeTime++;
                if (chargeTime > 40 && chargeObject == null)
                {
                    chargeObject = Instantiate(projectileObject.GetComponent<Projectile>().chargingObject, CircleAroundCenter(transform.position.x, transform.position.y, transform.position.x + projectileObject.GetComponent<Projectile>().chargeOriginPoint.x,
                transform.position.y + projectileObject.GetComponent<Projectile>().chargeOriginPoint.y), this.transform.rotation);
                    if (chargeObject.transform.childCount > 0)
                    {
                        chargeObject.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = projectileObject.GetComponent<Projectile>().chargeColor;
                    }
                }
                ChargeParticleCheck();

               
            }

            // Right click shot
            if(Input.GetMouseButton(1) && rightClickWaitTime >= rightClickWaitTimeLimit)
            {
                ShootBullet();
                rightClickWaitTime = 0;
            }
        }
    }

    public void ChargeParticleCheck()
    {
        if(chargeTime == 40)
        {
            chargeObject = Instantiate(projectileObject.GetComponent<Projectile>().chargingObject,CircleAroundCenter(transform.position.x,transform.position.y,transform.position.x + projectileObject.GetComponent<Projectile>().chargeOriginPoint.x,
                transform.position.y + projectileObject.GetComponent<Projectile>().chargeOriginPoint.y),this.transform.rotation);
            if (chargeObject.transform.childCount > 0)
            {
                chargeObject.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = projectileObject.GetComponent<Projectile>().chargeColor;
            }
        }

        if(chargeTime > 40)
        {
            chargeObject.transform.position = CircleAroundCenter(transform.position.x, transform.position.y, transform.position.x + projectileObject.GetComponent<Projectile>().chargeOriginPoint.x, transform.position.y + projectileObject.GetComponent<Projectile>().chargeOriginPoint.y);
        }
    }

    // Generates burst
    public void CheckBurst()
    {
        if(GameObject.FindWithTag("Menu").GetComponentInParent<SideMenu>().selectedItem == "burst" )
        {
            Vector3 trueMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!GameObject.FindWithTag("Menu").GetComponentInParent<SideMenu>().isMenuOpen || GameObject.FindWithTag("Menu").GetComponentInParent<SideMenu>().isMenuOpen && trueMousePosition.y < 4.3 && trueMousePosition.x < -7.2
                || GameObject.FindWithTag("Menu").GetComponentInParent<SideMenu>().isMenuOpen && trueMousePosition.x > -7.2)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    PlayBurst();
                }
            }
        }
    }

    // Plays the burst animation
    public void PlayBurst()
    {
        if(burstObject != null)
        {
            Destroy(burstObject);
        }
        burstObject = Instantiate(GameObject.FindWithTag("Menu").GetComponentInParent<SideMenu>().selectedItemObject, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        burstObject.gameObject.SetActive(true);
    }

    // Burst Manual removal
    public void BurstManualRemoval()
    {
        if (burstObject != null)
        {
            Destroy(burstObject);
        }
    }

    // Generates the loop and hides it if loop is not selected
    public void CheckLoop()
    {
        if (loopObject != null && loopObject.transform.childCount > 0)
        {
            if (GameObject.FindWithTag("Menu").GetComponentInParent<SideMenu>().selectedItem == "loop")
            {
                loopObject.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().renderMode = ParticleSystemRenderMode.Billboard;
                loopObject.transform.position = loopObject.GetComponent<Loop>().loopPosition;
            }
            else
            {
                GameObject.Destroy(loopObject);
            }
        }
    }

    // Shoots the actual bullet
    public void ShootBullet()
    {

        Vector2 spawnPoint = CircleAroundCenter(transform.position.x, transform.position.y, transform.position.x + projectileObject.GetComponent<Projectile>().bulletOriginPoint.x, transform.position.y + projectileObject.GetComponent<Projectile>().bulletOriginPoint.y);
        float bulletAngle = 0;
        if (projectileObject.GetComponent<Projectile>().rotateSprite)
        {
            bulletAngle = GetAngle() * Mathf.Rad2Deg;
        }
        GameObject bullet = Instantiate(projectileObject, new Vector3(spawnPoint.x, spawnPoint.y, 1), Quaternion.Euler(0, 0, 0));
        bullet.GetComponent<Projectile>().moveAngle = GetAngle() + (Mathf.Deg2Rad * Random.Range(-bullet.GetComponent<Projectile>().angleRandomness, bullet.GetComponent<Projectile>().angleRandomness));
        bullet.GetComponent<Projectile>().spriteAngle = bullet.GetComponent<Projectile>().moveAngle;

        // Increases the size of the bullet if it met the charge requirements
        if(projectileObject.GetComponent<Projectile>().isChargeable)
        {
            // Remove the Charge effect

            if(chargeTime >= fullChargeLimit)
            {
                float bulletSize = 1.5f;
                bullet.transform.localScale = new Vector3(bulletSize, bulletSize,bulletSize);
                if (bullet.transform.childCount > 0)
                {
                    bullet.transform.GetChild(0).transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
                }


            }
            else if(chargeTime >= midChargeTime)
            {
                float bulletSize = 1.25f;
                bullet.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
                if (bullet.transform.childCount > 0)
                {
                    bullet.transform.GetChild(0).transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
                }
            }

            RemoveChargeObject();
        }

        bullet.SetActive(true);

        if (projectileObject.GetComponent<Projectile>().muzzleFlash)
        {
            Vector2 muzzleFlashPoint = CircleAroundCenter(transform.position.x, transform.position.y, transform.position.x + +projectileObject.GetComponent<Projectile>().muzzleFlashOriginPoint.x, transform.position.y + projectileObject.GetComponent<Projectile>().muzzleFlashOriginPoint.y);
            GameObject muzzleFlashObjectTemp = Instantiate(bullet.GetComponent<Projectile>().muzzleFlashObject, new Vector3(muzzleFlashPoint.x, muzzleFlashPoint.y, transform.position.z), Quaternion.Euler(0,0,Mathf.Rad2Deg * GetAngle()));
            muzzleFlashObjectTemp.tag = "muzzle flash";
            muzzleFlashObjectTemp.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = projectileObject.GetComponent<Projectile>().muzzleFlashColor;
            
        }
    }

    // RemovesTheChargeObject
    public void RemoveChargeObject()
    {
        if (chargeObject != null)
        {
            Destroy(chargeObject);
        }
    }

    // Limits the head movement
    public void SendLimitsToHead()
    {
        GameObject.FindWithTag("Head").GetComponent<Head>().SetAngles(angleMin,angleMax);
    }



    public void ReceiveLoopInformation(GameObject tempLoopObject)
    {
        //Debug.Log(tempLoopObject);
        DestroyImmediate(loopObject);
        loopObject = Instantiate(tempLoopObject);
        loopObject.active = true;


    }

    void CheckMuzzleFlashAndImpact()
    {
        GameObject[] listOfImpactEffects = GameObject.FindGameObjectsWithTag("impact");
        GameObject[] listOfMuzzleFlashEffects = GameObject.FindGameObjectsWithTag("muzzle flash");


        for(int i = listOfImpactEffects.Length - 1; i >=0; i--)
        {
            if (listOfImpactEffects[i].GetComponent<ParticleSystem>().time >= listOfImpactEffects[i].GetComponent<ParticleSystem>().main.duration)
            {
                Destroy(listOfImpactEffects[i]);
            }
        }

        for (int i = listOfMuzzleFlashEffects.Length - 1; i >= 0; i--)
        {
            if (listOfMuzzleFlashEffects[i].GetComponent<ParticleSystem>().time >= listOfMuzzleFlashEffects[i].GetComponent<ParticleSystem>().main.duration)
            {
                Destroy(listOfMuzzleFlashEffects[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SendLimitsToHead();
        SetArmRotation();
        CheckShot();
        CheckBurst();
        CheckLoop();
        CheckMuzzleFlashAndImpact();

    }
}
