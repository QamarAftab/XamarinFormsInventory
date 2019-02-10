using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace Helper.Helpers
{
    public static class ControlsHelper
    {
        public static System.Drawing.Color ErrorColor
        {
            get
            {
                return System.Drawing.Color.Red;
            }
        }

        public static System.Drawing.Color SuccessColor
        {
            get
            {
                return System.Drawing.Color.Green;
            }
        }


        public static void ShowLoading(bool IsShow, string message = "")
        {
            if (IsShow)
            {
                UserDialogs.Instance.ShowLoading(message);
            }
            else
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public static void Toast(string message, System.Drawing.Color _color, string actionMessage = "Ok")
        {
            ToastConfig config = new ToastConfig(message)
            {
                Message = message,
                Duration = TimeSpan.FromSeconds(10),
                Action = new ToastAction()
                {
                    Text = actionMessage
                },
            };
            config.Action = new ToastAction()
            {
                Text = "Ok",
                TextColor = System.Drawing.Color.White
            };
            config.BackgroundColor = _color;
            UserDialogs.Instance.Toast(config);
        }

        public async static void ClickAnimation(View _view)
        {
            await _view.ScaleTo(1.1, 50, Easing.SinIn);
            await _view.ScaleTo(1, 50, Easing.SinOut);
        }

     
    }
}
