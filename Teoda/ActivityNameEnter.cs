using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Teoda
{
    [Activity(Label = "ActivityNameEnter")]
    public class ActivityNameEnter : Activity
    {
        private const string LettersForButtons = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";
        private LinearLayout llLetterPlaceholders;
        private LinearLayout llButtons;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NameEnter);

            llLetterPlaceholders= FindViewById<LinearLayout>(Resource.Id.llLetterPlaceholders);
            llButtons = FindViewById<LinearLayout>(Resource.Id.llButtons);

            PopulateLetters();
        }

        private void PopulateLetters()
        {
            llButtons.RemoveAllViews();

            var chars = LettersForButtons.ToCharArray();

            var buttonLayoutParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MatchParent);
            buttonLayoutParams.Weight = 1;

            int rows = 3;
            int cols = 8;
            int r = 1;
            int c = 1;

            var row = new LinearLayout(this);
            var rowLayoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 0);
            rowLayoutParams.Weight = 1;
            row.Orientation = Orientation.Horizontal;
            row.LayoutParameters = rowLayoutParams;

            llButtons.AddView(row);

            for (var l = 0; l < chars.Length; l++)
            {
                if (c > cols)
                {
                    c = 1;
                    r++;
                    row = new LinearLayout(this);
                    rowLayoutParams.Weight = 1;
                    row.Orientation = Orientation.Horizontal;
                    row.LayoutParameters = rowLayoutParams;
                    llButtons.AddView(row);
                }
                var letter = chars[l];
                var button = new Button(this);
                button.Text = letter.ToString();
                button.Tag = letter;
                button.LayoutParameters = buttonLayoutParams;
                button.Click += LetterButton_Click;
                row.AddView(button);
                c++;
            }
            for (int e = c - 1; e < cols; e++)
            {
                var space = new Space(this);
                space.LayoutParameters = buttonLayoutParams;
                row.AddView(space);
            }
        }

        private void LetterButton_Click(object sender, EventArgs e)
        {
            var textViewLetter = new TextView(this);
            textViewLetter.Text = (string)((Button)sender).Tag;
            llLetterPlaceholders.AddView(textViewLetter);
        }
    }
}