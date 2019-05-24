using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float pressInterval = .3f; // How long until player can do input.
    [SerializeField] private float turnSpeed = 10f; // How fast the boat turns
    [SerializeField] private float acceleration = 10f; // How fast the boat moves

    [SerializeField] private Rigidbody _rbody; // Referencing rigidbody that is attached to boat
    private float _timesSincePress;
    [SerializeField] private AudioSource _source; // Referencing Audio Source
    
    [SerializeField] private Animator _anim;
    [SerializeField] private ParticleSystem _movement;


    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
        _movement.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _timesSincePress += Time.fixedDeltaTime;
        
        //Giving Forward force so that player can move forward
        float forwardForce = 0;
        //Giving Directional force so that the player can move clockwise/ anti-clockwise
        float directionalForce = 0;

        //Controls for Mouse Input
        if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1)) && _timesSincePress > pressInterval)
        {
            _timesSincePress = 0;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                _anim.SetTrigger("LeftRow");
                _source.Play();
                _movement.Play();
                directionalForce = -4f;
                forwardForce = 4;
            }
            
            if (Input.GetKey(KeyCode.Mouse1))
            {
                _anim.SetTrigger("RightRow");
                _source.Play();
                _movement.Play();
                directionalForce = 4f;
                forwardForce = 4;
            }
        }
        //Controls for Controller Input
        else if ((Mathf.Abs(Input.GetAxis("Xbox L2")) > 0.8 || Mathf.Abs(Input.GetAxis("Xbox R2")) > 0.8) && _timesSincePress > pressInterval)
        {
            _timesSincePress = 0;

            if (Mathf.Abs(Input.GetAxis("Xbox L2")) > 0.8)
            {
                _anim.SetTrigger("LeftRow");
                _source.Play();
                _movement.Play();
                directionalForce = -4f;
                forwardForce = 4;
            }

            if (Mathf.Abs(Input.GetAxis("Xbox R2")) > 0.8)
            {
                _anim.SetTrigger("RightRow");
                _source.Play();
                _movement.Play();
                directionalForce = 4f;
                forwardForce = 4;
            }
            
        }
        
        _rbody.AddForce(transform.forward * forwardForce * acceleration * Time.deltaTime);
        //rbody.transform.Rotate(new Vector3(0,directionalForce * turnSpeed,0));
        _rbody.AddTorque(0f, directionalForce * turnSpeed * Time.deltaTime, 0f);
    }
}