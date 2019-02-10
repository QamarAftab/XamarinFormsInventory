
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Helper.CustomControls
{
    public class Frame : Xamarin.Forms.Frame
    {
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
                                                              propertyName: "TitleText",
                                                              returnType: typeof(string),
                                                              declaringType: typeof(Frame),
                                                              defaultValue: "",
                                                              defaultBindingMode: BindingMode.TwoWay);

        public string TitleText
        {
            get { return base.GetValue(TitleTextProperty).ToString(); }
            set { base.SetValue(TitleTextProperty, value); }
        }



        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }

        public Frame()
        {
            var data = TitleText;
        }
    }
}
