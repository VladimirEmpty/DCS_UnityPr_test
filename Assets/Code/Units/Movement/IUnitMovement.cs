using Code.Units;

namespace Code.UnitMovement
{
    public interface IUnitMovement
    {
        public float Speed { get; set; }
        void Move(Unit owner);
    }
}
