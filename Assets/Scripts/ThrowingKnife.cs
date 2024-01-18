using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ThrowingKnife : MonoBehaviour
{
    private Rigidbody _rb;
    public Transform ThrowingPoint;
    public Transform player;
    public GameObject Knife;
    public float RotTime;
    public bool ApplyCooldown = false;
    public float time, DurationOfCooldown;
    public float throwForce, throwUpForce;
    LineRenderer laserLine;
    public float LineDist;
    public bool EnableThrowingKnifeMode;
    private TextMeshProUGUI txt;
    public static int AmountOfKnives;
    [SerializeField] InputActionReference AimRef;
    private float Aim;
    public static bool KnifeThrown;
    public Transform Center;
    private void Awake()
    {
        AimRef.action.performed += ctx => Aim = ctx.ReadValue<float>();
        AimRef.action.canceled += ctx => Aim = 0;
    }
    private void OnEnable()
    {
        AimRef.action.Enable();
    }
    private void OnDisable()
    {
        AimRef.action.Disable();
    }

    private void Start()
    {
        AmountOfKnives = 3;
        laserLine = GetComponent<LineRenderer>();
        EnableThrowingKnifeMode = false;
        txt = GameObject.Find("KnifeText").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        txt.SetText("Knives Left: " + AmountOfKnives);
        if (Aim > 0)
        {
            EnableThrowingKnifeMode = true;
        }
        else
        {
            EnableThrowingKnifeMode = false;
        }
        if (EnableThrowingKnifeMode)
        {
            DrawLine();
        }
        else
        {
            laserLine.enabled = false;
        }

        if (!ApplyCooldown && AmountOfKnives>0)
        {
            if (Gamepad.current.rightTrigger.wasPressedThisFrame && EnableThrowingKnifeMode)
            {
                KnifeThrown = true;
                print("K PRessed");
                GameObject knife = Instantiate(Knife, ThrowingPoint.position, Quaternion.identity);
                AmountOfKnives--;
                knife.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 90f, transform.eulerAngles.z);
                //knife.transform.forward = gameObject.transform.forward + new Vector3(0,90,0);
                //knife.transform.rotation = Quaternion.LookRotation(Movement.movementDirection);
                _rb = knife.GetComponent<Rigidbody>();
                Vector3 Force = throwForce * transform.forward; //+ transform.up * throwUpForce;
                _rb.AddForce(Force, ForceMode.Impulse);
                ApplyCooldown = true;
                time = 0;
            }
        }
        if (ApplyCooldown)
        {
            time += Time.deltaTime;
            if (time > DurationOfCooldown)
            {
                ApplyCooldown = false;
            }
        }
    }

    void DrawLine()
    {
        laserLine.enabled = true;
        var NewPos = Center.position + new Vector3(0, -0.75f, 0);
        laserLine.SetPosition(0, NewPos);
        laserLine.startColor = Color.red;
        laserLine.endColor = Color.red;
        //laserLine.material.color = Color.red;
        if (Physics.Raycast(NewPos, Center.forward, out RaycastHit hit, LineDist))
        {
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            laserLine.SetPosition(1, NewPos + (Center.forward * LineDist));
        }
    }


    public void OnThrowingKnifeMode()
    {
        if (EnableThrowingKnifeMode)
        {
            EnableThrowingKnifeMode = false;
        }
        else
        {
            EnableThrowingKnifeMode = true;
        }
    }
}
