using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Dal;
using StoreBl.Models;

namespace StoreBl.Bl
{
    public class ClsStores : IBusinessLayer<StoreModel>
    {
        #region GetAll FUNCTION
        public List<StoreModel> GetAll()
        {
            IDataAccess myDataAccess = DataAcessHelper.CreatObject();
            string storeList = myDataAccess.GetAll("store.txt");
            string[] Stores = storeList.Split('-');

            List<StoreModel> ListStores = new List<StoreModel>();
            StoreModel oStoreModel; // like ::: StoreModel oStoreModel = new StoreModel();

            foreach (string myStore in Stores)
            {
                if (string.IsNullOrEmpty(myStore)) continue; //egnore all codes bellow

                string[] StoreFileds = myStore.Split('#');
                oStoreModel = new StoreModel();// like ::: StoreModel oStoreModel = new StoreModel();
                oStoreModel.StoreId = Convert.ToInt32(StoreFileds[0]);
                oStoreModel.StoreName = StoreFileds[1];
                ListStores.Add(oStoreModel);
            }
            return ListStores;
        }
        #endregion

        #region Add Function
        public bool Add(StoreModel table)
        {
            #region auto incremnt id function
            //auto incremnt id function
            List<StoreModel> lstStores = GetAll();//get all stores
            int nStoreId = 0;
            if (lstStores.Count <= 0)
            {
                nStoreId = 1;
            }
            else
            {
                nStoreId = lstStores.Max(x => x.StoreId) + 1;
            } 
            #endregion

            string StoreData = string.Format("-{0}#{1}", nStoreId, table.StoreName);

            IDataAccess myDataAccess = DataAcessHelper.CreatObject();
            myDataAccess.Insert("store.txt", StoreData);
            return true;
        }
        #endregion

        #region Delete function
        public bool Delete(int id)
        {
            List<StoreModel> lstStores = GetAll();//get all stores
            StoreModel model = lstStores.Where(x => x.StoreId == id).FirstOrDefault();
            if (model == null)
            {
                return false;
            }
            else
            {
                lstStores.Remove(model);
                //reCreat file :
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var store in lstStores)
                {
                    if (nCount == 0)
                    {
                        sFileData += string.Format("{0}#{1}", store.StoreId, store.StoreName);
                    }
                    else
                    {
                        sFileData += string.Format("-{0}#{1}", store.StoreId, store.StoreName);
                    }
                    nCount++;

                    IDataAccess myDataAccess = DataAcessHelper.CreatObject();
                    myDataAccess.Delete("store.txt", sFileData);
                }
                return true;
            }
        } 
        #endregion
    }
}
