using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Player
{

    public class WalkingState : State
    { 
        Animator animator;
        PlayerScript player;
        public WalkingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {

        }

        public override void Enter()
        {
            base.Enter();

            // animations etc movemnt in here


            player.Movement();


            


        }
        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            player.CheckForIdle();
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }
      

    }
}
