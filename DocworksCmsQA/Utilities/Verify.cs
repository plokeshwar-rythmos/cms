using AventStack.ExtentReports;
using DocworksCmsQA.CustomException;
using System;

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
                Pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));
            }

            return false;

        }

        public Boolean VerifyEquals(ExtentTest test, Object expected, Object actual, String successMessage, String errorMessage)
        {

            if (expected.Equals(actual))
            {
                Pass(test, "<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(test, new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : null<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : Null,   Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : NOT NULL<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : Not Null,   Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : TRUE<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : True , Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : FALSE<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                throw new AssertException("Expected : False , Actual : " + actual + ",  ERROR : " + errorMessage);
                //fail(new Exception("Expected : False , Actual : " + actual + ",  ERROR : " + errorMessage));
            }


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
                Pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));

            }
            return false;
        }

        public Boolean VerifyText(ExtentTest test, String expected, String actual, String successMessage, String errorMessage)
        {

            if (expected.Equals(actual))
            {
                Pass(test, "<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(test, new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));

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
                Pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "");
                return true;

            }
            else
            {
                Fail(new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "");
                return true;

            }
            else
            {
                Fail(new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "<br> SUCCESS :" + successMessage);
                return true;
            }
            else
            {
                
                Fail(new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));

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
                Pass("<b>Expected</b> : " + expected + "<br> <b>Actual</b> : " + actual + "");
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : " + expected + "   Actual : " + actual + ",  ERROR : " + errorMessage));
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
                Pass("<b>Expected</b> : [" + expected + "] is available in <b>Actual</b> : [" + actual + "]<br> SUCCESS : "
                        + successMessage);
                return true;
            }
            else
            {
                Fail(new AssertException("Expected : " + expected + " is not available in  Actual : " + actual + ",  ERROR : " + errorMessage));
              

            }
            return false;
        }

        


    

}
}
