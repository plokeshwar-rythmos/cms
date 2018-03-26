using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocWorksQA.Utilities
{
    public class Verify : ExtentReporter
    {
        /**
	 * @author Pravin Lokeshwar
	 * 
	 */


        /**
         * This method verifies two objects and returns true if equal and reports message.
         * 
         * @param expected
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if objects equal
         */

        public Boolean VerifyEquals(Object expected, Object actual, String successMessage, String errorMessage)
        {

            if (expected.Equals(actual))
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }

        /**
         * This method verifies two objects and returns true if not equal and reports message.
         * 
         * @param expected
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if objects not equal
         */

        public Boolean VerifyNotEquals(Object expected, Object actual, String successMessage, String errorMessage)
        {

            if (!expected.Equals(actual))
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }

        /**
         * This method verifies if the object is null and returns true if null and reports message.
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if object is null
         */
        public Boolean VerifyIsNull(Object actual, String successMessage, String errorMessage)
        {


            if (actual == null)
            {
                pass("<b>Expected</b> : null<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : null<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }


        /**
         * This method verifies if the object is not null and returns true if not null and reports message.
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if object is not null
         */

        public Boolean VerifyNotNull(Object actual, String successMessage, String errorMessage)
        {

            if (actual != null)
            {
                pass("<b>Expected</b> : NOT NULL<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : NOT NULL<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }

        /**
         * This method verifies if the object is true and returns true if true and reports message.
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if object is true
         */
        public Boolean VerifyTrue(Boolean actual, String successMessage, String errorMessage)
        {

            if (actual)
            {
                pass("<b>Expected</b> : TRUE<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : TRUE<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }


        /**
         * 
         * This method verifies if the object is false and returns true if false and reports message.
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if object is false
         */

        public Boolean VerifyFalse(Boolean actual, String successMessage, String errorMessage)
        {

            if (!actual)
            {
                pass("<b>Expected</b> : FALSE<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : FALSE<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }


        /**
         * This method verifies object against object and returns true if equal and reports messages.
         * 
         * @param expected
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if both objects are equal.
         */

        public Boolean verify(Object expected, Object actual, String successMessage, String errorMessage)
        {

            if (expected.Equals(actual))
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }

        /**
         * This method verifies object against object and returns true if equal and reports only error messages.
         * 
         * @param expected
         * @param actual
         * @param errorMessage
         * @return True if both objects are equal.
         
         */
        public Boolean verify(Object expected, Object actual, String errorMessage)
        {

            if (expected.Equals(actual))
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "");
                return true;

            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }
            return false;
        }


        /**
         * This method verifies Text against Text and reports messages.
         * 
         * @param expected
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if both Strings are equal.
         
         */

        public Boolean VerifyText(String expected, String actual, String successMessage, String errorMessage)
        {

            if (expected.Equals(actual))
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);

            }
            return false;
        }

        /**
         * This method verifies Text against Text and reports only error messages.
         * 
         * @param expected
         * @param actual
         * @param errorMessage
         * @return True if both Strings are equal.
         */
        public Boolean VerifyText(String expected, String actual, String errorMessage)
        {

            if (expected.Equals(actual))
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "");
                return true;

            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }

        /**
         * This method verifies Text against Text ignoring case sensitivity and
         * reports messages.
         * 
         * @param expected
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if both Strings are equal.
         
         */
        public Boolean VerifyTextIgnoreCase(String expected, String actual, String successMessage, String errorMessage)
        {

            if (expected.Equals(actual, StringComparison.OrdinalIgnoreCase))
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }

        /**
         * This method verifies Text against Text ignoring case sensitivity and
         * reports error messages.
         * 
         * @param expected
         * @param actual
         * @param errorMessage
         * @return True if both Strings are equal.
         
        */
        public Boolean VerifyTextIgnoreCase(String expected, String actual, String errorMessage)
        {

            if (expected.Equals(actual, StringComparison.OrdinalIgnoreCase))
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "");
                return true;

            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }
            return false;
        }

        /**
         * This method verifies boolean against boolean and reports messages.
         * 
         * @param expected
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if both objects are equal.
         
         */
        public Boolean VerifyBoolean(Boolean expected, Boolean actual, String successMessage, String errorMessage)
        {

            if (expected == actual)
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS :" + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);

            }
            return false;

        }

        /**
         * This method verifies boolean against boolean and reports error messages.
         * 
         * @param expected
         * @param actual
         * @param errorMessage
         * @return True if both objects are equal.
         
         */
        public Boolean VerifyBoolean(Boolean expected, Boolean actual, String errorMessage)
        {

            if (expected == actual)
            {
                pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "");
                return true;
            }
            else
            {
                fail("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> ERROR : " + errorMessage);
            }

            return false;

        }

        /**
         * This method verifies if the expected text contains actual text and
         * reports messages.
         * 
         * @param expected
         * @param actual
         * @param successMessage
         * @param errorMessage
         * @return True if expected contains actual.
         
         */

        public Boolean VerifyContainsText(String expected, String actual, String successMessage, String errorMessage)
        {

            if (actual.Contains(expected))
            {
                pass("<b>Expected</b> : [" + expected + "] is available in <b>Actual</b> : [" + actual + "]<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                fail("<b>Expected</b> : [" + expected + "] is not available in <b>Actual</b> : [" + actual + "]<br> ERROR : "
                        + errorMessage);

            }
            return false;
        }

        /**
         * This method verifies if the expected text contains actual text and reports only error messages.
         * 
         * @param expected
         * @param actual
         * @param errorMessage
         * @return True if expected contains actual.
         */
        public Boolean VerifyContainsText(String expected, String actual, String errorMessage)
        {

            if (actual.Contains(expected))
            {
                pass("<b>Expected</b> : [" + expected + "] is available in <b>Actual</b> : [" + actual + "]");
                return true;
            }
            else
            {
                fail("<b>Expected</b> : [" + expected + "] is not available in <b>Actual</b> : [" + actual + "]<br> ERROR : "
                        + errorMessage);

            }
            return false;

        }



    

}
}
