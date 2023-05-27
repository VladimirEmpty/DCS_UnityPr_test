using UnityEngine;

using Code.Settings;
using Code.Units;

namespace Code.UnitMovement
{
    public sealed class PlayerMovement : IUnitMovement
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        public float Speed { get; set; }

        public void Move(Unit owner)
        {
            //LOOK
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
            {                
                var point = hit.point;
                point.y = owner.transform.position.y;

                owner.transform.forward = point - owner.transform.position;
            }

            //MOVE
            var movePosition = Vector3.zero;
            movePosition += owner.transform.forward * Input.GetAxis(Vertical) * Speed;
            movePosition += owner.transform.right * Input.GetAxis(Horizontal) * Speed;
            movePosition.y = owner.Rigidbody.velocity.y;

            owner.Rigidbody.velocity = movePosition;

            //TEST
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }
}
