using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Aras_Mobile
{
    public class OnSignInEventArgs : EventArgs
    {
        private string mLogin;
        private string mPassword;

        public string Login
        {
            get { return mLogin;  }
            set { mLogin = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        public OnSignInEventArgs(string login, string password) : base()
        {
            Login = login;
            Password = password;
        }
    }
    class dialog_sign_in : DialogFragment
    {
        private EditText mTxtLogin;
        private EditText mTxtPassword;
        private Button mBtnSignIn;

        public event EventHandler<OnSignInEventArgs> mOnSignInComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_in, container, false);

            mTxtLogin = view.FindViewById<EditText>(Resource.Id.txtLogin);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnSignIn = view.FindViewById<Button>(Resource.Id.btnDialogSignIn);

            mBtnSignIn.Click += MBtnSignIn_Click;

            return view;
        }

        private void MBtnSignIn_Click(object sender, EventArgs e)
        {
            mOnSignInComplete.Invoke(this, new OnSignInEventArgs(mTxtLogin.Text, mTxtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}