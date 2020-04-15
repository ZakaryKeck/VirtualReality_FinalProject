using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ReturnToOrigin : MonoBehaviour
    {
        private bool outOfOrigin = false;
        private bool inHand = false;
        private Vector3 originPosition;
        private Quaternion originRotation;
        private Interactable interactable;

        // Start is called before the first frame update
        void Start()
        {
            this.interactable = gameObject.GetComponent<Interactable>();
            Transform trans = gameObject.GetComponent<Transform>();
            this.originPosition = trans.position;
            this.originRotation = trans.rotation;
        }

        // Update is called once per frame
        void Update()
        {
            if (this.interactable != null && interactable.attachedToHand != null)
            {
                this.inHand = true;
            }
            else
            {
                this.inHand = false;
            }

            if (this.outOfOrigin && !this.inHand)
            {
                gameObject.transform.position = this.originPosition;
                gameObject.transform.rotation = this.originRotation;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                this.outOfOrigin = false;
            }
        }

        void OnTriggerExit()
        {
            this.outOfOrigin = true;
        }

    }
}
