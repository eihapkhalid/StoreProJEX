using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Dal;
using StoreBl.Models;

namespace StoreBl.Bl
{
    public class ClsItems : IBusinessLayer<ItemModel>
    {
        #region GetAll
        public List<ItemModel> GetAll()
        {
            IDataAccess myDataAccess = DataAcessHelper.CreatObject();
            string itemList = myDataAccess.GetAll("items.txt");
            string[] Items = itemList.Split('-');

            List<ItemModel> ListItems = new List<ItemModel>();
            ItemModel oItemModel; // like ::: StoreModel oStoreModel = new StoreModel();

            foreach (string myItem in Items)
            {
                if (string.IsNullOrEmpty(myItem)) continue; //egnore all codes bellow

                string[] StoreFileds = myItem.Split('#');
                oItemModel = new ItemModel();// like ::: StoreModel oStoreModel = new StoreModel();
                oItemModel.ItemId = Convert.ToInt32(StoreFileds[0]);
                oItemModel.ItemName = StoreFileds[1];
                oItemModel.ItemPrice = Convert.ToDecimal(StoreFileds[2]);
                ListItems.Add(oItemModel);
            }
            return ListItems;
        }
        #endregion

        #region Add
        public bool Add(ItemModel table)
        {
            #region auto incremnt id function
            //auto incremnt id function
            List<ItemModel> lstItems = GetAll();//get all stores
            int nItemId = 0;
            if (lstItems.Count < 0)
            {
                nItemId = 1;
            }
            else
            {
                nItemId = lstItems.Max(x => x.ItemId) + 1;
            }
            #endregion

            string ItemData = string.Format("-{0}#{1}#{2}", nItemId, table.ItemName, table.ItemPrice);

            IDataAccess myDataAccess = DataAcessHelper.CreatObject();
            myDataAccess.Insert("items.txt", ItemData);
            return true;
        }
        #endregion

        #region Delete
        public bool Delete(int id)
        {
            List<ItemModel> lstItems = GetAll();//get all stores
            ItemModel model = lstItems.Where(x => x.ItemId == id).FirstOrDefault();
            if (model == null)
            {
                return false;
            }
            else
            {
                lstItems.Remove(model);
                //reCreat file :
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var item in lstItems)
                {
                    if (nCount == 0)
                    {
                        sFileData += string.Format("{0}#{1}#{2}", item.ItemId, item.ItemName, item.ItemPrice);
                    }
                    else
                    {
                        sFileData += string.Format("-{0}#{1}#{2}", item.ItemId, item.ItemName, item.ItemPrice);
                    }
                    nCount++;

                    IDataAccess myDataAccess = DataAcessHelper.CreatObject();
                    myDataAccess.Delete("items.txt", sFileData);
                }
                return true;
            }
        }
        #endregion

       
    }
}
