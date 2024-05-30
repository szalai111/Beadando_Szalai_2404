using Beadando_Szalai_2404.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Szalai_2404.Repository
{
    class MenuItemRepository
    {
        private RestaurantContext RestaurantContext;

        //Methods

        public MenuItemRepository(RestaurantContext Context)
        {
            this.RestaurantContext = Context;
        }

        public List<MenuItem> GetMenuItem()
        {
            return RestaurantContext.MenuItems.ToList();
        }

        public MenuItem GetMenuItemById(int id)
        {
            return RestaurantContext.MenuItems.Find(id);
        }

        public void InsertMenuItem(MenuItem menuitem)
        {
            RestaurantContext.MenuItems.Add(menuitem);
        }

        public void DeleteMenuItems(int MenuItemId)
        {
            MenuItem menuitem = RestaurantContext.MenuItems.Find(MenuItemId);
            RestaurantContext.MenuItems.Remove(menuitem);
        }

        public void UpdateMenuItem(MenuItem menuitem)
        {
            RestaurantContext.MenuItems.Find(menuitem.Id).Id = menuitem.Id;
            RestaurantContext.MenuItems.Find(menuitem.Id).ItemName = menuitem.ItemName;
            RestaurantContext.MenuItems.Find(menuitem.Id).Price = menuitem.Price;
        }

        public void Save()
        {
            RestaurantContext.SaveChanges();
        }

        public void Dispose()
        {
            RestaurantContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
