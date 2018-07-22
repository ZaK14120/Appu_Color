/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using System.Collections;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    /// 
   
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler

    {

        string[] urls;
        int url_index;
        //------------Begin Sound----------

        // public AudioSource soundTarget;
        // public AudioClip clipTarget;

        //private AudioSource[] allAudioSources;

        //function to stop all sounds

        // void StopAllAudio()

        // {

        //    allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        //  foreach (AudioSource audioS in allAudioSources)

        //   {

        //      audioS.Pause();

        //    }

        // }

        //function to play sound

        //  void playSound(string ss)

        //{

        //    clipTarget = (AudioClip)Resources.Load(ss);

        //   soundTarget.clip = clipTarget;

        //   soundTarget.loop = true;

        //  soundTarget.playOnAwake = true;

        //  soundTarget.Play();

        //}

        //-----------End Sound------------ 

        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            urls = new string[] { "https://youtu.be/niT7UhXlOZI", "https://youtu.be/cE5aHG4yC20", "https://youtu.be/DQipZoJpBSY" };

            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
           

            //  soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();

        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");


            //  soundTarget.clip = clipTarget;
            //  soundTarget.Play();

            //Play Sound, IF detect an target 


            if (mTrackableBehaviour.TrackableName == "ganeshasticker")

            {

            //	playSound("sounds/Bg on AR");

            }

            url_index = Random.Range(0, urls.Length);
            StartCoroutine(openURL());
            

            //string[] Urls = { "https://youtu.be/niT7UhXlOZI", "https://youtu.be/cE5aHG4yC20", "https://youtu.be/DQipZoJpBSY" };

            //Application.OpenURL(Urls.RandomItem());

               //         if (mTrackableBehaviour.TrackableName == "apu1")
               //         {
               //             Application.OpenURL("https://youtu.be/niT7UhXlOZI");
            			//} 

            			//if (mTrackableBehaviour.TrackableName == "apu2")
            	  //      {
           				//    Application.OpenURL("https://youtu.be/cE5aHG4yC20");
            			//} 

            			//if (mTrackableBehaviour.TrackableName == "apu3")
            			//{
            			//	Application.OpenURL("https://youtu.be/DQipZoJpBSY");
            			//} 

            			//if (mTrackableBehaviour.TrackableName == "apu4")
            			//{
            		 //       Application.OpenURL("https://youtu.be/UyI1rO4sk-Q");
            	  //       } 

            		 //   if (mTrackableBehaviour.TrackableName == "apu5")
            		 //    {
            			//    Application.OpenURL("https://youtu.be/L7v0Q_rxytY");
            		 //    } 

        }

        IEnumerator openURL()
        {
            yield return new WaitForSeconds(2f);
            Application.OpenURL(urls[url_index]);
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            StopCoroutine(openURL());
            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

           // soundTarget.Stop();

          //  StopAllAudio();

        }

        #endregion // PRIVATE_METHODS
    }
}
