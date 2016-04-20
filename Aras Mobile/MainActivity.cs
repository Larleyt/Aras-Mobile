using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Aras_Mobile
{
    [Activity(Label = "Aras Mobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnLogin;
        private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBtnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBarLogin);

            mBtnLogin.Click += (object sender, EventArgs args) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_sign_in signInDialog = new dialog_sign_in();
                signInDialog.Show(transaction, "dialog fragment");

                signInDialog.mOnSignInComplete += SignInDialog_mOnSignInComplete;
            };

        }

        private void SignInDialog_mOnSignInComplete(object sender, OnSignInEventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            // Thread
            //RunOnUiThread(() => {
            //    mProgressBar.Visibility = ViewStates.Invisible;
            //}
        }
    }
}

