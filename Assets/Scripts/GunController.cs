using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class GunController : MonoBehaviour
    {
        public Transform origin = null;
        public GameObject streamPrefab = null;
        public Target target = null;
        private Interactable interactable;

        private bool inHand = false;
        private GunStream currentStream = null;

        private bool isHittingTarget = false;

        private void Start()
        {
            this.interactable = gameObject.GetComponent<Interactable>();
        }

        private void Update()
        {
            bool shootingCheck = this.interactable != null && interactable.attachedToHand != null;
            if (inHand != shootingCheck)
            {
                this.inHand = shootingCheck;

                if(inHand)
                {
                    StartShooting();
                }
                else
                {
                    EndShooting();
                }
            }
            this.isHittingTarget = IsHittingTarget();
            this.target.setActive(this.isHittingTarget);
        }

        private void StartShooting()
        {
            currentStream = CreateStream();
            currentStream.Begin();
        }

        private void EndShooting()
        {
            currentStream.End();
            currentStream = null;
        }

        private GunStream CreateStream()
        {
            GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
            return streamObject.GetComponent<GunStream>();
        }

        public bool isShooting()
        {
            return this.inHand;
        }

        public bool IsHittingTarget()
        {
            if (this.inHand)
            {
                RaycastHit hit;
                Ray ray = new Ray(this.origin.transform.position, Vector3.forward);

                Physics.Raycast(ray, out hit, 5.0f);
                // UnityEngine.Debug.Log(hit.collider.tag + " " + gameObject.tag);
                if (hit.collider.tag == gameObject.tag)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }   
        }
    }
}