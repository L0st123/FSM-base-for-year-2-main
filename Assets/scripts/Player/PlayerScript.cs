using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        

        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public WalkingState walkingState;

        public StateMachine sm;
        public Animator animator;
        public float speed = 1f;
        public int moving;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();
            animator = gameObject.AddComponent<Animator>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
           
        }

        // Update is called once per frame
        public void Update()
        {
            print("state=" + sm.CurrentState);
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText("Press I for idle / R for run");

        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }


        public void Movement()
        {
            //left
            if (Input.GetKey("a") == true)
            {
                print("player pressed left");
                transform.position = new Vector2(transform.position.x - (1 * speed * Time.deltaTime), transform.position.y);
                animator.SetBool("walk", true);

                moving = 1;

            }
            //right
            else if (Input.GetKey("d") == true)
            {
                print("player pressed right");
                transform.position = new Vector2((1 * speed * Time.deltaTime) + transform.position.x, transform.position.y);
                animator.SetBool("walk", true);

                moving = 1;
            }

            else
            {
                animator.SetBool("walk", false);
            }
        }


        public void CheckForRun()
        {
            if (Input.GetKey("r")) // key held down
            {
                sm.ChangeState(runningState);
                
                return;
               
            }

        }


        public void CheckForIdle()
        {
            if (Input.GetKey("i") ) // key held down
            {
                sm.ChangeState(idleState);
            }

        }

        public void CheckForWalking()
        {
            if (Input.GetKey("w"))
            {
                sm.ChangeState(walkingState);
            }
        }

        public bool CheckForMoveKeys()
        {
            float x = Input.GetAxis("Horizontal");
            if ( x < -0.1f || x > 0.1f)
            {
                return true;
            }
            return false;
        }



    }

}