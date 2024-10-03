
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {

       
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
         
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
            //player.CheckForWalking();

            if( player.CheckForMoveKeys() == true )
            {
                player.sm.ChangeState(player.walkingState);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}