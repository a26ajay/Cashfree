using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.SessionState;


namespace WebApplication3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SendAnSMSMessage("message");
        }
        public static bool SendAnSMSMessage(string message)
        {
            string Reg_No = "";
            string DOB = "";
            string PHnumber = "";
            string Name = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.koreroplatforms.com/v1/sms/send");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.MediaType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("apikey", ".=.-----==");
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = ("{\n  \"sender_id\": \"SDEIRC\",\n  \"type\": \"text\",\n  \"message\": \"Dear Candidate, Your form has been registered with us with Registration No: " + Reg_No + " and Password is your DOB " + DOB + " --REDCROSSHARYANA\",\n  \"recipient\": [\n    {\n      \"to\": [\n        \"" + PHnumber + "\"\n      ],\n      \"variables\": {\n        \"NAME\": \"" + Name + "\"\n      }\n    }\n  ],\n  \"country_specific\": [\n    {\n      \"country\": \"91\",\n      \"entity_id\": \"\",\n      \"template_id\": \"\"\n    }\n  ]\n}");
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                return true;
            }
        }
    }
}
