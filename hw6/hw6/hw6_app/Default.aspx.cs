﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw6_app
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            string inputData = txtInputData.Text;

            ServiceReference1.DataParserService service = new ServiceReference1.DataParserServiceClient();
            double [] numberSet = service.ParseData(inputData);
            
        }
    }
}