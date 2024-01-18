using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SmokeBomb : MonoBehaviour
{
    public GameObject smokeParticles;
    private bool ApplyCooldown = false;
    private float time = 5f, time2 = 7.5f;
    public float DurationOfCooldown;
    private bool CoroutineRunning = false, CooldownRunning = false;
    public TextMeshProUGUI CooldownTxt, RunningTxt;
    [SerializeField] InputActionReference SmokeRef;
    private float CanSmoke;
    //private GameObject smokeExplosion;
    private void Awake()
    {
        SmokeRef.action.performed += ctx => CanSmoke = ctx.ReadValue<float>();
        SmokeRef.action.canceled += ctx => CanSmoke = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        smokeParticles.SetActive(false);
        time = 5f;
        time2 = 7.5f;
    }
    private void OnEnable()
    {
        SmokeRef.action.Enable();
    }
    private void OnDisable()
    {
        SmokeRef.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad k = Gamepad.current;
        if (!ApplyCooldown)
        {
            if (CanSmoke > 0 && !Movement.Pause && !Movement.PlayerIsInvisible)//if b is pressed (SMOKE BOMB)
            {
                print("B pressed");
                smokeParticles.transform.position = transform.position;
                smokeParticles.SetActive(true);
                // smokeExplosion = Instantiate(smokeParticles, transform.position, transform.rotation);
                //Destroy(smokeExplosion, 5f);
                StartCoroutine(nameof(Delay), 5f);
                //StartCoroutine(nameof(Cooldown), 10f);
                ApplyCooldown = true;
            }
        }
        if (CoroutineRunning)
        {
            time -= Time.deltaTime;
            Movement.TimeInvisible += Time.deltaTime;
            PlayerPrefs.SetFloat("TimeInvisible", Movement.TimeInvisible);
        }
        if (CooldownRunning)
        {
            time2 -= Time.deltaTime;
        }
        CooldownTxt.SetText("Smoke Cooldown: " + time2.ToString("F2"));
        RunningTxt.SetText("Smoke Timer: " + time.ToString("F2"));
        /*if (ApplyCooldown)
        {
            time += Time.deltaTime;
            if (time > DurationOfCooldown)
            {
                ApplyCooldown = false;
            }
        }*/
    }

    IEnumerator Delay(float delay)
    {
        CoroutineRunning = true;
        yield return new WaitForSeconds(delay);
        CoroutineRunning = false;
        smokeParticles.SetActive(false);
        TriggerSmokeBomb.InSmoke = false;
        Movement.PlayerIsInvisible = false;
        time = 5;
        StartCoroutine(nameof(Cooldown), 7.5f);
        print("DONE");
    }
    IEnumerator Cooldown(float cdelay)
    {
        CooldownRunning = true;
        yield return new WaitForSeconds(cdelay);
        CooldownRunning = false;
        ApplyCooldown = false;
        time2 = 7.5f;
        print("COOLDOWN OVER");
    }
}
