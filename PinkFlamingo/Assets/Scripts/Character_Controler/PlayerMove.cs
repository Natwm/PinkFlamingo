using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName, verticalInputName;
    [SerializeField] private float movementSpeed;

    public CharacterController charController;

    public bool isJumping = false;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    public LayerMask interuptMask;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        JumpInput();
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3F, interuptMask);
   if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
            {
            hit.collider.gameObject.GetComponent<Interupteur>().ChangeStatus();
        }
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        float timeInAir = 0f;
        do
        {
            float jumpforce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpforce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded  && charController.collisionFlags != CollisionFlags.Above);

        isJumping = false;

    }
}
