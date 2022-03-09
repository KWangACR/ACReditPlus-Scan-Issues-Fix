using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ACReditPlus_Scan_Issues_Fix.Helpers
{
    public class SecureTokenHelper
    {

        //private readonly static string keyPayFlowSectionName = "externalFlow/payflowSettings";
        private readonly static string keyHostAddress = "HostAddress";
        private readonly static string keyPartner = "PARTNER";
        private readonly static string keyVendor = "VENDOR";
        private readonly static string keyUser = "USER";
        private readonly static string keyPsd = "PWD";
        private readonly static string keyTrxType = "TrxType";
        private readonly static string keyCheckoutPage = "CheckoutUrl";
        private readonly static string keyMode = "Mode";

        public SecureTokenRequestInfo SetSecurityToken(PayPalCheckout payPalCheckout)
        {

            SecureTokenRequestInfo requestData = new SecureTokenRequestInfo();

            try
            {
                requestData = GetSecureTokenRequestByExistedData(Guid.NewGuid().ToString(), payPalCheckout);
                string postUrl = requestData.RequestUrl;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"https://" + postUrl);

                //Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                string secureTokenRequestContent = ParserRequestContent(requestData);
                string strRequest = secureTokenRequestContent;
                req.ContentLength = strRequest.Length;

                //for proxy
                //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
                //req.Proxy = proxy;
                //Send the request to PayPal and get the response

                StreamWriter streamOut = null;
                try
				{
                    streamOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
                    streamOut.Write(strRequest);
                }
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
                    streamOut.Close();
                }

                
                


                StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                string strResponse = streamIn.ReadToEnd();
                streamIn.Close();
            }
            catch (Exception exc)
            {
                //add exception handle
                requestData.RequestException = exc;
            }

            return requestData;
        }
    }
}
