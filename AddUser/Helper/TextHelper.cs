using System;
using Android.Text;
using Android.Widget;
using Java.Lang;

namespace AddUser
{

    public class TextHelper : Java.Lang.Object, ITextWatcher
    {
        private EditText _editText;

        public TextHelper()
        {
        }

        public TextHelper(EditText editText)
        {
            _editText = editText;
        }

        public void AfterTextChanged(IEditable s)
        {

        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
        }
    }
}
