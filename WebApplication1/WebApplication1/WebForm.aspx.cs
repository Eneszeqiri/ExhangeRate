using Microsoft.Xml.XQuery;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
              
        protected void Show_Click(object sender, EventArgs e)
        {
            if(IsDate(StartDate.Text) && IsDate(EndDate.Text))
            {
                nbrmService.KursSoapClient client = new nbrmService.KursSoapClient();
                //var response gets the xml string
                var response = client.GetExchangeRate(StartDate.Text, EndDate.Text);

                //opening a xml document to read the response
                XmlDocument xm = new XmlDocument();
                xm.LoadXml(response);
                var xmlNodes = xm.SelectNodes("//KursZbir");

                for (var i = 0; i < xmlNodes.Count; i++)
                {
                    var node = xmlNodes[i];
                    var states = new State();

                    //getting the exact values from the xml string
                    states.Valuta = node["Valuta"].InnerText;
                    states.Oznaka = node["Oznaka"].InnerText;
                    states.Nomin = node["Nomin"].InnerText;
                    states.Sreden = node["Sreden"].InnerText;
                    states.DrzavaAng = node["DrzavaAng"].InnerText;

                    //Creating new table row dynamically
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();
                    cell1.Text = states.DrzavaAng;
                    cell2.Text = states.Valuta;
                    cell3.Text = states.Oznaka;
                    cell4.Text = states.Nomin;
                    cell5.Text = states.Sreden;
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    myTable.Rows.Add(row);
                    //Label1.Text += states.Oznaka + " " + states.DrzavaAng + " " + states.Sreden + " --------------------- ";
                }
            }
            else
            {
                Label1.Text = "Date is Invalid";
            }
        }

        public static bool IsDate(string tempDate)
        {
            DateTime fromDateValue;
            var formats = new[] { "dd.MM.yyyy" };
            if (DateTime.TryParseExact(tempDate, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}