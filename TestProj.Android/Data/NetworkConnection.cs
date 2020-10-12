using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestProj.Data;
using TestProj.Droid.Data;

[assembly : Xamarin.Forms.Dependency(typeof(NetworkConnection))]

namespace TestProj.Droid.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected{ get; set; }
        public void CheckNetworkConnection()
        {
            var ConnectivityManeger = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActivityNetworkinfo = ConnectivityManeger.ActiveNetworkInfo;
            if (ActivityNetworkinfo != null)
            {
                //connected to the internet
                IsConnected = true;
            }
            else
            {
                //not connected to the internet
                IsConnected = false;
            }
        }
    }
}