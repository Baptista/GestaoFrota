﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;

namespace Android_Gestao_Frotas.Adapters
{
    public class ReportsFragmentsAdapter : Android.Support.V4.App.FragmentPagerAdapter
    {

        List<V4Fragment> fragments = new List<V4Fragment>();
        List<string> fragmentTitles = new List<string>();


        public ReportsFragmentsAdapter(V4FragmentManager fragmentManager) : base(fragmentManager)
        {

        }

        public void AddFragment(V4Fragment fragment, String title)
        {
            fragments.Add(fragment);
            fragmentTitles.Add(title);
        }

        public override V4Fragment GetItem(int position)
        {
            return fragments[position];
        }

        public override int Count
        {
            get { return fragments.Count; }
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(fragmentTitles[position]);
        }

    }
}