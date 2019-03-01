using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardinal1 : MonoBehaviour
{
    public float speed = 10;
    public string word = "Hello World";
    public string rly = "why World";
    public bool currentlyFlying; // to see if it's flying
    public bool currentlyMoving; // to see if it's flying
    public GameObject firstSpot;
    public GameObject secondSpot;
    public GameObject thirdSpot;
    public GameObject fourthSpot;
    Animator animator;
    Compass compass;
    Gyroscope gyro;
    public Vector3 gyroRot;
    public float compassval;
    public AudioSource myAudio;
    public AudioSource myAudio2;
    float lastsounded;
    bool havesounded = false;
    Renderer cardinalRenderer;
    Material cardinalMaterial;
    DeviceOrientation orientation;
    DeviceOrientation targetOrientation = DeviceOrientation.FaceUp;
    Color baseGrey;

    public bool reachedDestination = false;

   // public AudioClip successSound;

    //private AudioSource source;
    private Vector3 moveTarget;

    // Start is called before the first frame update

    private void Awake()
    {
       // source = GetComponent<AudioSource>();
    }

    void Start()
    {
        print("started Cardinal");
        //set movetarget to the position of the first spot.
        moveTarget = firstSpot.transform.position;
        // rotate the bird to be looking at the right spot.
        //transform.Rotate(0, 90, 0);
        currentlyFlying = true;
        currentlyMoving = true;
        animator = GetComponent<Animator>();
        gyro = Input.gyro;
        compass = Input.compass;
        compass.enabled = true;
        gyro.enabled = true;
        Input.location.Start();

        cardinalRenderer = gameObject.GetComponentInChildren(typeof(Renderer)) as Renderer;
        cardinalMaterial = cardinalRenderer.material;

        ColorUtility.TryParseHtmlString("#B4B4B4", out baseGrey);

        //animator.SetInteger("hop", 1);
        //myAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {   // happens only when cardinal is active.
        float step = speed * Time.deltaTime;

        gyroRot = gyro.rotationRate;
        compassval = compass.trueHeading;
        orientation = Input.deviceOrientation;




        if (currentlyFlying == true)
        {
            //going to need to be able to tell when I want to do this, and whether I should be rotating, etc.
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, step);
        }
        if(orientation == targetOrientation)
        {
            animator.SetTrigger("ruffle");
        }
        if (compassval < 180 && compassval > 90) //&& havesounded == false && reachedDestination == false
        {
            // need to time this
            //myAudio2.Play();
            //animator.SetTrigger("sing");
            //havesounded = true;
            //lastsounded = Time.time;
            cardinalMaterial.color = Color.yellow;
        }
        else
        {
            cardinalMaterial.color = baseGrey;
        }
        /*
        else if (Time.time - lastsounded > 5 && havesounded == true && reachedDestination == false)
        {
            // more than 5 seconds since last sounded, and we're out of the heading
            //resent havesounded
            havesounded = false;

        }
        */
        /*
        if (currentlyMoving == true && animator.GetInteger("hop") == 0)
        {
            animator.SetInteger("hop", 1);
        }*/
    }

    void FixedUpdate()
    {
        
    }

    public void CardinalEasyAR()
    {
        print("called from EasyAR");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spot1"))
        {
            //set the target to spot2.
            moveTarget = secondSpot.transform.position;
            transform.LookAt(moveTarget);
            //animator.SetTrigger("ruffle");

        }
        else if (other.gameObject.CompareTag("Spot2"))
        {
            moveTarget = thirdSpot.transform.position;
            transform.LookAt(moveTarget);
        }
        else if (other.gameObject.CompareTag("Spot3"))
        {
            moveTarget = fourthSpot.transform.position;
            transform.LookAt(moveTarget);
        }
        else if (other.gameObject.CompareTag("Spot4"))
        {
            print("in final position");
            reachedDestination = true;
            //GetComponent<AudioSource>().Play();
            myAudio.Play(); 

            currentlyMoving = false;
            animator.SetTrigger("sing");
        }
    }

}
