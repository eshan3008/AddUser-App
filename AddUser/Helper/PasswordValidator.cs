using System;
using System.Collections.Generic;
using Java.Util.Regex;

namespace AddUser
{
    public class PasswordValidator
    {


        public static String ERROR_PASSWORD_LENGTH = "Password must be 8 to 12 characters long.";
        public static String ERROR_PASSWORD_CASE = "Password must only contain lowercase letters.";
        public static String ERROR_LETTER_AND_DIGIT = "Password must contain both a letter and a digit.";
        public static String ERROR_PASSWORD_SEQUENCE_REPEATED = "Password must not contain any sequence of characters immediately followed by the same sequence.";

        private static Pattern checkCasePattern = Pattern.Compile("[A-Z]");
        private static Pattern checkLetterAndDigit = Pattern.Compile("[a-z]+\\d+|\\d+[a-z]+");
        private static Pattern checkSequenceRepetition = Pattern.Compile("(\\w{2,})\\1");

        internal static String validate(String password)
        {
            List<String> failures = new List<string>();
            checkLength(password, failures);
            checkCase(password, failures);
            CheckLetterAndDigit(password, failures);
            CheckSequenceRepetition(password, failures);
            return errorDetails(failures);

        }
        public static String errorDetails(List<string> failures)

        {
            string error = null;
            if (failures != null)
            {
                for (int i = 0; i < failures.Count; i++)
                {
                    error += failures[i];
                }
            }
            return error;
        }

        private static void CheckSequenceRepetition(String password, List<String> failures)
        {
            Matcher matcher = checkSequenceRepetition.Matcher(password);
            if (matcher.Find())
            {
                failures.Add(ERROR_PASSWORD_SEQUENCE_REPEATED);
            }
        }

        private static void CheckLetterAndDigit(String password, List<String> failures)
        {
            Matcher matcher = checkLetterAndDigit.Matcher(password);
            if (!matcher.Find())
            {
                failures.Add(ERROR_LETTER_AND_DIGIT);
            }

        }

        private static void checkCase(String password, List<String> failures)
        {
            Matcher matcher = checkCasePattern.Matcher(password);
            if (matcher.Find())
            {
                failures.Add(ERROR_PASSWORD_CASE);
            }

        }

        private static void checkLength(String value, List<String> failures)
        {
            if (value.Length < 8 || value.Length > 12)
            {
                failures.Add(ERROR_PASSWORD_LENGTH);
            }
        }

    }
}
