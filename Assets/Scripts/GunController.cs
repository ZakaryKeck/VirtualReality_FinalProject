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
        private Interactable interactable;

        private bool inHand = false;
        private GunStream currentStream = null;

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
    }
}