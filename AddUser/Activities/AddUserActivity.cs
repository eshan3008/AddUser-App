using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace AddUser
{
    [Activity(Label = "AddUserActivity")]
    public class AddUserActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addNewUser);
            EditText userDetails = FindViewById<EditText>(Resource.Id.userName);
            Button addUserBtn = FindViewById<Button>(Resource.Id.submitBtn);

            // Handler for the Random Pick Button:
            addUserBtn.Click += delegate
            {
                if (PasswordValidator.validate(userDetails.Text) != null)
                {
                    Toast.MakeText(this, "Validation Error: " + PasswordValidator.validate(userDetails.Text), ToastLength.Long).Show();
                }
                else
                {
                    var intent = new Intent();
                    intent.PutExtra("selectedItemId", userDetails.Text);
                    SetResult(Result.Ok, intent);
                    Toast.MakeText(this, "User Added successfully", ToastLength.Short).Show();
                    Finish();
                }
            };

        }
    }
}
