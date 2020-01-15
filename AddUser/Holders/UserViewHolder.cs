using System;

using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace AddUser
{

    public class UserViewHolder : RecyclerView.ViewHolder
    {
        public TextView Caption { get; private set; }
        public UserViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}
