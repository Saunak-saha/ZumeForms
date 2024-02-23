using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

using System.Xml;
using System.Xml.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace ZumeForms.Word.UserControls {
    public partial class FormFields : UserControl {

        public FormFields() {
            InitializeComponent();
        }

        private void btnLoadForm_Click(object sender, EventArgs e) {
            Forms.UserForms frm = new Forms.UserForms();
            frm.ShowDialog();
        }

        public XElement xComponentTreeData = new XElement("HTMLSummary");
        public String FormID {
            get;
            set;
        }

        public void LoadForm() {

        }

        public HtmlAgilityPack.HtmlDocument HTMLDocument = new HtmlAgilityPack.HtmlDocument();
        public void LoadForm(String formurl){

            try {

                xSummaryData = new XElement("Form", new XAttribute("ico", "Form"), new XAttribute("Name", "Form"));
                // Create web client simulating IE6.
                using (System.Net.WebClient client = new System.Net.WebClient()) {
                    
                    // Download data.
                    string html = client.DownloadString(formurl);
                    HTMLDocument.LoadHtml(html);

                    LoadFormStructure();
                    //InitHTMLForm(HTMLDocument);

                }
            }
            catch {
                HTMLDocument.LoadHtml("<div id='main' class='col-md-12 col-lg-12'><h3>Form not found or not published</h3></div>");
            }

            DataSet ds = new DataSet();
            ds.ReadXml(new System.IO.StringReader(xSummaryData.ToString()));
            grdFields.DataMember = "Form";
            grdFields.DataSource = ds;
            grdFields.RetrieveStructure(true);
            
            foreach (Janus.Windows.GridEX.GridEXTable tbl in grdFields.Tables) {

                foreach (Janus.Windows.GridEX.GridEXColumn col in tbl.Columns) {
                    if (col.DataTypeCode == TypeCode.Int32) col.Visible = false;
                    if (col.Key == "ico") {
                        col.ColumnType = Janus.Windows.GridEX.ColumnType.Image;
                        col.Width = 20;
                    }
                    else {
                        col.Width = 200;
                    }
                }

            }

            grdFields.ExpandRecords();

            this.Visible = true;
        }


        public void LoadFormFieldsFromFormScheme(String formurl)
        {
            try
            {
                if (!string.IsNullOrEmpty(formurl))
                {
                    // Parse the query string parameters
                    var queryParameters = HttpUtility.ParseQueryString(new Uri(formurl).Query);

                    string originalId = queryParameters["OriginalId"];
                    string version = queryParameters["version"];
                    string apiUrl = $"api/services/app/Forms/GetFormForView?Id={originalId}&OriginalId={originalId}&Version={version}";
                    string formsUrl = $"{ucUserForm2.BaseUrl}/{apiUrl}";

                    // Create the HttpWebRequest for Forms API
                    HttpWebRequest formRequest = (HttpWebRequest)WebRequest.Create(formsUrl);
                    formRequest.Method = "GET";
                    formRequest.Headers.Add("Authorization", "Bearer " + ucUserForm2.AcceccToken);
                    using (HttpWebResponse formsResponse = (HttpWebResponse)formRequest.GetResponse())
                    using (Stream formsStream = formsResponse.GetResponseStream())
                    using (StreamReader formsReader = new StreamReader(formsStream))
                    {
                        // Read and print the Forms API response content
                        string formContent = formsReader.ReadToEnd();
                        // Deserialize the JSON response into a JObject
                        JObject formJson = JsonConvert.DeserializeObject<JObject>(formContent);

                        // Access the "result" property, then the "form" property, and finally the "schema" property
                        JToken formSchemaToken = formJson["result"]?["form"]?["schema"];

                        // Check if the "schema" property exists before parsing it
                        if (formSchemaToken != null)
                        {
                            JObject jsonSchema = JObject.Parse(formSchemaToken.ToString());
                            XElement componentTrees = ExtractComponentsAsXml(jsonSchema);
                            xComponentTreeData = componentTrees;
                        }
                    }
                }
            }
            catch (Exception)
            {
                HTMLDocument.LoadHtml("<div id='main' class='col-md-12 col-lg-12'><h3>Form not found or not published</h3></div>");
            }
        }


        static XElement ExtractComponentsAsXml(JObject json)
        {
            XElement root = new XElement("Components");

            if (json["components"] != null)
            {
                foreach (var component in json["components"])
                {
                    root.Add(CreateXElementFromComponent((JObject)component));
                }
            }

            return root;
        }

        static XElement CreateXElementFromComponent(JObject component)
        {
            string key = (string)component["key"];

            XElement element = new XElement(key);

            if (component["components"] != null)
            {
                foreach (var childComponent in component["components"])
                {
                    element.Add(CreateXElementFromComponent((JObject)childComponent));
                }
            }

            return element;
        }

        public System.Xml.Linq.XDocument xProject = new System.Xml.Linq.XDocument();
        public XElement xSummaryData = new XElement("HTMLSummary");
        public void LoadFormStructure() {

            IEnumerable<HtmlAgilityPack.HtmlNode> ndgroups = HTMLDocument.DocumentNode.FirstChild.SelectNodes("./div[contains(@class, 'Group')]");

            Classes.FormFields.Fields.Clear();

            // Add The Page/section name
            foreach (HtmlAgilityPack.HtmlNode ndgroup in ndgroups) {

                HtmlAgilityPack.HtmlNode ndrepeat = ndgroup.SelectSingleNode("./div[contains(@class, 'repeat')]");

                // If the dropped groups controls are visible then it is a repeat. <div id="Section2_controls" class="col-md-12 col-lg-12 _controls highlight" style="display: block
                bool isrepeat = ndgroup.SelectSingleNode("./div[contains(@class, '_controls') and contains(@style, 'block')]") != null ? true : false;

                XElement xgroup = new XElement(System.Xml.XmlConvert.EncodeLocalName(ndrepeat.Attributes["data-repeat"].Value ) );
                if (isrepeat) {
                    xgroup.Add(new XAttribute("ico", "Repeat"));                    
                    xgroup.Add(new XAttribute("SectionName", ndrepeat.Attributes["data-repeat"].Value));                    
                    xSummaryData.Add(xgroup);
                    LoadFormStructureRecursive(ndrepeat, xgroup, isrepeat);
                    xgroup = new XElement(System.Xml.XmlConvert.EncodeLocalName(ndrepeat.Attributes["data-repeat"].Value),new XAttribute("ico", "Repeat"), new XAttribute("SectionName", ndrepeat.Attributes["data-repeat"].Value));

                }
                else {
                    xgroup.Add(new XAttribute("ico", "Section"));
                    xgroup.Add(new XAttribute("SectionName", ndrepeat.Attributes["data-repeat"].Value));                    
                    xSummaryData.Add(xgroup);
                    LoadFormStructureRecursive(ndrepeat, xgroup, isrepeat);
                }
 
            }

        }

        private void LoadFormStructureRecursive(HtmlAgilityPack.HtmlNode ndparent, XElement xgroupparent, bool isrepeat) {

            if (ndparent.SelectNodes("./div[contains(@class, 'droppedField') or contains(@class, 'droppedGroup')]") != null) {

                foreach (HtmlAgilityPack.HtmlNode nddroppedfld in ndparent.SelectNodes("./div[contains(@class, 'droppedField') or contains(@class, 'droppedGroup')]")) {

                    if (nddroppedfld.Attributes["class"].Value.Contains("droppedGroup")) {
                        // This is agroup process levels 
                        HtmlAgilityPack.HtmlNode ndrepeat = nddroppedfld.SelectSingleNode("./div[contains(@class, 'repeat')]");

                        // If the dropped groups controls are visible the it is a repeat. <div id="Section2_controls" class="col-md-12 col-lg-12 _controls highlight" style="display: block
                        isrepeat = nddroppedfld.SelectSingleNode("./div[contains(@class, '_controls') and contains(@style, 'block')]") != null ? true : false;
                        XElement xgroup = new XElement(System.Xml.XmlConvert.EncodeLocalName(ndrepeat.Attributes["data-repeat"].Value));

                        if (isrepeat) {
                            xgroup.Add( new XAttribute("ico", "Repeat"));
                            xgroup.Add(new XAttribute("SectionName", ndrepeat.Attributes["data-repeat"].Value));                           
                            xgroupparent.Add(xgroup);
                            LoadFormStructureRecursive(ndrepeat, xgroup, isrepeat);

                            //xgroup = new XElement(System.Xml.XmlConvert.EncodeLocalName(ndrepeat.Attributes["data-repeat"].Value), new XAttribute("ico", "Repeat"), new XAttribute("SectionName", ndrepeat.Attributes["data-repeat"].Value));

                        }
                        else {
                            xgroup.Add(new XAttribute("ico", "Section"));
                            xgroup.Add(new XAttribute("SectionName", ndrepeat.Attributes["data-repeat"].Value));
                            xgroupparent.Add(xgroup);
                            LoadFormStructureRecursive(ndrepeat, xgroup, isrepeat);
                        }
 
                    }
                    else {

                        HtmlAgilityPack.HtmlNode nddroppedfldctrl = nddroppedfld.SelectSingleNode(".//input[contains(@class, 'ctrl')]");

                        if (nddroppedfldctrl == null) nddroppedfldctrl = nddroppedfld.SelectSingleNode(".//input[@type='checkbox' or @type='radio']");
                        if (nddroppedfldctrl == null) nddroppedfldctrl = nddroppedfld.SelectSingleNode(".//select[contains(@class, 'ctrl')]");
                        if (nddroppedfldctrl == null) nddroppedfldctrl = nddroppedfld.SelectSingleNode(".//textarea[contains(@class, 'ctrl')]");

                        HtmlAgilityPack.HtmlNode nddroppedfldlabel = nddroppedfld.SelectSingleNode(".//label[contains(@class, 'control-label')]");

                        if (nddroppedfldctrl != null) {

                            string type = "Textbox";
                            if (nddroppedfldctrl.Attributes["type"] != null) {
                                type = nddroppedfldctrl.Attributes["type"].Value ;

                                switch (type.ToLower()) {
                                    case "text":
                                        type = "TextBox";
                                        break;
                                    case "number":
                                        type = "Numeric";
                                        break;
                                    case "radio":
                                        type = "YesNo";
                                        break;
                                    case "checkbox":
                                        type = "CheckBox";
                                        break;
                                }
                            }

                            if (nddroppedfldctrl.Name.ToLower() == "select") {
                                if (nddroppedfldctrl.Attributes["size"] == null) {
                                    type = "Combobox";
                                }
                                else {
                                    type = "Choices";
                                }
                                
                            }
                            if (nddroppedfldctrl.Name.ToLower() == "textarea") type = "MultiLineText";

                            // This is the name of the field
                            string fldname = nddroppedfldctrl.Attributes["name"].Value.Split(']').Last();
                            string fldlabel = nddroppedfldlabel == null ? fldname : HttpUtility.HtmlDecode(nddroppedfldlabel.InnerText).Trim();
                            XElement xfield = new XElement(System.Xml.XmlConvert.EncodeLocalName(fldname), new XAttribute("ico", type), new XAttribute("FieldName", fldname));
                            xgroupparent.Add(xfield);

                            Classes.FormFields.addField(fldname);

                        }
                    }
                }
            }
        }

        DataSet DSForms = new DataSet();  
        private void grdFields_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e) {

            try {
                if (this.imgList.Images[e.Row.Cells["ico"].Value.ToString()] != null) {
                    String Type = e.Row.Cells["ico"].Value.ToString();
                    e.Row.Cells["ico"].Image = this.imgList.Images[Type];
                }
            }
            catch {
            }

        }
        
        object missing = System.Type.Missing;
        private Rectangle dragBoxFromMouseDown;

        private void lstItems_MouseDown(object sender, MouseEventArgs e) {
            // Remember the point where the mouse down occurred. The DragSize indicates
            // the size that the mouse can move before a drag event should be started.                
            Size dragSize = SystemInformation.DragSize;

            
            // Create a rectangle using the DragSize, with the mouse position being
            // at the center of the rectangle.
            dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                           e.Y - (dragSize.Height / 2)), dragSize);

        }

        private void lstItems_MouseMove(object sender, MouseEventArgs e) {

            try {

                String fldtype = Convert.ToString(grdFields.GetValue("ico"));
                if (fldtype == "Form" ) return;
                if (fldtype == "Section") return;

                //To check if the Mouse left button is clicked
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                    Object cur = Cursor.Current;
                       // If the mouse moves outside the rectangle, start the drag.
                    if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y)) {
                        //Start Drag Drop
                        DoDragDrop("", DragDropEffects.Copy);

                       if (fldtype == "Repeat") {
                           String fldname = grdFields.GetValue("SectionName").ToString();
                           Classes.MailMerge.TableRegionNew(fldname);                   }
                       else {
                           String fldname = grdFields.GetValue("FieldName").ToString();
                           Microsoft.Office.Interop.Word.Field fld = Classes.MailMerge.FieldNew(fldname);
                           Classes.MailMerge.FieldEdit("MailMerge", fld);                       
                       }
                    }
                }
            }
            catch {

            }

        }

        private void lstItems_MouseUp(object sender, MouseEventArgs e) {

            // Reset the drag rectangle when the mouse button is raised.
            dragBoxFromMouseDown = Rectangle.Empty;

        }


        private void grdFields_DragDrop(object sender, DragEventArgs e) {

        }

        private void grdFields_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e) {

            try {

                String fldtype = grdFields.GetValue("ico").ToString();
                if (fldtype == "Form") return;
                if (fldtype == "Section") return;

                if (fldtype == "Repeat") {
                    String fldname = grdFields.GetValue("SectionName").ToString();
                    Classes.MailMerge.TableRegionNew(fldname);
                }
                else {
                    String fldname = grdFields.GetValue("FieldName").ToString();
                    Microsoft.Office.Interop.Word.Field fld = Classes.MailMerge.FieldNew(fldname);
                    Classes.MailMerge.FieldEdit("MailMerge", fld);
                }
             
                
            }
            catch {

            }
        }
    }
}
