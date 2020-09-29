using System.Collections;
using UnityEngine;

public class GigaDeathBMissileHolder : EnemyScript
{
    private Animator[] animators;
    private GameObject missile;
    private GameObject topMissile = null;
    private GameObject bottomMissile = null;
    private float missileSpeed;
    private bool UMissileReady = true;
    private bool DMissileReady = true;
    public bool canLaunch = true;
    private bool cooldown = false;
    private float lastShot = 0f;
    private float cooldownDelay = 5f;
    private bool reloadedU = false;
    private bool reloadedB = false;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        missile = GetComponentInParent<GigaDeathB>().missile;
        missileSpeed = GetComponentInParent<GigaDeathB>().missileSpeed;
        animators = GetComponentsInChildren<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(topMissile == null && !reloadedU && !UMissileReady)
            {
                StartCoroutine(ReloadMissile(0));
                reloadedU = true;
            }
        if(bottomMissile == null && !reloadedB && !DMissileReady)
            {
                StartCoroutine(ReloadMissile(1));
                reloadedB = true;
            }

        if(Time.time - lastShot > cooldownDelay)
        {
            cooldown = false;
        }
        if((!UMissileReady && !DMissileReady) || cooldown || (topMissile != null && bottomMissile != null))
            canLaunch = false;
        else
            canLaunch = true;
    }

    public override void Attack(){
    }

    public void LaunchMissile(GameObject target)
    {
        lastShot = Time.time;
        cooldown = true;
        if (UMissileReady)
        {
            topMissile = Instantiate(missile, animators[0].transform.position, new Quaternion(0f,0f,0f,0f));
            topMissile.GetComponent<GigaDeathBMissile>().target = target;
            topMissile.GetComponent<GigaDeathBMissile>().speed = missileSpeed;
            UMissileReady = false;
            animators[0].SetTrigger("empty");
            reloadedU = false;
            
        }
        
        else
        {
            bottomMissile = Instantiate(missile, animators[1].transform.position, new Quaternion(0f,0f,0f,0f));
            bottomMissile.GetComponent<GigaDeathBMissile>().target = target;
            bottomMissile.GetComponent<GigaDeathBMissile>().speed = missileSpeed;
            DMissileReady = false;
            animators[1].SetTrigger("empty");
            reloadedB = false;

        }
    }


    IEnumerator ReloadMissile(int index){
        
        yield return new WaitForSeconds(10f);
        animators[index].SetTrigger("loadMissile");
        yield return new WaitForSeconds(1f);
        if(index == 0)
            UMissileReady = true;
        else
            DMissileReady = true;
    }

}
