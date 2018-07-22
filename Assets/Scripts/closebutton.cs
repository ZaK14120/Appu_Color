using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using waqashaxhmi.AndroidNativePlugin;
using System.Runtime.InteropServices;
using System;


namespace Assets.SimpleAndroidNotifications
{

    public class closebutton : MonoBehaviour
    {

        public GameObject xbutton;
        public GameObject disclaimer;
        public GameObject dis_button;
        public GameObject instructions;
        public int throttle = 0;


        // Use this for initialization

        IEnumerator Start()
        {
            //NotificationManager.Send(TimeSpan.FromSeconds(3600), "We are missing you", "Scan for more Magic", new Color(1, 0.3f, 0.15f));

            var notificationParams = new NotificationParams
            {
                Id = UnityEngine.Random.Range(0, int.MaxValue),
                Delay = TimeSpan.FromSeconds(5),
                Title = "We are missing you",
                Message = "Come Scan for more Magic",
                Ticker = "Experience Augmented Reality",
                Sound = true,
                Vibrate = true,
                Light = true,
                SmallIcon = NotificationIcon.Heart,
                SmallIconColor = new Color(0, 0, 0.5f),
                LargeIcon = "app_icon"
            };

            NotificationManager.SendCustom(notificationParams);

            yield return new WaitForSeconds(7);
            instructions.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void disabledisclaimer()
        {
            xbutton.SetActive(false);
            disclaimer.SetActive(false);
            dis_button.SetActive(true);
        }

        public void enabledisclaimer()
        {
            xbutton.SetActive(true);
            disclaimer.SetActive(true);
            dis_button.SetActive(false);
        }
        void OnApplicationPause()
        {
            NotificationManager.Send(TimeSpan.FromSeconds(1), "We are missing you", "Scan for more Magic", new Color(1, 0.3f, 0.15f));

            Debug.Log("Application ending after " + Time.time + " seconds");
           //AndroidNativePluginLibrary.Instance.ShowToast("This is a Toast");

           throttle++;
           if (throttle > 5) {
       
             xbutton.SetActive(true);
         }
         }
        //public void ScheduleSimple()
        //{
           // NotificationManager.Send(TimeSpan.FromSeconds(5), "We are missing you", "Scan for more Magic", new Color(1, 0.3f, 0.15f));
       // }


    }
}
