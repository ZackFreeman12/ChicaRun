using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ChicaRun
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;
        [SerializeField]
        private Rigidbody rb;
        private Vector3 playerPos;
        [SerializeField]
        private CinemachineVirtualCamera cam;
        private Cinemachine3rdPersonFollow camBody;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float jumpForce;
        public bool isGrounded;
        [SerializeField]
        private CapsuleCollider capsuleCollider;
        private bool slide;
        private Vector2 startTouchPosition;
        private Vector2 endTouchPosition;

        private bool dead = false;

        [SerializeField]
        private Animator animator;

        private float swipeLengthRequired = 150f;

        void Start()
        {
            camBody = cam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

        }

        void FixedUpdate()
        {

            if (!dead)
            {
                Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
                rb.MovePosition(transform.position + forwardMove);
            }

        }

        void Update()
        {
            if (!dead)
            {
                //Reset player collider size if the player is not sliding
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Running Slide") && slide)
                {
                    Debug.Log("Reset");
                    capsuleCollider.center = new Vector3(-0.02705574f, 1.274797f, 0);
                    capsuleCollider.height = 2.561244f;
                    camBody.ShoulderOffset = new Vector3(0, 3.3f, -2f);
                    slide = false;
                }

                if (Input.GetKeyDown("a"))
                {
                    if (rb.transform.position.x! >= -1)
                    {

                        MoveLeft();

                    }
                }

                if (Input.GetKeyDown("d"))
                {
                    if (rb.transform.position.x! <= 1)
                    {

                        MoveRight();

                    }
                }

                if (Input.GetKeyDown("s"))
                {
                    Slide();
                }

                if (Input.GetKeyDown("space"))
                {
                    Jump();
                }

                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startTouchPosition = Input.GetTouch(0).position;
                }

                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {

                    Debug.Log(startTouchPosition);
                    Debug.Log(endTouchPosition);

                    endTouchPosition = Input.GetTouch(0).position;
                    float horizontalSwipeLeft = startTouchPosition.x - endTouchPosition.x;
                    float verticalSwipeDown = startTouchPosition.y - endTouchPosition.y;
                    float horizontalSwipeRight = endTouchPosition.x - startTouchPosition.x;
                    float verticalSwipeUp = endTouchPosition.y - startTouchPosition.y;


                    if (endTouchPosition.x < startTouchPosition.x && (startTouchPosition.x - endTouchPosition.x) > swipeLengthRequired)
                    {
                        if (rb.transform.position.x! >= -1)
                        {

                            MoveLeft();

                        }

                    }

                    if (endTouchPosition.x > startTouchPosition.x && (endTouchPosition.x - startTouchPosition.x) > swipeLengthRequired)
                    {
                        if (rb.transform.position.x! <= 1)
                        {

                            MoveRight();

                        }
                    }

                    if (endTouchPosition.y < startTouchPosition.y && (startTouchPosition.y - endTouchPosition.y) > swipeLengthRequired)
                    {
                        Slide();
                    }

                    if (endTouchPosition.y > startTouchPosition.y && (endTouchPosition.y - startTouchPosition.y) > swipeLengthRequired)
                    {
                        Jump();
                    }

                }
            }
            else
            {
                if (Input.touchCount > 0 || Input.GetKeyDown("m"))
                {
                    SceneManager.LoadSceneAsync("MainMenu");
                }
            }


        }


        private void Slide()
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Running Slide") && isGrounded && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump Backward") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump Backward 0"))
            {
                animator.ResetTrigger("Slide");
                animator.SetTrigger("Slide");
                Debug.Log("Slide");
                capsuleCollider.center = new Vector3(-0.02705574f, 0.712834f, 0);
                capsuleCollider.height = 1.437318f;
                camBody.ShoulderOffset = new Vector3(0, 0.9f, -2f);
                slide = true;

            }
        }

        private void Jump()
        {
            if (isGrounded && !animator.GetCurrentAnimatorStateInfo(0).IsName("Running Slide"))
            {
                animator.ResetTrigger("Jump");
                animator.SetTrigger("Jump");
                Debug.Log("Jump");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

        }
        private void MoveLeft()
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Running Slide") && isGrounded)
            {
                animator.ResetTrigger("SideStep");
                animator.SetTrigger("SideStep");
                rb.transform.position = new Vector3(player.transform.position.x - 2, player.transform.position.y, player.transform.position.z);
            }

        }

        private void MoveRight()
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Running Slide") && isGrounded)
            {
                animator.ResetTrigger("SideStep");
                animator.SetTrigger("SideStep");
                rb.transform.position = new Vector3(player.transform.position.x + 2, player.transform.position.y, player.transform.position.z);
            }
        }


        public void Die()
        {
            animator.SetTrigger("Die");
            dead = true;
        }

        public void CorrectPlayerPos()
        {
            //rb.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
        }
    }
}

