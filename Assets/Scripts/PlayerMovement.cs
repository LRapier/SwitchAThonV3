using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    Renderer rend;
    public GameObject player;
    public ParticleSystem polPart;
    public float forwardForce = 2000f;
    public float sideForce = 3000f;

    public bool polarity = true;
    public Material posMat;
    public Material negMat;
    public int posLayer;
    public int negLayer;

    void Start()
    {
        rend = GetComponent<Renderer>();
        posLayer = LayerMask.NameToLayer("Positive");
        negLayer = LayerMask.NameToLayer("Negative");
    }

    void Update()
    {
        /*if (Input.GetKeyDown("space"))
        {
            TogglePolarity();
        }*/
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
    }

    public void MoveRight()
    {
        rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void MoveLeft()
    {
        rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void TogglePolarity()
    {
        if (polarity)
        {
            polarity = false;
            rend.sharedMaterial = negMat;
            player.layer = negLayer;
        }
        else if (!polarity)
        {
            polarity = true;
            rend.sharedMaterial = posMat;
            player.layer = posLayer;
        }
        PolarityParticles();
    }

    public void PolarityParticles()
    {
        if(polarity)
        {
            polPart.startColor = Color.red;
        }
        else
        {
            polPart.startColor = Color.cyan;
        }
        polPart.Play();
    }

    public void ResetPosition()
    {
        polarity = true;
        rend.sharedMaterial = posMat;
        player.layer = posLayer;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
        transform.position = new Vector3(0.0f, 1.6f, 0.0f);
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
    }
}
