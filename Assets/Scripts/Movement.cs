using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float speed, SlowWalkSpeed;
    // public static Material mat;
    public Transform center;
    public static float InvisibilityAlpha;
    NewControls controls;
    public static int TotalKillsDuringGameplay;
    private Vector3 move, look;
    public static Vector3 movementDirection, lookDirection;
    //private CharacterController controller;
    private Rigidbody _rb;
    public static int EnemysKilled = 0;
    public static TextMeshProUGUI EnemyKilledTxt;
    public TextMeshProUGUI CooldownTxt, RunningTxt;
    private Animator _anims;
    [SerializeField] private float RotTime, AIRotTime;
    private bool StopMovement = false;
    public bool isSlowWalking = false;
    public float time, time2;
    private float DurationOfInvisibility, DurationOfCooldown;
    private bool StartTimer = false, ApplyCooldown = false;
    public static Color thisColour;
    private float OriginalAlpha;
    public GameObject Player, Sword;
    public static bool PlayerIsInvisible = false;
    public static bool isSpotted = false;
    public GameObject Smoke;
    public static bool Pause = false;
    public GameObject PauseMenuGO, OptionsMenu, RemapMenu, ControlsMenu;
    public Button resumeBtn;
    public static float rotSpeed;
    private float OriginalSpeed;
    ThrowingKnife k;
    public float radius, distance;
    public static bool CanActivateInvisibility = true;
    public Transform cmCam;
    private int layermask;
    [SerializeField] InputActionReference InvisibilityRef;
    private float CanInvisibility;
    public static bool Moving = false, HitEnemy = false, MissEnemy = false;
    public Material OpaqueMat, TransparentMat;
    public static float TimeInvisible;
    private void OnTriggerStay(Collider other)
    {
        /*if (other.gameObject.CompareTag("EnemyCollider"))
        {
            if (Gamepad.current.rightTrigger.isPressed)
            {
                Destroy(other.transform.parent.gameObject);
                EnemysKilled++;
                EnemyKilledTxt.text = "Enemys Killed: " + EnemysKilled.ToString();
            }
        }*/
        if (other.gameObject.CompareTag("NoiseDetector"))
        {
            /* if (Physics.Raycast(center.position, center.forward, out RaycastHit hit, distance))
             {
                 if (hit.collider.gameObject.CompareTag("Enemy"))
                 {
                     if (Gamepad.current.rightTrigger.isPressed)
                     {
                         Destroy(hit.collider.gameObject);
                         //Destroy(other.transform.parent.gameObject);
                         EnemysKilled++;
                         EnemyKilledTxt.text = "Enemys Killed: " + EnemysKilled.ToString();
                     }
                 }
             }
             if (Physics.Raycast(center.position + new Vector3(-1,0,0), center.forward, out RaycastHit hit2, distance))
             {
                 if (hit2.collider.gameObject.CompareTag("Enemy"))
                 {
                     if (Gamepad.current.rightTrigger.isPressed)
                     {
                         Destroy(hit2.collider.gameObject);
                         //Destroy(other.transform.parent.gameObject);
                         EnemysKilled++;
                         EnemyKilledTxt.text = "Enemys Killed: " + EnemysKilled.ToString();
                     }
                 }
             }
             if (Physics.Raycast(center.position + new Vector3(1,0,0), center.forward, out RaycastHit hit3, distance))
             {
                 if (hit3.collider.gameObject.CompareTag("Enemy"))
                 {
                     if (Gamepad.current.rightTrigger.isPressed)
                     {
                         Destroy(hit3.collider.gameObject);
                         //Destroy(other.transform.parent.gameObject);
                         EnemysKilled++;
                         EnemyKilledTxt.text = "Enemys Killed: " + EnemysKilled.ToString();
                     }
                 }
             }*/
            Collider[] hitColliders = Physics.OverlapSphere(center.position + center.forward * distance, radius);
            foreach (Collider go in hitColliders)
            {
                if (go.CompareTag("Enemy"))
                {
                    if (Gamepad.current.rightTrigger.isPressed)
                    {
                        HitEnemy = true;
                        Destroy(go.gameObject);
                        //Destroy(other.transform.parent.gameObject);
                        EnemysKilled++;
                        TotalKillsDuringGameplay++;
                        PlayerPrefs.SetInt("TotalKills", TotalKillsDuringGameplay);
                        PlayerPrefs.Save();
                        EnemyKilledTxt.text = "Enemys Killed: " + EnemysKilled.ToString();
                    }
                    print("HIT");
                }
            }
            if (!isSlowWalking && !PlayerIsInvisible && move != Vector3.zero)//if player is moving normally and isnt invisible
            {
                //other.transform.parent.gameObject.transform.LookAt(transform.position);
                // AI._agent.isStopped = true;
                //other.GetComponentInParent<AI>._isStopped = true;
                other.gameObject.GetComponentInParent<NavMeshAgent>().isStopped = true;
                other.gameObject.GetComponentInParent<Animator>().SetFloat("Blend", 0);
                //other.GetComponent<AI>._agent.isStopped = true;
                //other.transform.parent.rotation = Quaternion.Slerp(other.transform.parent.rotation, Quaternion.LookRotation(transform.position - other.transform.parent.position), AIRotTime);
                other.transform.parent.rotation = Quaternion.RotateTowards(other.transform.parent.rotation, Quaternion.LookRotation(transform.position - other.transform.parent.position), AIRotTime);
            }
            else
            {
                if (other.transform.parent.gameObject.activeInHierarchy)
                {
                    other.gameObject.GetComponentInParent<NavMeshAgent>().isStopped = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NoiseDetector"))
        {
            isSpotted = false;
            other.gameObject.GetComponentInParent<NavMeshAgent>().isStopped = false;
        }
    }
    private void Awake()
    {
        layermask = 1 << 8;
        EnemysKilled = 0;
        controls = new NewControls();
        TotalKillsDuringGameplay = PlayerPrefs.GetInt("TotalKills");
        TimeInvisible = PlayerPrefs.GetFloat("TimeInvisible");
        LineofSight.AmountOfTimesCaptured = PlayerPrefs.GetInt("AmountOfTimesCaptured");
        InvisibilityRef.action.performed += ctx => CanInvisibility = ctx.ReadValue<float>();
        InvisibilityRef.action.canceled += ctx => CanInvisibility = 0;
        controls.Newactionmap.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Newactionmap.Move.canceled += ctx => move = Vector2.zero;
        controls.Newactionmap.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.Newactionmap.Look.canceled += ctx => look = Vector2.zero;
        // controls.Newactionmap.SlowWalk.performed += ctx => isSlowWalking = true;
        // controls.Newactionmap.SlowWalk.canceled += ctx => isSlowWalking = false;
    }
    private void OnEnable()
    {
        controls.Newactionmap.Enable();
        InvisibilityRef.action.Enable();
    }
    private void OnDisable()
    {
        controls.Newactionmap.Disable();
        InvisibilityRef.action.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.Save();
        PlayerIsInvisible = false;
        DurationOfInvisibility = 5f;
        DurationOfCooldown = 10f;
        EnemyKilledTxt = GameObject.Find("EnemyKilledText").GetComponent<TextMeshProUGUI>();
        k = gameObject.GetComponent<ThrowingKnife>();
        OriginalSpeed = speed;
        _rb = gameObject.GetComponent<Rigidbody>();
        // controller = gameObject.GetComponent<CharacterController>();
        _anims = gameObject.GetComponent<Animator>();
        thisColour = Color.red;
        //thisColour = GetComponent<SpriteRenderer>().color;
        InvisibilityAlpha = 0.2f;//0.2f
        OriginalAlpha = 1;

        //mat = Player.GetComponent<SkinnedMeshRenderer>().material;
        Physics.IgnoreLayerCollision(6, 7, false);
    }

    private void FixedUpdate()
    {
        if (!StopMovement)
        {
            CalculateMovement();
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
        if (_rb.velocity.sqrMagnitude > 0)
        {
            Moving = true;
        }
        else
        {
            Moving = false;
        }
    }
    private void Update()
    {
        /*Debug.DrawRay(center.position + new Vector3(-1, 0, 0), center.forward * distance, Color.green);
        Debug.DrawRay(center.position + new Vector3(1, 0, 0), center.forward * distance, Color.green);
        Debug.DrawRay(center.position + new Vector3(0.5f, 0, 0), center.forward * distance, Color.green);
        Debug.DrawRay(center.position + new Vector3(-0.5f, 0, 0), center.forward * distance, Color.green);
        Debug.DrawRay(center.position, center.forward * distance, Color.green);*/
        //Check for player inputs, Applied movement is in fixedupdate
        movementDirection = new(move.x, 0, move.y);
        // print(look.x);
        movementDirection.Normalize();

        Rotations();


        if (!Pause)
        {
            Animations();
        }
        if (!StartTimer)
        {
            if (!TriggerSmokeBomb.InSmoke)
            {
                CanActivateInvisibility = true;
            }
            if (CanInvisibility > 0 && !Pause && CanActivateInvisibility && !ApplyCooldown && !PlayerIsInvisible)
            {
                StartTimer = true;
                time = 0;
                time2 = 0;
            }
        }
        if (StartTimer)
        {
            CanActivateInvisibility = false;
            DurationOfInvisibility -= Time.deltaTime;
            TimeInvisible += Time.deltaTime;
            PlayerPrefs.SetFloat("TimeInvisible", TimeInvisible);
            if (DurationOfInvisibility <= 0)
            {
                ApplyCooldown = true;
                PlayerIsInvisible = false;
                DurationOfInvisibility = 5f;
                Physics.IgnoreLayerCollision(6, 7, false);
            }
            else
            {
                PlayerIsInvisible = true;
                Physics.IgnoreLayerCollision(6, 7, true); //Make player not collide with walls when invisible
            }
        }
        CooldownTxt.SetText("Invisibility Timer: " + DurationOfCooldown.ToString("F2"));
        RunningTxt.SetText("Invisibility Cooldown: " + DurationOfInvisibility.ToString("F2"));
        if (ApplyCooldown)
        {
            StartTimer = false;
            DurationOfCooldown -= Time.deltaTime;
            if (DurationOfCooldown <= 0)
            {
                ApplyCooldown = false;
                StartTimer = false;
                DurationOfCooldown = 10f;
            }
        }
        if (PlayerIsInvisible)
        {
            print("SET THIS");
            Player.GetComponent<SkinnedMeshRenderer>().material = TransparentMat;
            //SetupMaterialWithBlendMode(mat, 3);
            //thisColour.a = 0;
        }
        else if (!PlayerIsInvisible)
        {
            Player.GetComponent<SkinnedMeshRenderer>().material = OpaqueMat;
            //SetupMaterialWithBlendMode(mat, 0);
        }
        if (Pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        if (!isSlowWalking)
        {
            speed = OriginalSpeed;
        }
        if (isSlowWalking)
        {
            speed = SlowWalkSpeed;
            if (move == Vector3.zero)
            {
                isSlowWalking = false;
            }
        }
    }

    public void OnSlowWalk()
    {
        if (!isSlowWalking)
        {
            isSlowWalking = true;
        }
        else
        {
            isSlowWalking = false;
        }
    }

    private void CalculateMovement()
    {
        /* print(move.x);
         if(move.x == 1)
         {
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection + transform.right;
         }
         else if(move.x == -1)
         {
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection - transform.right;
         }
         if(move.y == 1)
         {
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection + transform.forward;
         }
         else if(move.y == -1)
         {
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection - transform.forward;
         }
         if (move == Vector3.zero)
         {
             _rb.velocity = Vector3.zero;
             //movementDirection = Vector3.zero;
             //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), RotTime);
         }
         if(movementDirection != Vector3.zero && look == Vector3.zero)
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), RotTime);
         }
         if(look != Vector3.zero)
         {
             transform.Rotate(0, look.x * rotSpeed, 0);
         }
         _rb.velocity = speed * Time.fixedDeltaTime * movementDirection + transform.forward;*/
        /* if (k.EnableThrowingKnifeMode)
         {
             transform.Rotate(transform.up * look.x * rotSpeed);
             Vector3 ForwardMovement = transform.forward;
             Vector3 RightMovement = transform.right;
             ForwardMovement.y = 0;
             RightMovement.y = 0;
             Vector3 ForwardMovementY = move.y * ForwardMovement;
             Vector3 ForwardMovementX = move.x * RightMovement;
             Vector3 MovementBasedOnCamera = ForwardMovementY + ForwardMovementX;
             _rb.velocity = speed * Time.fixedDeltaTime * MovementBasedOnCamera.normalized;
             if (MovementBasedOnCamera == Vector3.zero)
             {
                 return;
             }
         }
         else
         {
             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), RotTime);
             _rb.velocity = speed * Time.fixedDeltaTime * movementDirection;
         }*/
        //_rb.MoveRotation(look.x * rotSpeed * transform.up);
        //transform.Rotate(look.x * rotSpeed * transform.up);
        if (move != Vector3.zero)
        {
            Vector3 ForwardMovement = transform.forward;
            Vector3 RightMovement = transform.right;
            ForwardMovement.y = 0;
            RightMovement.y = 0;
            Vector3 ForwardMovementY = move.y * ForwardMovement;
            Vector3 ForwardMovementX = move.x * RightMovement;
            Vector3 MovementBasedOnCamera = ForwardMovementY + ForwardMovementX;
            _rb.AddForce(speed * Time.fixedDeltaTime * MovementBasedOnCamera.normalized, ForceMode.VelocityChange);
            //_rb.velocity = speed * Time.fixedDeltaTime * MovementBasedOnCamera.normalized;
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }

    }
    private void Animations()
    {
        if (move.x == 0 && move.y == 0)
        {
            _anims.SetFloat("Movement", 0); //Idle Animation
        }
        if (!isSlowWalking && move.x != 0 || move.y != 0)
        {
            _anims.SetFloat("Movement", 0.5f); //Sprint Animation
        }
        else if (isSlowWalking && move.x != 0 || move.y != 0)
        {
            _anims.SetFloat("Movement", 1); //Walk Animation
        }
        if (Gamepad.current.rightTrigger.wasPressedThisFrame && !k.EnableThrowingKnifeMode)//Play attack anim on f key press
        {
            _anims.SetTrigger("Attack");
            if (!HitEnemy)
            {
                MissEnemy = true;
            }
        }
        if (_anims.GetCurrentAnimatorStateInfo(0).IsName("RightHand@Attack01")) //Checks if Attack animation is running
        {
            StopMovement = true;
        }
        else
        {
            StopMovement = false;
        }
    }

    private void Rotations()
    {
        if (look.x == 0)
        {
            _rb.freezeRotation = true;
        }
        else if (look.x != 0)
        {
            _rb.freezeRotation = false;
            //transform.localRotation = Quaternion.Euler(lookDirection);
            // float angleA = Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg;
            // _rb.MoveRotation(_rb.rotation * Quaternion.AngleAxis(angleA, transform.forward));
            //transform.rotation = Quaternion.Euler(0f, angleA, 0f);
            //_rb.MoveRotation(_rb.rotation * Quaternion.Euler(lookDirection * rotSpeed));
            float LookingX = look.x * Time.deltaTime * rotSpeed;
            //transform.Rotate(Vector3.up, LookingX);
            //cmCam.localRotation *= Quaternion.Euler(0f, LookingX, 0f);
            var rotateValue = new Vector3(0f, LookingX * -1f, 0f);
            cmCam.eulerAngles -= rotateValue;
        }
        var CharacterRotation = cmCam.rotation;
        CharacterRotation.x = 0;
        CharacterRotation.z = 0;
        transform.rotation = CharacterRotation;
    }

    public void OnPause()
    {
        if (Pause)
        {
            Pause = false;
            PauseMenuGO.SetActive(false);
            OptionsMenu.SetActive(false);
            RemapMenu.SetActive(false);
            ControlsMenu.SetActive(false);
            ThrowingKnife.KnifeThrown = false;
            Movement.MissEnemy = false;
            Movement.HitEnemy = false;
        }
        else
        {
            Pause = true;
            PauseMenuGO.SetActive(true);
            resumeBtn.Select();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(center.position + center.forward * distance, radius);
    }

    public static void SetupMaterialWithBlendMode(Material material, int blendMode)
    {
        switch (blendMode)
        {
            case 0://Opaque
                material.SetOverrideTag("RenderType", "Opaque");
                material.SetFloat("_Mode", 0);
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case 1://CutOut
                material.SetOverrideTag("RenderType", "Cutout");
                material.SetFloat("_Mode", 1);
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case 2://Fade
                material.SetOverrideTag("RenderType", "Fade");
                material.SetFloat("_Mode", 2);
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case 3://Transparent
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetFloat("_Mode", 3);
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }

    }
}
