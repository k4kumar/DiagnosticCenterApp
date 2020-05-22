using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectApp.DAL.Model;
using ProjectApp.DAL.Gateway;
using ProjectApp.BLL;

namespace ProjectApp.UI
{
    public partial class TypeSaveUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridview();
        }
        TypeManager anManager = new TypeManager();
        private void PopulateGridview()
        {
            List<TypeNameModel> types = anManager.GetAllTypes();
            typeGridView.DataSource = types;
            typeGridView.DataBind();
        }
      
        protected void saveButton_Click(object sender, EventArgs e)
        {
            TypeNameModel name = new TypeNameModel();
            
            name.TypeName = typeNameTextBox.Text;


            messagelabel.Text= anManager.Save(name);
            typeNameTextBox.Text = string.Empty;
            PopulateGridview();
        }
    }
}