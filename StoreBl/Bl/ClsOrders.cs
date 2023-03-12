using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Dal;
using StoreBl.Models;

namespace StoreBl.Bl
{
    public class ClsOrders : IBusinessLayer<OrderModel>
    {
        public bool Add(OrderModel table)
        {
            #region auto incremnt id function
            //auto incremnt id function
            List<OrderModel> lstOrders = GetAll();//get all stores
            int nOrderId = 0;
            if (lstOrders.Count <= 0)
            {
                nOrderId = 1;
            }
            else
            {
                nOrderId = lstOrders.Max(x => x.OrderId) + 1;
            }
            #endregion

            string OrderData = string.Format("-{0}#{1}#{2}#{3}", nOrderId, table.OrderDateTime, table.OrderItem.ItemId, table.OrderStore.StoreId);

            IDataAccess myDataAccess = DataAcessHelper.CreatObject();
            myDataAccess.Insert("orders.txt", OrderData);
            return true;
        }

        public bool Delete(int id)
        {
            List<OrderModel> lstOrders = GetAll();//get all stores
            OrderModel model = lstOrders.Where(x => x.OrderId == id).FirstOrDefault();
            if (model == null)
            {
                return false;
            }
            else
            {
                lstOrders.Remove(model);
                //reCreat file :
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var order in lstOrders)
                {
                    if (nCount == 0)
                    {
                        sFileData += string.Format("{0}#{1}#{2}#{3}", order.OrderId, order.OrderDateTime, order.OrderItem.ItemId, order.OrderStore.StoreId);
                    }
                    else
                    {
                        sFileData += string.Format("-{0}#{1}#{2}#{3}", order.OrderId, order.OrderDateTime, order.OrderItem.ItemId, order.OrderStore.StoreId);
                    }
                    nCount++;

                    IDataAccess myDataAccess = DataAcessHelper.CreatObject();
                    myDataAccess.Delete("orders.txt", sFileData);
                }
                return true;
            }
        }

        public List<OrderModel> GetAll()
        {
            IDataAccess myDataAccess = DataAcessHelper.CreatObject();
            string orderList = myDataAccess.GetAll("orders.txt");
            string[] Orders = orderList.Split('-');

            List<OrderModel> ListOrder = new List<OrderModel>();
            OrderModel oOrderModel; // like ::: StoreModel oStoreModel = new StoreModel();

            foreach (string myOrder in Orders)
            {
                if (string.IsNullOrEmpty(myOrder)) continue; //egnore all codes bellow

                string[] OrderFileds = myOrder.Split('#');
                oOrderModel = new OrderModel();// like ::: StoreModel oStoreModel = new StoreModel();
                oOrderModel.OrderId = Convert.ToInt32(OrderFileds[0]);
                oOrderModel.OrderDateTime = Convert.ToDateTime(OrderFileds[1]);
                oOrderModel.OrderItem.ItemId = Convert.ToInt32(OrderFileds[2]);
                oOrderModel.OrderStore.StoreId = Convert.ToInt32(OrderFileds[3]);
                ListOrder.Add(oOrderModel);
            }
            return ListOrder;
        }

    }
}
