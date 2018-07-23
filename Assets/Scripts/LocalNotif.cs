using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.SimpleAndroidNotifications
{
    public class LocalNotif : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnApplicationQuit()
        {
            NotificationManager.SendWithAppIcon(TimeSpan.FromMinutes(5), "We are missing you", "Come Scan for more Magic", new Color(0, 0.6f, 1), NotificationIcon.Message);
        }
    }
}
