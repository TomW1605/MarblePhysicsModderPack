using MarblePhysics.Modding.Shared.Player;
using UnityEngine;
using UnityEngine.Events;

namespace MarblePhysics.Modding.StandardComponents
{
    public class Seat : MonoBehaviour
    {
        public UnityEvent<Marble> SeatTaken;
        
        public Marble Marble { get; private set; }
        
        public virtual bool TryTakeMarble(Marble marble)
        {
            if (this.Marble == null)
            {
                this.Marble = marble;
                marble.SetGameState(PlayerGameState.Finished);
                marble.Teleport(transform.position, false, true, false);
                return true;
            }

            
            return false;
        }
    }
}
