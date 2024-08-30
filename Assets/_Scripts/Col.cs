using UnityEngine.Events;
using UnityEngine;

namespace ChicaRun
{
    public class Col : MonoBehaviour
    {
        public PlayerController player;
        [SerializeField]
        private UnityEvent spawnEvent;
        [SerializeField]
        private UnityEvent dieEvent;
        [SerializeField]
        private UnityEvent coinEvent;

        [SerializeField]
        private bool spawnTriggerCollisionOccured = false;

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "spawnTrigger" && !spawnTriggerCollisionOccured)
            {
                spawnTriggerCollisionOccured = true;
                spawnEvent.Invoke();

            }

            if (col.gameObject.tag == "coin")
            {
                PlayerManager.instance.addCoin(1);
                Destroy(col.gameObject);
                //Debug.Log(PlayerManager.instance.coins);
            }

        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "obstacle")
            {
                dieEvent.Invoke();
            }

            if (col.gameObject.tag == "ground")
            {
                player.isGrounded = true;
            }
        }

        private void OnTriggerExit(Collider col)
        {
            spawnTriggerCollisionOccured = false;


        }

    }
}

