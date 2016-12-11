using UnityEngine;

namespace UnitySampleAssets._2D
{

    public class Camera2DFollow : MonoBehaviour
    {

        public Transform target;
        public float damping = .5f;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.75f;
        public float lookAheadMoveThreshold = 0.05f;

        private float offsetZ;
        private Vector3 lastTargetPosition;
        private Vector3 currentVelocity;
        private Vector3 lookAheadPos;

        // Use this for initialization
        private void Start()
        {
			if(target == null) {
				target = GameObject.FindGameObjectWithTag ("Player").transform;
			}
            lastTargetPosition = target.position;
            offsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }

        // Update is called once per frame
        private void LateUpdate()
        {
			if (target) {
				// only update lookahead pos if accelerating or changed direction
				float xMoveDelta = (target.position - lastTargetPosition).x;

				bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;

				if (updateLookAheadTarget) {
					lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
				} else {
					lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
				}

				Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
				Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);

				transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);

				lastTargetPosition = target.position;
			} else {
				target = GameObject.FindGameObjectWithTag ("Player").transform;
			}
        }
    }
}