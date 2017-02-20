using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using WebFormsMvp;
using OldBoardGamesNeedLoveToo.MVP.Presenters;

namespace OldBoardGamesNeedLoveToo.Web.Admin
{
    [PresenterBinding(typeof(AdminCategoriesPresenter))]

    public partial class ManageCategories : MvpPage<AdminCategoriesViewModel>, IAdminCategoriesView
    {
        public event EventHandler<NewCategoryEventArgs> AdminAddCategory;
        public event EventHandler<CategoryEventArgs> AdminDeteleCategory;
        public event EventHandler AdminGetAllCateogires;
        public event EventHandler<CategoryEventArgs> AdminChangeCategory;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<OldBoardGamesNeedLoveToo.Models.Category> GridViewManageCategories_GetData()
        {
            this.AdminGetAllCateogires?.Invoke(this, null);

            return this.Model.Categories.ToList().AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewManageCategories_UpdateItem(Guid id)
        {
            this.AdminChangeCategory?.Invoke(this, new CategoryEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewManageCategories_DeleteItem(Guid id)
        {
            this.AdminDeteleCategory?.Invoke(this, new CategoryEventArgs(id));
        }

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            this.AdminAddCategory?.Invoke(this, new NewCategoryEventArgs(this.CategoryName.Text));
            this.CategoryName.Text = string.Empty;
        }
    }
}