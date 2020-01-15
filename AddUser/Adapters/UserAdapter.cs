using System;
using System.Collections.ObjectModel;
using Android.Support.V7.Widget;
using Android.Views;

namespace AddUser
{

    public class UserAdapter : RecyclerView.Adapter
    {

        private event EventHandler<int> ItemClick;
        private ObservableCollection<String> mUserList;

        public UserAdapter(ObservableCollection<string> userName) => mUserList = userName;


        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.UserList, parent, false);
            UserViewHolder vh = new UserViewHolder(itemView, OnClick);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            UserViewHolder vh = holder as UserViewHolder;

            vh.Caption.Text = mUserList[position];
        }

        public override int ItemCount => mUserList.Count;

        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }

    }
}
