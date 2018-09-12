using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Android_Gestao_Frotas.Activities.Configurations.Fragments
{

    public delegate void OnLoginAutomaticoClick();
    public delegate void OnResetApplicationClick();

    public class FragmentLocal : Android.Support.V4.App.Fragment
    {

        LinearLayout bttloginautomatico;
        LinearLayout bttbasedados;
        TextView tvLoginautomatico;
        public event OnLoginAutomaticoClick OnLoginAutomaticoClick;
        public event OnResetApplicationClick OnResetApplicationClick;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_local, container, false);
            bttloginautomatico = view.FindViewById<LinearLayout>(Resource.Id.bttloginautomatico);
            tvLoginautomatico = view.FindViewById<TextView>(Resource.Id.tvLoginautomatico);
            bttbasedados = view.FindViewById<LinearLayout>(Resource.Id.bttbasedados);

            bttloginautomatico.Click -= Bttloginautomatico_Click;
            bttloginautomatico.Click += Bttloginautomatico_Click;

            bttbasedados.Click -= Bttbasedados_Click;
            bttbasedados.Click += Bttbasedados_Click;

            return view;
        }

        private void Bttbasedados_Click(object sender, EventArgs e)
        {
            OnResetApplicationClick?.Invoke();
        }

        private void Bttloginautomatico_Click(object sender, EventArgs e)
        {
            OnLoginAutomaticoClick?.Invoke();
        }

        public void ChangeAutoLoginStatus(bool status)
        {
            string Texto = "";
            if (status == true)
            {
                Texto = "Login Automatico: ON";
                ISpannable spannable = new SpannableString(Texto);
                spannable.SetSpan(new ForegroundColorSpan(Color.Green), 17, Texto.Length, SpanTypes.ExclusiveExclusive);
                tvLoginautomatico.SetText(spannable, TextView.BufferType.Spannable);
            }
            else
            {
                Texto = "Login Automatico: OFF";
                ISpannable spannable = new SpannableString(Texto);
                spannable.SetSpan(new ForegroundColorSpan(Color.Red), 17, Texto.Length, SpanTypes.ExclusiveExclusive);
                tvLoginautomatico.SetText(spannable, TextView.BufferType.Spannable);
            }
        }

    }
}