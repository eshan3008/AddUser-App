using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.ObjectModel;

namespace AddUser
{
    [Activity(Label = "AddUser", MainLauncher = true, Icon = "@drawable/AddUSerIcon",
               Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class MainActivity : Activity
    {

        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        UserAdapter mAdapter;
        public ObservableCollection<String> itemList;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            itemList = new ObservableCollection<String>();

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            mAdapter = new UserAdapter(itemList);
            mRecyclerView.SetAdapter(mAdapter);


            Button addUserBtn = FindViewById<Button>(Resource.Id.addUserButton);
            addUserBtn.Click += delegate
            {
                var intent = new Intent(this, typeof(AddUserActivity));
                StartActivityForResult(intent, 0);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && data != null)
            {
                if (itemList == null)
                {
                    itemList = new ObservableCollection<string>();
                }
                itemList.Add(data.Extras.GetString("selectedItemId"));
                RefreshTheList();
            }
        }

        private void RefreshTheList()
        {
            mAdapter.NotifyItemChanged(0);
        }
    }
}

