using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace ZumeForms.Word.UserControls {

    public partial class ucUserForm2 : UserControl {
        public static string AcceccToken { get; set; }
        public static string BaseUrl { get; set; }

        public event EventHandler FormSelected;

        public ucUserForm2() {
            InitializeComponent();
        }

        public void LoadUsers_Old(string domain, string user, string pass) {




            user = HttpUtility.UrlEncode(user);
            pass = HttpUtility.UrlEncode(pass);

            string url = "https://" + domain + "/User/UserFormsJson?username=" + user + "&userpass=" + pass;
            this.Cursor = Cursors.WaitCursor;

            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream(), true);
                string json = sr.ReadToEnd();

                List<UserForm> userforms = JsonConvert.DeserializeObject<List<UserForm>>(json);

                if(userforms == null) {
                    MessageBox.Show("UserName / Password incorrect or this user has no forms.", "Error", MessageBoxButtons.OK);
                }
                else {

                    cboForms.Items.Clear();

                    foreach (UserForm form in userforms) {
                        //string[] row = { form.FormName};
                        //var listViewItem = new ListViewItem(row);
                        //listViewItem.Tag = form.URL;
                        //listViewItem.ImageKey = "Form";
                        //lstViewMain.Items.Add(listViewItem);

                        ComboboxItem item = new ComboboxItem();
                        item.Value = form.URL;
                        item.ico = "Form";
                        item.Text = form.FormName;
                        cboForms.Items.Add(item);

                    }
                }

                string urlmergetext = "http://" + domain + "/Users/" + user + "/MergeText.xml";
                request = (HttpWebRequest)WebRequest.Create(urlmergetext);
                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream(), true);
                string xml = sr.ReadToEnd();

                //todo check url first
                if (string.IsNullOrEmpty(xml)) {
                    urlmergetext = "http://" + domain + "/Users/MergeText.xml";
                    request = (HttpWebRequest)WebRequest.Create(urlmergetext);
                    response = (HttpWebResponse)request.GetResponse();

                    sr = new StreamReader(response.GetResponseStream(), true);
                    xml = sr.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(xml)) {
                    XElement xmtext = XElement.Parse(xml);
                    Classes.Application.MergeTextLists.Clear();

                    var queryResult = from c in xmtext.Descendants() select c.Name;
                    foreach (var item in queryResult.Distinct()) {
                        Classes.Application.MergeTextLists.Add(item.ToString());
                    }
                }


            }
            catch (WebException ex) {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream(), true);
                string str = sr.ReadToEnd();
            }
            finally {
                this.Cursor = Cursors.Default;
            }

        }

        public void LoadUsers(string domain, string user, string pass)
        {

            user = HttpUtility.UrlEncode(user);
            pass = HttpUtility.UrlEncode(pass);

            string baseUrl = $"https://{domain}";
            BaseUrl = baseUrl;
            string authUrl = $"{baseUrl}/api/TokenAuth/Authenticate";
            string formsUrl = $"{baseUrl}/api/services/app/Forms/GetAll";
            string tanencyName = domain.Split('.')[0];
            string authModel = $"{{ \"UserNameOrEmailAddress\": \"{Uri.EscapeDataString(user)}\", \"Password\": \"{Uri.EscapeDataString(pass)}\", \"TanencyName\": \"{Uri.EscapeDataString(tanencyName)}\" }}";
            this.Cursor = Cursors.WaitCursor;

            // Create the HttpWebRequest for Authentication
            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(authUrl);
            authRequest.Method = "POST";
            authRequest.ContentType = "application/json";

            using (StreamWriter writer = new StreamWriter(authRequest.GetRequestStream()))
            {
                writer.Write(authModel);
            }

            try
            {
                // Authenticate the user
                using (HttpWebResponse authResponse = (HttpWebResponse)authRequest.GetResponse())
                using (Stream authStream = authResponse.GetResponseStream())
                using (StreamReader authReader = new StreamReader(authStream))
                {
                    string content = authReader.ReadToEnd();
                    JObject json = JObject.Parse(content);

                    bool success = (bool)json["success"];
                    string accessToken = (string)json["result"]["accessToken"];
                    AcceccToken = accessToken;
                    if (success)
                    {
                        // Create the HttpWebRequest for Forms API
                        HttpWebRequest formsRequest = (HttpWebRequest)WebRequest.Create(formsUrl);
                        formsRequest.Method = "GET";
                        formsRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                        using (HttpWebResponse formsResponse = (HttpWebResponse)formsRequest.GetResponse())
                        using (Stream formsStream = formsResponse.GetResponseStream())
                        using (StreamReader formsReader = new StreamReader(formsStream))
                        {
                            // Read and print the Forms API response content
                            string formContent = formsReader.ReadToEnd();
                            JObject formjson = JsonConvert.DeserializeObject<JObject>(formContent);
                            JArray itemsArray = formjson["result"]["items"] as JArray;
                            List<UserForm> userForms = new List<UserForm>();
                            foreach (JToken item in itemsArray)
                            {
                                string formName = item["name"]?.ToString();
                                string formId = item["id"]?.ToString();
                                string originalId = item["originalId"]?.ToString();

                                UserForm userForm = new UserForm
                                {
                                    FormName = formName,
                                    URL = $"{baseUrl}/Falcon/forms/load?OriginalId={originalId}&version=live"
                                };

                                userForms.Add(userForm);
                            }

                            if (userForms.Count > 0)
                            {
                                cboForms.Items.Clear();

                                foreach (UserForm form in userForms)
                                {
                                    ComboboxItem item = new ComboboxItem();
                                    item.Value = form.URL;
                                    item.ico = "Form";
                                    item.Text = form.FormName;
                                    cboForms.Items.Add(item);
                                }
                            }
                            else
                            {
                                MessageBox.Show("UserName / Password incorrect or this user has no forms.", "Error", MessageBoxButtons.OK);
                            }


                            // Explain 

                            string urlmergetext = "http://" + domain + "/Users/" + user + "/MergeText.xml";
                            formsRequest = (HttpWebRequest)WebRequest.Create(urlmergetext);
                            using (HttpWebResponse formsResponseNew = (HttpWebResponse)formsRequest.GetResponse())
                            using (Stream formsStreamNew = formsResponseNew.GetResponseStream())
                            using (StreamReader formsReaderNew = new StreamReader(formsStreamNew))
                            {
                                // Read and print the Forms API response content
                                string formContentNew = formsReaderNew.ReadToEnd();

                                //todo check url first
                                if (string.IsNullOrEmpty(formContentNew))
                                {
                                    urlmergetext = "http://" + domain + "/Users/MergeText.xml";
                                    formsRequest = (HttpWebRequest)WebRequest.Create(urlmergetext);
                                    var response = (HttpWebResponse)formsRequest.GetResponse();

                                    var formsReaderNewNew = new StreamReader(response.GetResponseStream(), true);
                                    formContentNew = formsReaderNewNew.ReadToEnd();
                                }

                                if (!string.IsNullOrEmpty(formContentNew))
                                {
                                    //XElement xmtext = XElement.Parse(formContentNew);
                                    //Classes.Application.MergeTextLists.Clear();

                                    //var queryResult = from c in xmtext.Descendants() select c.Name;
                                    //foreach (var item in queryResult.Distinct())
                                    //{
                                    //    Classes.Application.MergeTextLists.Add(item.ToString());
                                    //}
                                }
                            }
                        }
                    }
                    else
                    {
                        // Handle the error for login response
                        Console.WriteLine($"Login Error: {authResponse.StatusCode} - {authResponse.StatusDescription}");
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle any web exceptions
                if (ex.Response is HttpWebResponse errorResponse)
                {
                    Console.WriteLine($"Error: {errorResponse.StatusCode} - {errorResponse.StatusDescription}");
                    using (Stream errorStream = errorResponse.GetResponseStream())
                    using (StreamReader errorReader = new StreamReader(errorStream))
                    {
                        string errorContent = errorReader.ReadToEnd();
                        Console.WriteLine(errorContent);
                    }
                }
                else
                {
                    Console.WriteLine($"WebException: {ex.Message}");
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void txtFind_KeyPress(object sender, KeyPressEventArgs e) {
 
        }

        private void cboForms_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.FormSelected != null)
                this.FormSelected(cboForms.SelectedItem, new EventArgs());
        }
    }

    public class UserForm {
        public string URL = string.Empty;
        public string FormName;
    }


    public class ComboboxItem {
        public string Text { get; set; }
        public object Value { get; set; }
        public object ico { get; set; }
        public override string ToString() {
            return Text;
        }
    }
}
